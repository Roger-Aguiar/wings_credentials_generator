namespace WingsCredentialsApproval
{
    public class HefestoBody
    {        
        public string client_id {get; init;}
        public string client_secret {get; init;}
        public string grant_type {get; init;}
        public string scope {get; init;}

        public HefestoBody(string client_id, string client_secret, string grant_type, string scope)
        {
            this.client_id = client_id;
            this.client_secret = client_secret;
            this.grant_type = grant_type;
            this.scope = scope;
        }        
    }
}