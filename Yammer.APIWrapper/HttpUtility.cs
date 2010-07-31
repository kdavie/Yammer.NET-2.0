using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yammer.APIWrapper.OAuth;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace Yammer.APIWrapper
{
    public static class HttpUtility
    {
        public static string Get(string url)
        {
            string nonce, timestamp;
            string signature = GetSignature(WebMethod.GET, url, out timestamp, out nonce);
            HttpWebRequest request = CreateWebRequest(url, WebMethod.GET, nonce, timestamp, signature);
            return GetWebResponse(request);
        }

        public static string Get(string url, NameValueCollection parameters)
        {

            string nonce, timestamp;
            string fullUrl = EncodeUrl(url, parameters);
            string signature = GetSignature(WebMethod.GET, fullUrl, out timestamp, out nonce);
            HttpWebRequest request = CreateWebRequest(fullUrl, WebMethod.GET, nonce, timestamp, signature);
            return GetWebResponse(request);
        }

        public static string Post(string url, NameValueCollection parameters)
        {
            string nonce, timestamp;
            string fullUrl = EncodeUrl(url, parameters);
            string signature = GetSignature(WebMethod.POST, fullUrl, out timestamp, out nonce);
            HttpWebRequest request = CreateWebRequest(fullUrl, WebMethod.POST, nonce, timestamp, signature);
            WritePostData(parameters, request);
            return GetWebResponse(request);
        }

        public static string Post(string url, NameValueCollection parameters, bool getLocationHeader)
        {
            string nonce, timestamp, location;
            string fullUrl = EncodeUrl(url, parameters);
            string signature = GetSignature(WebMethod.POST, fullUrl, out timestamp, out nonce);
             HttpWebRequest request = CreateWebRequest(fullUrl, WebMethod.POST, nonce, timestamp, signature);
            WritePostData(parameters, request);
            string response = GetWebResponse(request, out location);
            return location;

        }

        public static string Put(string url, NameValueCollection parameters)
        {
            string nonce, timestamp;
            string fullUrl = EncodeUrl(url, parameters);
            string signature = GetSignature(WebMethod.PUT, fullUrl, out timestamp, out nonce);
            HttpWebRequest request = CreateWebRequest(fullUrl, WebMethod.PUT, new string[] { nonce, timestamp, signature });


            WritePostData(parameters, request);
            return GetWebResponse(request);
        }

        public static string Delete(string url)
        {
            string nonce, timestamp;
            string signature = GetSignature(WebMethod.DELETE, url, out timestamp, out nonce);
            HttpWebRequest request = CreateWebRequest(url, WebMethod.DELETE, nonce, timestamp, signature);
            return GetWebResponse(request);

        }

        public static string Delete(string url, NameValueCollection parameters)
        {
            string nonce, timestamp;
            string fullUrl = EncodeUrl(url, parameters);
            string signature = GetSignature(WebMethod.DELETE, fullUrl, out timestamp, out nonce);
            HttpWebRequest request = CreateWebRequest(fullUrl, WebMethod.DELETE, nonce, timestamp, signature);
            return GetWebResponse(request);

        }

        public static string Upload(string url, NameValueCollection parameters, List<string> files)
        {
            return UploadAttachments(url, parameters, files);
        }

        private static string UploadAttachments(string url, NameValueCollection parameters, List<string> fileNames)
        {
            string nonce, timestamp;
            string beginBoundary = GenerateRandomString(25);
            string contentBoundary = "--" + beginBoundary;
            string endBoundary = contentBoundary + "--";
            string contentTrailer = "\r\n" + endBoundary;

            string fullUrl = EncodeUrl(url, parameters);
            string signature = HttpUtility.GetSignature(WebMethod.POST, fullUrl, out timestamp, out nonce);
            HttpWebRequest request = HttpUtility.CreateWebRequest(fullUrl, WebMethod.POST, nonce, timestamp, signature, beginBoundary);
            Version protocolVersion = HttpVersion.Version11;
            string method = WebMethod.POST.ToString();
            string contentType = "multipart/form-data; boundary=" + beginBoundary;
            string contentDisposition = "Content-Disposition: form-data; name=";
            request.Headers.Add("Cache-Control", "no-cache");
            request.KeepAlive = true;
            string postParams = GetPostParameters(parameters, contentBoundary, contentDisposition);

            FileInfo[] fi = new FileInfo[fileNames.Count];
            int i = 0;
            long postDataSize = 0;
            int headerLength = 0;
            byte[] newLineBytes = System.Text.Encoding.ASCII.GetBytes("\r\n");
            List<string> fileHeaders = new List<string>();
            AddFileHeaders(fileNames, contentBoundary, contentDisposition, fi, ref i, ref postDataSize, ref headerLength, fileHeaders);
            request.ContentLength = postParams.Length + headerLength + contentTrailer.Length + postDataSize + (fileNames.Count * newLineBytes.Length);

            System.IO.Stream io = request.GetRequestStream();

            WritePostData(postParams, io, false);
            i = 0;
            foreach (string fileName in fileNames)
            {
                WritePostData(fileHeaders[i], io, false);
                WriteFile(io, fileName);
                i++;
            }
            WritePostData(contentTrailer, io, true);

            string response = GetWebResponse(request);
            io.Close();
            request = null;

            return response;
        }

        public static string GetSignature(WebMethod method, string url, out string timestamp, out string nonce)
        {

            OAuthBase oAuth = new OAuthBase();
            nonce = oAuth.GenerateNonce();
            timestamp = oAuth.GenerateTimeStamp();
            string nurl, nrp;

            Uri uri = new Uri(url);
            string sig = oAuth.GenerateSignature(
                uri,
                Session.Auth.Key.ConsumerKey,
                Session.Auth.Key.ConsumerSecret,
                Session.Auth.Key.TokenKey,
                Session.Auth.Key.TokenSecret,
                method.ToString(),
                timestamp,
                nonce,
                OAuthBase.SignatureTypes.PLAINTEXT, out nurl, out nrp);

            return System.Web.HttpUtility.UrlEncode(sig);
        }

        private static string GetPostParameters(NameValueCollection parameters, string contentBoundary, string contentDisposition)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < parameters.Count; i++)
                sb.Append(contentBoundary + "\r\n" + contentDisposition + '"' + parameters.GetKey(i) + "\"\r\n\r\n" + parameters[i].ToString() + "\r\n");


            return sb.ToString();
        }

        private static void AddFileHeaders(List<string> fileNames, string contentBoundary, string contentDisposition, FileInfo[] fi, ref int i, ref long postDataSize, ref int headerLength, List<string> fileHeaders)
        {
            foreach (string s in fileNames)
            {
                bool isImage = IsValidImage(System.IO.File.OpenRead(s));
                string contentType = isImage ? "image/gif" : "text/xml";
                string header = contentBoundary + "\r\n" + contentDisposition + "\"attachment" + (i + 1).ToString() +
                                    "\"; filename=\"" + Path.GetFileName(s) + "\"\r\n" + "Content-type: " + contentType + "\r\n\r\n";
                fi[i] = new FileInfo(s);
                postDataSize += fi[i].Length;
                headerLength += header.Length;
                fileHeaders.Add(header);
                i++;
            }
        }

        private static void WritePostData(string postData, Stream requestStream, bool close)
        {
            byte[] postDataBytes = System.Text.Encoding.ASCII.GetBytes(postData);
            requestStream.Write(postDataBytes, 0, postDataBytes.Length);
            if (close)
                requestStream.Close();
        }

        public static void WritePostData(NameValueCollection parameters, HttpWebRequest request)
        {
            int count = 0;
            string queryString = string.Empty;
            foreach (string key in parameters.Keys)
            {
                if (count == 0)
                    queryString = key + "=" + Rfc3986.Encode(parameters[key]);
                else
                    queryString += "&" + key + "=" + Rfc3986.Encode(parameters[key]);

             
                count++;
            }

            queryString = System.Web.HttpUtility.UrlEncode(queryString);

            byte[] postDataBytes = Encoding.ASCII.GetBytes(queryString);
            request.ContentLength = postDataBytes.Length;
            Stream reqStream = request.GetRequestStream();
            reqStream.Write(postDataBytes, 0, postDataBytes.Length);
            reqStream.Close();
        }

        public static void WriteFile(System.IO.Stream io, string fileName)
        {
            int bufferSize = 10240;
            FileStream readIn = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            readIn.Seek(0, SeekOrigin.Begin); // move to the start of the file
            byte[] fileData = new byte[bufferSize];
            int bytes;
            while ((bytes = readIn.Read(fileData, 0, bufferSize)) > 0)
            {
                // read the file data and send a chunk at a time
                io.Write(fileData, 0, bytes);
            }

            readIn.Close();

            byte[] newLineBytes = System.Text.Encoding.ASCII.GetBytes("\r\n");
            io.Write(newLineBytes, 0, newLineBytes.Length);


        }

        private static HttpWebRequest CreateWebRequest(string fullUrl, WebMethod method, string nonce, string timeStamp, string sig)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullUrl);
            request.Method = method.ToString();
            request.Proxy = Session.WebProxy;
            string authHeader = CreateAuthHeader(method, nonce, timeStamp, sig);
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add("Authorization", authHeader);

            return request;
        }

        public static HttpWebRequest CreateWebRequest(WebMethod method, WebProxy proxy, string requestUrl, bool preAuth)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
            request.Method = method.ToString();
            request.PreAuthenticate = preAuth;
            request.Proxy = proxy;

            return request;
        }

        public static HttpWebRequest CreateWebRequest(WebMethod method, string requestUrl, bool preAuth)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(requestUrl);
            request.Method = method.ToString();
            request.PreAuthenticate = preAuth;
            request.Proxy = HttpWebRequest.DefaultWebProxy;

            return request;
        }

        public static HttpWebRequest CreateWebRequest(string fullUrl, WebMethod method, string nonce, string timeStamp, string sig, string boundary)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullUrl);
            request.Method = method.ToString();
            request.Proxy = Yammer.APIWrapper.Session.WebProxy;
            string authHeader = CreateAuthHeader(method, nonce, timeStamp, sig);
            request.ContentType = "multipart/form-data; boundary=" + boundary;
            request.Headers.Add("Authorization", authHeader);
            return request;
        }

        private static HttpWebRequest CreateWebRequest(string fullUrl, WebMethod method, string[] oauthParams)
        {
            string nonce, timeStamp, sig;
            nonce = oauthParams[0];
            timeStamp = oauthParams[1];
            sig = oauthParams[2];
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(fullUrl);
            request.ServicePoint.Expect100Continue = false;
            request.KeepAlive = false;
            request.ProtocolVersion = HttpVersion.Version10;
            request.Method = method.ToString();
            request.Proxy = Yammer.APIWrapper.Session.WebProxy;
            string authHeader = CreateAuthHeader(method, nonce, timeStamp, sig);
            request.ContentType = "text/plain";
            request.Headers.Add("Authorization", authHeader);

            return request;
        }

        private static string CreateAuthHeader(WebMethod method, string nonce, string timeStamp, string sig)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("OAuth ");
            if (method == WebMethod.POST)
                sb.Append("realm=\"" + "\",");
            else
                sb.Append("realm=\"\",");

            string authHeader = "oauth_consumer_key=\"" + Session.Auth.Key.ConsumerKey + "\"," +
                                "oauth_token=\"" + Session.Auth.Key.TokenKey + "\"," +
                                "oauth_nonce=\"" + nonce + "\"," +
                                "oauth_timestamp=\"" + timeStamp + "\"," +
                                "oauth_signature_method=\"" + "PLAINTEXT" + "\"," +
                                "oauth_version=\"" + "1.0" + "\"," +
                                "oauth_signature=\"" + sig + "\"";


            sb.Append(authHeader);
            return sb.ToString();

            //Authorization: OAuth realm="", oauth_consumer_key="AMbmZSOP3wHm1cjfvSsRg", oauth_signature_method="HMAC-SHA1", oauth_signature="yLDH5eLS4uUVa3vVbNxvDX9B8aFgnwRSFla3jph9y90%26", oauth_timestamp="1229537444", oauth_nonce="1229537444", oauth_version="1.0"

        }

        private static string GenerateRandomString(int intLenghtOfString)
        {
            StringBuilder randomString = new StringBuilder();
            Random randomNumber = new Random();
            Char appendedChar;
            for (int i = 0; i <= intLenghtOfString; ++i)
            {
                appendedChar = Convert.ToChar(Convert.ToInt32(26 * randomNumber.NextDouble()) + 65);
                randomString.Append(appendedChar);
            }
            return randomString.ToString();
        }

        private static bool IsValidImage(Stream imageStream)
        {
            if (imageStream.Length > 0)
            {
                byte[] header = new byte[4]; // Change size if needed.
                string[] imageHeaders = new[]{
                "\xFF\xD8", // JPEG
                "BM",       // BMP
                "GIF",      // GIF
                Encoding.ASCII.GetString(new byte[]{137, 80, 78, 71})}; // PNG

                imageStream.Read(header, 0, header.Length);

                bool isImageHeader = imageHeaders.Count(str => Encoding.ASCII.GetString(header).StartsWith(str)) > 0;
                if (isImageHeader == true)
                {
                    try
                    {
                        System.Drawing.Image.FromStream(imageStream).Dispose();
                        imageStream.Close();
                        return true;
                    }

                    catch
                    {

                    }
                }
            }

            imageStream.Close();
            return false;
        }

        public static string GetWebResponse(HttpWebRequest request)
        {
            string location = string.Empty;
            return GetWebResponse(request, out location);
        }

        public static string GetWebResponse(HttpWebRequest request, out string location)
        {
           
            WebResponse response = null;
            string data = string.Empty;
            location = string.Empty;
            try
            {
                response = request.GetResponse();
                location = response.Headers["Location"];
                using (StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8))
                    data = reader.ReadToEnd();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (response != null)
                    response.Close();
            
            }

            return data;
        }

        public static string EncodeUrl(string url, NameValueCollection parameters)
        {
            string fullUrl = string.Empty;
            int count = 0;
            foreach (string key in parameters.Keys)
            {
                if (count == 0)
                    fullUrl = url + "?" + key + "=" + Rfc3986.Encode(parameters[key]);
                else
                    fullUrl += "&" + key + "=" + Rfc3986.Encode(parameters[key]);

              
                count++;
            }
            return fullUrl;
        }

        public static System.Drawing.Image GetImage( string url)
        {

            try
            {
                Dictionary<string, DirectoryInfo> appData = Yammer.APIWrapper.Utility.GetAppData();
                string fileName = Yammer.APIWrapper.Utility.GetMd5Sum(url);
                System.Drawing.Image image;
                if (!System.IO.File.Exists(appData["images"] + "\\" + fileName + ".jpg"))
                {
                    HttpWebRequest request = Yammer.APIWrapper.HttpUtility.CreateWebRequest(Yammer.APIWrapper.WebMethod.GET, Yammer.APIWrapper.Session.WebProxy, url, false);
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    Stream stream = response.GetResponseStream();
                    System.Threading.Monitor.Enter(stream);
                    image = System.Drawing.Image.FromStream(stream);
                    image.Save(appData["images"] + "\\" + fileName + ".jpg");
                    System.Threading.Monitor.Exit(stream);
                    if (stream != null)
                        stream.Close();
                }
                else
                {
                    FileInfo file = new FileInfo(appData["images"] + "\\" + fileName + ".jpg");
                    System.Threading.Monitor.Enter(file);
                    image = System.Drawing.Image.FromFile(file.FullName);
                    System.Threading.Monitor.Exit(file);
                }


                return image;
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                throw ex;
            }
        }

    }

    
}
