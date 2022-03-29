using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;

namespace WingsCredentialsApproval
{
    public class Hefesto : IHefesto
    {
        private readonly HefestoBody hefestoBody;

        public Hefesto(HefestoBody hefestoBody)
        {
            this.hefestoBody = hefestoBody;
        }
        
        public string GetTokenFromHefesto()
        {
            var httpClient = new HttpClient();
            var request = httpClient.PostAsync("https://hefesto-dev.pottencial.com.br/connect/token", new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", hefestoBody.grant_type),
                new KeyValuePair<string, string>("client_id", hefestoBody.client_id),
                new KeyValuePair<string, string>("client_secret", hefestoBody.client_secret),
                new KeyValuePair<string, string>("scope", hefestoBody.scope),
            })).GetAwaiter().GetResult();

            var result = request.Content.ReadAsStringAsync();                      
            
            var token = JsonConvert.DeserializeObject<dynamic>(result.Result);
            return token.access_token;
        }
    }
}