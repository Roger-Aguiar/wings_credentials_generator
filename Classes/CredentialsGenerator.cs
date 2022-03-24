using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WingsCredentialsApproval
{
    public class CredentialsGenerator : ICredentialsGenerator
    {
        private string clientId;
        private string clientSecret;        
        private string credentialsResult = null;
                
        public CredentialsGenerator(Headers headers)
        {
            this.clientId = headers.ClientId;
            this.clientSecret = headers.ClientSecret;  
        }        
        public Credentials GenerateCredentials(Payload payload)
        {                                  
            var authentication = new Authentication(clientId, clientSecret);
            var access_token = authentication.GenerateAccessToken();            
            var request = (HttpWebRequest)WebRequest.Create("https://api-dev.pottencial.com.br/apps/v1/apps/");            
            
            request.ContentType = "application/json";            
            request.Method = "POST";            
            request.Headers.Add("client_id", this.clientId);
            request.Headers.Add("client_secret", this.clientSecret);
            request.Headers.Add("access_token", access_token);
                     
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(payload);

            using(var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(json);
            }

            var response = (HttpWebResponse)request.GetResponse();

            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                credentialsResult = streamReader.ReadToEnd();
            }

            Credentials credentials = JsonConvert.DeserializeObject<Credentials>(credentialsResult);  
            
            return credentials;
        }
    }
}