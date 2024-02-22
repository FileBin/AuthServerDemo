using Filebin.Common.Models.Auth;
using Filebin.Common.Tests;

namespace Filebin.AuthServer.Tests.Tests;

public class AuthTest : SetupUserApi {
    [Test]
    [CancelAfter(10_000)]
    public async Task UserInfoGet(CancellationToken cancellationToken) {
        var userCredentials = new UserCredentials {
            Email = "waffle@example.com",
            Username = "waffle",
            Password = TestGenerator.GenerateRandomPassword()
        };

        var result = await RegisterUser(userCredentials);
        Assert.That(result.IsSuccessStatusCode);

        await VerifyEmail(cancellationToken);

        result = await LoginUser(userCredentials);
        Assert.That(result.IsSuccessStatusCode);

        var loginResult = await GetJsonContent<LoginResultDto>(result);
        result = await GetUserInfo(loginResult.AccessToken);
        Assert.That(result.IsSuccessStatusCode);

        var userInfo = await GetJsonContent<UserInfoDto>(result);

        Assert.That(userInfo.Username, Is.EqualTo(userCredentials.Username));
        Assert.That(userInfo.Email, Is.EqualTo(userCredentials.Email));
    }

    [Test]
    [CancelAfter(10_000)]
    public async Task UserInfoUnauthorized(CancellationToken cancellationToken) {
        var userCredentials = new UserCredentials {
            Email = "waffle@example.com",
            Username = "waffle",
            Password = TestGenerator.GenerateRandomPassword()
        };

        var result = await RegisterUser(userCredentials);
        Assert.That(result.IsSuccessStatusCode);

        result = await GetUserInfo();
        Assert.That(!result.IsSuccessStatusCode);
    }


}
