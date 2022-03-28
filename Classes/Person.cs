using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace WingsCredentialsApproval
{
    public class Person : IPerson
    {
        private readonly HefestoBody hefestoBody;
        private readonly UrlParams urlParams;

        public Person(HefestoBody hefestoBody, UrlParams urlParams)
        {
            this.hefestoBody = hefestoBody;
            this.urlParams = urlParams;
        }

        public string GetPersonId()
        {            
            var httpClient = new HttpClient();
            var access_token = new Hefesto(hefestoBody);
            
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", access_token.GetTokenFromHefesto());
                       
            var request = httpClient.GetAsync($"https://person-dev-shared.pottencial.com.br/api/persons/{urlParams.documentType}/{urlParams.documentNumber}").GetAwaiter().GetResult();
            var result = request.Content.ReadAsStringAsync();
            PersonResponse personResponse = JsonConvert.DeserializeObject<PersonResponse>(result.Result);
            return personResponse.Id;
        }
    }
}