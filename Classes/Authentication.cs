using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace WingsCredentialsApproval
{
    public class Authentication : IAuthentication
    {
        private readonly Headers headers;
        AccessToken token = null;
    
        public Authentication(Headers headers)
        {
            this.headers = headers;
        }
        public string GenerateAccessToken()
        {            
            string access_token = null;

            WebRequest requestObject = WebRequest.Create("https://api-dev.pottencial.com.br/oauth/v3/access-token");
            var encoded = System.Convert.ToBase64String(Encoding.GetEncoding("ISO-8859-1").GetBytes(headers.ClientId + ":" + headers.ClientSecret));
            requestObject.Headers.Add("Authorization", "Basic " + encoded);
            requestObject.ContentType = "application/json; charset=utf-8";
            requestObject.Method = WebRequestMethods.Http.Post;
            HttpWebResponse responseObject = (HttpWebResponse)requestObject.GetResponse();

            using (Stream stream = responseObject.GetResponseStream())
            {
                StreamReader streamReader = new StreamReader(stream);
                access_token = streamReader.ReadToEnd();
                streamReader.Close();
            }

            token = JsonConvert.DeserializeObject<AccessToken>(access_token);
            return token.Access_token;
        }
    }
}