namespace WingsCredentialsApproval
{
    public interface ICredentialsGenerator
    {
        string GenerateCredentials(Payload payload);
    }
}