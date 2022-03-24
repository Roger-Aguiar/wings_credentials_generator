namespace WingsCredentialsApproval
{
    public interface ICredentialsGenerator
    {
        Credentials GenerateCredentials(Payload payload);
    }
}