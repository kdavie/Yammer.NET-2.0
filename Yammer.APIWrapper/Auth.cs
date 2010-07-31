using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yammer.APIWrapper.OAuth;
using System.Net;
using System.Collections.Specialized;

namespace Yammer.APIWrapper
{
    public delegate void YammerErrorEventHandler(YammerErrorEventArgs args);
    [Serializable]
    public class YammerErrorEventArgs : EventArgs
    {
        public YammerErrorEventArgs(string type, Exception ex)
        {
            this.Exception = ex;
            this.Type = type;
        }

        public Exception Exception { get; set; }

        public string Type { get; set; }
    }

    [Serializable]
    public class Auth
    {
        #region Ctor

        public Auth()
        {

        }

        public Auth(OAuthKey key)
        {
            this.Key = key;
        }



        #endregion

        #region Properties

        /// <summary>
        /// The client Web Proxy.  Can be null
        /// </summary>
        /// <remarks></remarks>

        public WebProxy Proxy { get; set; }

        /// <summary>
        /// The OAuth key to use
        /// </summary>

        public OAuthKey Key { get; set; }

        /// <summary>
        /// The client's consumer key
        /// </summary>

        private string ConsumerKey { get; set; }

        /// <summary>
        /// The client's consumer secret
        /// </summary>

        private string ConsumerSecret { get; set; }

        /// <summary>
        /// The persisted client settings file.
        /// </summary>

        public Settings Settings { get; set; }

        /// <summary>
        /// Connection success indicator
        /// </summary>

        public bool Success
        {
            get
            {
                return success;
            }
            set
            {
                success = value;
                OnAuthorizationComplete();
            }
        }

        private bool success;

        #endregion

        public event EventHandler AuthorizationComplete;
        public void OnAuthorizationComplete()
        {

            //Session.Settings = Yammer.Settings.CheckConfiguration();
            //Session.Settings.Save();
            //Session.Assets.GetUsers();
            //Session.Assets.GetAvatars();

            if (this.AuthorizationComplete != null)
                this.AuthorizationComplete(this, new EventArgs());



        }


        #region Helper Methods

        /// <summary>
        /// Retrieves the OAuth request token
        /// </summary>
        /// <param name="consumerKey">The client's consumer key</param>
        /// <param name="consumerSecret">The client's consumer secret</param>
        /// <returns>the request token query string</returns>
        private string GetRequestTokenQuery(string consumerKey, string consumerSecret)
        {
            //TODO: Utilize Yammer.HttpUtility for get
            Uri uri = new Uri(Resources.OAuth.RequestToken);
            string nurl;
            string nrp;

            OAuthBase oAuth = new OAuthBase();
            string nonce = oAuth.GenerateNonce();
            string timeStamp = oAuth.GenerateTimeStamp();
            string sig = oAuth.GenerateSignature(
                uri,
                consumerKey,
                consumerSecret,
                string.Empty,
                string.Empty,
                "GET",
                timeStamp,
                nonce,
                OAuthBase.SignatureTypes.HMACSHA1, out nurl, out nrp);
            sig = System.Web.HttpUtility.UrlEncode(sig);

            StringBuilder sb = new StringBuilder(uri.ToString());
            sb.AppendFormat("?oauth_consumer_key={0}&", consumerKey);
            sb.AppendFormat("oauth_nonce={0}&", nonce);
            sb.AppendFormat("oauth_timestamp={0}&", timeStamp);
            sb.AppendFormat("oauth_signature_method={0}&", "HMAC-SHA1");
            sb.AppendFormat("oauth_version={0}&", "1.0");
            sb.AppendFormat("oauth_signature={0}", sig);
            string query = sb.ToString();

            return query;
        }

        /// <summary>
        /// Retrieves the OAuth authorization token
        /// </summary>
        /// <param name="tokenKey">The generated OAuth Token</param>
        /// <param name="callback">The callback URL for the client</param>
        /// <returns>the OAuth authorization query string</returns>
        private string GetAuthorizeQuery(string tokenKey, string callback)
        {
            return Resources.OAuth.Authorize + "?oauth_token=" + tokenKey;
        }

        /// <summary>
        /// Retrieves OAuth access token
        /// </summary>
        /// <returns>the OAuth access token query string</returns>
        private string GetAccessTokenQuery(string callbackToken)
        {
            Uri uri = new Uri(Resources.OAuth.AccessToken + "?callback_token=" + callbackToken);
            string nurl;
            string nrp;

            OAuthBase oAuth = new OAuthBase();
            string nonce = oAuth.GenerateNonce();
            string timeStamp = oAuth.GenerateTimeStamp();
            string sig = string.Empty;

            #region Generate OAuth Signature

            sig = oAuth.GenerateSignature(
                uri,
                Key.ConsumerKey,
                Key.ConsumerSecret,
                Key.TokenKey,
                Key.TokenSecret,
                "POST",
                timeStamp,
                nonce,
                OAuthBase.SignatureTypes.HMACSHA1, out nurl, out nrp);

            #endregion

            sig = System.Web.HttpUtility.UrlEncode(sig);

            StringBuilder sb = new StringBuilder(uri.ToString());
            sb.AppendFormat("&oauth_consumer_key={0}&", Key.ConsumerKey);
            sb.AppendFormat("oauth_token={0}&", Key.TokenKey);
            sb.AppendFormat("oauth_signature_method={0}&", "HMAC-SHA1");
            sb.AppendFormat("oauth_timestamp={0}&", timeStamp);
            sb.AppendFormat("oauth_nonce={0}&", nonce);
            sb.AppendFormat("oauth_version={0}&", "1.0");
            sb.AppendFormat("oauth_signature={0}", sig);

            string query = sb.ToString();

            return query;
        }

        #endregion

        #region Public Functions

        /// <summary>
        /// retrieves the <see cref="Auth">authorization object</see>
        /// </summary>
        /// <param name="proxy"></param>
        /// <param name="consumerKey"></param>
        /// <param name="consumerSecret"></param>
        /// <returns>The <see cref="Auth">authorization object</see></returns>
        public static Auth GetRequestToken(WebProxy proxy, string consumerKey, string consumerSecret)
        {
            Auth auth = new Auth();
            try
            {
                auth.Proxy = proxy;
                 
                HttpWebRequest request = Yammer.APIWrapper.HttpUtility.CreateWebRequest(WebMethod.GET, proxy, auth.GetRequestTokenQuery(consumerKey, consumerSecret), true);

                string response = Yammer.APIWrapper.HttpUtility.GetWebResponse(request);
                string tokenKey;
                string tokenSecret;
                ReadResponse(response, out tokenKey, out tokenSecret);
                auth.Key = new OAuthKey(consumerKey, consumerSecret, tokenKey, tokenSecret);
            }
            catch (WebException ex)
            {
               
                if (ex.Status == WebExceptionStatus.ConnectFailure || ex.Status == WebExceptionStatus.ServerProtocolViolation)
                {
                    if (Auth.Error != null)
                        Auth.Error(new YammerErrorEventArgs("ProxyError", ex));
                }
            }
            catch (Exception ex)
            {
                
                auth.Success = false;

                throw ex;
            }

            return auth;
        }

        public static event YammerErrorEventHandler Error;
        /// <summary>
        /// Opens web browser for authorization
        /// </summary>
        /// <param name="callbackUrl"></param>
        public void Authorize(string callbackUrl)
        {
            try
            {
                
                if (Key == null)
                    throw new NullReferenceException("You must get a request token before obtaining an authorization URL.");

                System.Diagnostics.Process.Start(GetAuthorizeQuery(this.Key.TokenKey, callbackUrl));
                
            }
            catch (Exception ex)
            {
                 

            }
        }

        /// <summary>
        /// Retrieves the authorization information from the server
        /// and saves it the persisted see cref="Settings">settings</see> file
        /// </summary>
        public void GetAccessToken(string callbackToken)
        {
            try
            {

                HttpWebRequest request = Yammer.APIWrapper.HttpUtility.CreateWebRequest(WebMethod.POST, this.Proxy, GetAccessTokenQuery(callbackToken), true);

                string response = Yammer.APIWrapper.HttpUtility.GetWebResponse(request);
                string tokenKey;
                string tokenSecret;
                Auth.ReadResponse(response, out tokenKey, out tokenSecret);
           
                Settings.SaveConfiguration(tokenKey, tokenSecret, this.Key, this.Proxy);                
                this.Success = true;
            }
            catch (WebException ex)
            {
               
                this.Success = false;
                //if (ex.Message.Trim() == "The remote server returned an error: (401) Unauthorized.")
                //    System.Windows.Forms.MessageBox.Show("You must authorize this application before continuing.");
            }
            catch (InvalidOperationException ex)
            {
                this.Success = false;
            }
            catch (Exception ex)
            {
                 
                this.Success = false;
                throw ex;
            }


        }

      

        /// <summary>
        /// Splits the Yammer token key and token secret from the response
        /// </summary>
        /// <param name="response">The http web response</param>
        /// <param name="tokenKey">the token key to save to</param>
        /// <param name="tokenSecret">the token secret to save to</param>
        private static void ReadResponse(string response, out string tokenKey, out string tokenSecret)
        {
            if (response != string.Empty && response != null)
            {
                string[] data = response.Split('&');
                tokenKey = data[0].Split('=')[1];
                tokenSecret = data[1].Split('=')[1];
            }
            else
                throw new NullReferenceException("Http response cannot be empty or null");
        }


        #endregion

    }
}
