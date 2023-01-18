using AutoFixture;
using AutoFixture.Xunit2;
using Samples.UnitTestingWorkshop.Lib;

namespace Sample.UnitTestingWorkshop.Lib.Tests;

public class EmailAddressShould
{
    [Theory]
    [MemberData(nameof(GetTestEmails))]
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
    [InlineData("foo.foo")]
    [InlineData("@foo.foo")]
    [MemberData(nameof(GetStrings))]
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

    public static IEnumerable<object[]> GetTestEmails()
        => new AutoFaker<Email>()
            .UseSeed(1)
            .RuleFor(x => x.Value, f => f.Internet.Email())
            .Generate(20)
            .Select(x => new object[] { x.Value });

    public static IEnumerable<object[]> GetStrings()
        => new AutoFaker<string>()
            .UseSeed(1)
            .Generate(20)
            .Select(s => new object[] { s });

    record Email(string Value);
}
