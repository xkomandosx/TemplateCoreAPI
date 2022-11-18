using templateAPI.Domain.Common;

namespace templateAPI.Domain;

public class User
{
    public string Id { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string PasswordHash { get; set; } = default!;
    public string EmailAddress { get; set; } = default!;
    public bool EmailAddressConfirmed { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}