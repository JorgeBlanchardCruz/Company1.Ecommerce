using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Company1.Ecommerce.Application.Testing;

[TestClass]
public sealed class UsersApplicationTests
{
    private static WebApplicationFactory<Program> _factory = null!;
    private static IServiceScopeFactory _serviceScopeFactory = null!;

    [ClassInitialize]
    public static void Initialize(TestContext _)
    {
        _factory = new CustomWebApplicationFactory();
        _serviceScopeFactory = _factory.Services.GetRequiredService<IServiceScopeFactory>();
    }

    [TestMethod]
    public void Authenicate_whenNoSendParameters_thenReturnsError()
    {
        // Arrange: When intializating the necessary objects  
        //using var scope = _serviceScopeFactory.CreateScope();
        //var context = scope.ServiceProvider.GetRequiredService<IUsersApplication>();

        //string userName = string.Empty;
        //string password = string.Empty;
        //const string expectedMessage = "Username or password is incorrect";

        //// Act: When calling the method  
        //var response = context.Authenticate(userName, password);

        //// Assert: Then the result is as expected  
        //Assert.IsFalse(response.IsSuccess);
        //Assert.AreEqual(expectedMessage, response.Message);
    }

    [TestMethod]
    public void Authenicate_whenSendCorrectParameters_thenReturnsSuccess()
    {
        //// Arrange: When intializating the necessary objects  
        //using var scope = _serviceScopeFactory.CreateScope();
        //var context = scope.ServiceProvider.GetRequiredService<IUsersApplication>();

        //string userName = "Jorge";
        //string password = "123456";
        //const string expectedMessage = "User authenticated successfully";

        //// Act: When calling the method  
        //var response = context.Authenticate(userName, password);

        //// Assert: Then the result is as expected  
        //Assert.IsTrue(response.IsSuccess);
        //Assert.AreEqual(expectedMessage, response.Message);
    }

    [TestMethod]
    public void Authenicate_whenSendCorrectParameters_thenReturnsUserNotFound()
    {
        //// Arrange: When intializating the necessary objects  
        //using var scope = _serviceScopeFactory.CreateScope();
        //var context = scope.ServiceProvider.GetRequiredService<IUsersApplication>();

        //string userName = "Jorge";
        //string password = "1234567";
        //const string expectedMessage = "User not found";

        //// Act: When calling the method  
        //var response = context.Authenticate(userName, password);

        //// Assert: Then the result is as expected  
        //Assert.IsTrue(response.IsSuccess);
        //Assert.AreEqual(expectedMessage, response.Message);
    }
}
