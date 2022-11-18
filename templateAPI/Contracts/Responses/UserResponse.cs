namespace templateAPI.Domain.Contracts.Responses;

public class UserResponse
{
    public string Id { get; init; } = default!;
    public string Username { get; init; } = default!;
    public string EmailAddress { get; init; } = default!;
    public bool EmailAddressConfirmed { get; init; }
}