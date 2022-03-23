using System.IO;
using System.Net;
using Newtonsoft.Json;

namespace WingsCredentialsApproval
{
    public class CredentialsGenerator : ICredentialsGenerator
    {
        private string clientId;
        private string clientSecret;
        private string name;
        private string description;
        private string email;
        private string [] apis;
        private string personRole;
        private string personId;
        private string credentialsResult = null; 
        private int id;
        private string code;
        private string secret;

        public CredentialsGenerator(string clientId, string clientSecret, string name, string description, string email, string [] apis, string personRole, string personId)
        {
            this.clientId = clientId;
            this.clientSecret = clientSecret;
            this.name = name;
            this.description = description;
            this.email = email;
            this.apis = apis;
            this.personRole = personRole;
            this.personId = personId;
        }

        public void GenerateCredentials()
        {                                  
            var authentication = new Authentication(clientId, clientSecret);
            var access_token = authentication.GenerateAccessToken();            
            var request = (HttpWebRequest)WebRequest.Create("https://api-dev.pottencial.com.br/apps/v1/apps/");            
            
            request.ContentType = "application/json";            
            request.Method = "POST";            
            request.Headers.Add("client_id", this.clientId);
            request.Headers.Add("client_secret", this.clientSecret);
            request.Headers.Add("access_token", access_token);
            
            var payload = new Payload(name, description, email, apis, personRole, personId);            
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
            id = credentials.Id;
            code = credentials.Code;
            secret = credentials.Secret;
        }

        public string GetClientId()
        {
            return clientId;
        }

        public string GetClientSecret()
        {
            return clientSecret;
        }

        public int GetId()
        {
            return id;
        }
    }
}