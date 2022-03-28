using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WingsCredentialsApproval
{
    public class CredentialsGenerator : ICredentialsGenerator
    {                
        private string credentialsResult = null;
        private readonly Headers headers;
        private readonly Payload payload;
                
        public CredentialsGenerator(Headers headers, Payload payload)
        {            
            this.headers = headers;
            this.payload = payload;
        }        
        
        public string GenerateCredentials()
        {                                              
            var authentication = new Authentication(headers.ClientId, headers.ClientSecret);
            var access_token = authentication.GenerateAccessToken();            
            var request = (HttpWebRequest)WebRequest.Create("https://api-dev.pottencial.com.br/apps/v1/apps/");            
            
            request.ContentType = "application/json";            
            request.Method = "POST";            
            request.Headers.Add("client_id", headers.ClientId);
            request.Headers.Add("client_secret", headers.ClientSecret);
            request.Headers.Add("access_token", access_token);
                     
            var json = JsonConvert.SerializeObject(payload);

            using(var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                credentialsResult = streamReader.ReadToEnd();
            }
                        
            return credentialsResult;
        }
    }
}