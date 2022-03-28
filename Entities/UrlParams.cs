namespace WingsCredentialsApproval
{
    public class UrlParams
    {       
        public string documentType {get; init;}
        public string documentNumber {get; init;}

        public UrlParams(string documentType, string documentNumber)
        {
            this.documentType = documentType;
            this.documentNumber = documentNumber;
        }
    }
}