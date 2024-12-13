using Business.Factories;
using Business.Models;

namespace Business.Tests.Factories;


public class ContactFactory_Tests
{
    [Fact]
    public void CreateContact_WhenCalled_ShouldCreateContact()
    {
        // Act
        var result = ContactFactory.CreateContact();

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ContactRegForm>(result);

    }
}
