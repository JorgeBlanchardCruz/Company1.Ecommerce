using Company1.Ecommerce.Application.Interface;
using Company1.Ecommerce.Service.WebApi.Modules.Injection;
using Company1.Ecommerce.Service.WebApi.Modules.Mapper;
using Company1.Ecommerce.Service.WebApi.Modules.Validator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Company1.Ecommerce.Application.Testing;

[TestClass]
public sealed class UsersApplicationTests
{
    private static IConfiguration _configuration;
    private static IServiceScopeFactory _serviceScopeFactory;

    [ClassInitialize]
    public static void Initialize(TestContext _)
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddEnvironmentVariables();

        _configuration = builder.Build();

        var services = new ServiceCollection();
        services.AddValidators();
        services.AddMapper();
        services.AddInjection(_configuration);
        _serviceScopeFactory = services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>();
    }


    [TestMethod]
    public void Authenicate_whenNoSendParameters_thenReturnsError()
    {
        // Arrange: When intializating the necessary objects  
        using var scope = _serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<IUsersApplication>();

        string userName = string.Empty;
        string password = string.Empty;
        const string expectedMessage = "Username or password is incorrect";

        // Act: When calling the method  
        var response = context.Authenticate(userName, password);

        // Assert: Then the result is as expected  
        Assert.IsFalse(response.IsSuccess);
        Assert.AreEqual(expectedMessage, response.Message);
    }

    [TestMethod]
    public void Authenicate_whenSendCorrectParameters_thenReturnsSuccess()
    {
        // Arrange: When intializating the necessary objects  
        using var scope = _serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<IUsersApplication>();

        string userName = "Jorge";
        string password = "123456";
        const string expectedMessage = "User authenticated successfully";

        // Act: When calling the method  
        var response = context.Authenticate(userName, password);

        // Assert: Then the result is as expected  
        Assert.IsTrue(response.IsSuccess);
        Assert.AreEqual(expectedMessage, response.Message);
    }

    [TestMethod]
    public void Authenicate_whenSendCorrectParameters_thenReturnsUserNotFound()
    {
        // Arrange: When intializating the necessary objects  
        using var scope = _serviceScopeFactory.CreateScope();
        var context = scope.ServiceProvider.GetRequiredService<IUsersApplication>();

        string userName = "Jorge";
        string password = "1234567";
        const string expectedMessage = "User not found";

        // Act: When calling the method  
        var response = context.Authenticate(userName, password);

        // Assert: Then the result is as expected  
        Assert.IsTrue(response.IsSuccess);
        Assert.AreEqual(expectedMessage, response.Message);
    }
}
