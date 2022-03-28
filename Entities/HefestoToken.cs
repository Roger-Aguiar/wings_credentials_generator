namespace WingsCredentialsApproval
{
    public class HefestoToken
    {
        public string access_token {get; init;}
        public string expires_in {get; init;}
        public string token_type {get; init;}
        public string scope {get; init;}

        public HefestoToken(string access_token, string expires_in, string token_type, string scope)
        {
            this.access_token = access_token;
            this.expires_in = expires_in;
            this.token_type = token_type;
            this.scope = scope;
        }
    }
}