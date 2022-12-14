using Samples.UnitTestingWorkshop.Lib;

namespace Sample.UnitTestingWorkshop.Lib.Tests;

public class EmailAddressShould
{
    [Theory]
    [InlineData("foo@foo.foo")]
    [InlineData("example@gmail.com")]
    public void NotThrowExceptionWhenIsValid(string email)
    {
        EmailAddress emailAddress = email;

        emailAddress
            .Value
            .Should()
            .Be(email);
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    [InlineData("lorem ipsum")]
    [InlineData("foo.foo")]
    [InlineData("@foo.foo")]
    public void ThrowExceptionWhenIsNotValid(string email)
    {
        Action action = () =>
        {
            EmailAddress emailAddress = email;
        };

        action.Should().Throw<InvalidOperationException>();
    }

    [Theory]
    [InlineData("mino@kros.test")]
    [InlineData("niekto.iny@kros.test")]
    [InlineData("postmantest@kros.test")]
    public void BeTestEmail(string email)
    {
        EmailAddress emailAddress = email;

        emailAddress.IsTestingAddress.Should().BeTrue();
    }

    [Theory]
    [InlineData("mino@gmail.test")]
    [InlineData("niekto.iny@kros.com")]
    [InlineData("niekto.iny@inykros.test")]
    public void NoBeTestEmail(string email)
    {
        EmailAddress emailAddress = email;

        emailAddress.IsTestingAddress.Should().BeFalse();
    }
}
