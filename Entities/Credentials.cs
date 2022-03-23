namespace WingsCredentialsApproval
{
    public class Credentials
    {
        private int id;
        private string code;
        private string secret;

        public int Id { get => id; set => id = value; }
        public string Code { get => code; set => code = value; }
        public string Secret { get => secret; set => secret = value; }
    }
}