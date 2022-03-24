namespace WingsCredentialsApproval
{
    public class Headers
    {
        public string ClientId {get; init;}
        public string ClientSecret {get; init;}

        public Headers(string clientId, string clientSecret)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
        }
    }
}