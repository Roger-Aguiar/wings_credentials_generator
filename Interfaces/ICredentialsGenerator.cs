namespace WingsCredentialsApproval
{
    public interface ICredentialsGenerator
    {
        void GenerateCredentials();
        int GetId();
        string GetClientId();
        string GetClientSecret();
    }
}