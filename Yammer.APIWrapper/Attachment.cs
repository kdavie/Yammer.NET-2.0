using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
 

namespace Yammer.APIWrapper
{
    public class Attachment
    {
        #region Yammer Properties

        /// <summary>
        /// Indicates the type of attachment. Current options: image and file
        /// </summary>
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        /// <summary>
        /// Numerical idenifier for this attachment.
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        /// <summary>
        /// Short text identifier which may not be unique.
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Where the attachment can be viewed on the Yammer website
        /// </summary>
        [JsonProperty(PropertyName = "web-url")]
        public string WebUrl { get; set; }

        /// <summary>
        /// Image attachment
        /// </summary>
        [JsonProperty(PropertyName = "image")]
        public Image Image { get; set; }

        /// <summary>
        /// File attachment
        /// </summary>
        [JsonProperty(PropertyName = "file")]
        public File File { get; set; }

        #endregion

        #region Client Properties

        [JsonIgnore]
        public string EncodedString { get; set; }

        [JsonIgnore]
        public AttachmentType AttachmentType { get; set; }

        [JsonIgnore]
        public string FilePath;
        /// <summary>
        /// The filename of the filepart to be uploaded.
        /// </summary>
        [JsonIgnore]
        public string Filename;
        /// <summary>
        /// The starting position in the stream.
        /// </summary>
        [JsonIgnore]
        public long StartPos;
        /// <summary>
        /// The ending position in the stream.
        /// </summary>
        [JsonIgnore]
        public long EndPos;
        /// <summary>
        /// The total file length.
        /// </summary>
        [JsonIgnore]
        public long TotalFileLength;
        /// <summary>
        /// The stream of the file to be sent.
        /// </summary>
        [JsonIgnore]
        public System.IO.Stream BinaryStream;

        /// <summary>
        /// Gets the length of the data to be sent.
        /// </summary>
        [JsonIgnore]
        public long Length { get { return this.EndPos - this.StartPos + 1; } }

        #endregion


         
        public class FileInfo
        {
            public FileInfo()
            {
            }

            public FileInfo(string contentType, string name, byte[] bytes)
            {
 
                this.ContentType = contentType;
                this.Name = name;
                this.Buffer = bytes;
            }

            public string ContentType { get; set; }
            public string Name { get; set; }
            public byte[] Buffer { get; set; }
        }
    }

}
