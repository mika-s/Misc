using System;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Web
{
    [DataContract]
    public class TimeInfo
    {
        [DataMember]
        internal string time;

        [DataMember]
        internal UInt64 milliseconds_since_epoch;

        [DataMember]
        internal string date;

        public override string ToString()
        {
            return $"time: {time}\nmilliseconds_since_epoch: {milliseconds_since_epoch}\ndate: {date}";
        }
    }

    [DataContract]
    public class BlogPost
    {
        [DataMember]
        public int userId;

        [DataMember]
        public string title;

        [DataMember]
        public string body;
    }

    [DataContract]
    public class Response
    {
        [DataMember]
        internal int Id;
    }

    public sealed class RestTestService
    {
        public async Task<TimeInfo> GetTimeInfo()
        {
            TimeInfo timeInfo;
            using (WebClient wc = new WebClient())
            {
                wc.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                string content = await wc.DownloadStringTaskAsync(new Uri("http://time.jsontest.com/"));
                timeInfo = Deserialize<TimeInfo>(content);
            }

            return timeInfo;
        }

        public async Task<Response> PostBlogPost(BlogPost blogPost)
        {
            string URI = "https://jsonplaceholder.typicode.com/posts/";

            var ser = new JavaScriptSerializer();
            string json = ser.Serialize(blogPost);

            Response response;
            using (WebClient wc = new WebClient())
            {
                string responseData = string.Empty;
                wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                responseData = await wc.UploadStringTaskAsync(URI, json);
                response = Deserialize<Response>(responseData);
            }

            return response;
        }

        private T Deserialize<T>(string contentToRead) where T : class
        {
            T objectToDeserializeTo;
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(contentToRead)))
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                objectToDeserializeTo = ser.ReadObject(ms) as T;
            }

            return objectToDeserializeTo;
        }
    }
}
