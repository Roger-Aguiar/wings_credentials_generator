using Xunit;

namespace WingsCredentialsApproval
{
    public class AuthenticationTest
    {
        [Fact]
        public void GenerateAccessTokenTest()
        {
            Headers headers = new Headers("c3b9d872-d137-3f79-b801-8ac182f8379f", "e57c37fc-236b-3204-9e54-aa25abde9111");
            var authentication = new Authentication(headers);
            
            Assert.Equal(36, authentication.GenerateAccessToken().Length);
            Assert.NotEmpty(authentication.GenerateAccessToken());
        }
    }

}
