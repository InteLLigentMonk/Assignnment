using Business.Helpers;

namespace Business.Tests.Helpers;

public class IdGenerator_Tests
{
    [Fact]
    public void UniqueIdGenerator_WhenCalled_ShouldGenerateUniqueId()
    {
        // Act
        var result = IdGenerator.UniqueIdGenerator();
        // Assert
        Assert.NotNull(result);
        Assert.IsType<string>(result);
        Assert.True(Guid.TryParse(result, out _));
    }
}
