using System.Net.Mail;

namespace Samples.UnitTestingWorkshop.Lib;

/// <summary>
/// Value objec which represent email address.
/// </summary>
public record EmailAddress
{
    /// <summary>
    /// Gets the email address.
    /// </summary>
    public string Value { get; } = default!;

    /// <summary>
    /// Ctor.
    /// </summary>
    /// <param name="email">Email address.</param>
    /// <exception cref="BusinessRuleValidationException">When is not well formatted.</exception>
    public EmailAddress(string email)
    {
        Validate(email);

        Value = email;
    }

    private EmailAddress()
    {
        Value = string.Empty;
    }

    private static void Validate(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new InvalidOperationException("Email address cannot be empty.");
        }

        try
        {
            var mail = new MailAddress(email);
        }
        catch (FormatException e)
        {
            throw new InvalidOperationException("Email address is not well formatted.", e);
        }
    }

    /// <summary>
    /// Performs an implicit conversion from <see cref="string"/> to <see cref="EmailAddress"/>.
    /// </summary>
    /// <param name="email">The email.</param>
    public static implicit operator EmailAddress(string email) => new EmailAddress(email);

    /// <summary>
    /// Performs an implicit conversion from <see cref="EmailAddress"/> to <see cref="string"/>.
    /// </summary>
    /// <param name="email">The email.</param>
    public static implicit operator string(EmailAddress email) => email.Value;

    /// <summary>
    /// Is testing address?
    /// </summary>
    public bool IsTestingAddress => Value!.EndsWith("@kros.test");

    /// <summary>
    /// The empty email address.
    /// </summary>
    public static EmailAddress Empty = new EmailAddress();

    /// <summary>
    /// Converts to string.
    /// </summary>
    public override string ToString() => Value;
}