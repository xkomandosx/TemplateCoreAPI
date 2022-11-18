namespace templateAPI.Contracts.Responses;

public class LoginResponse
{
    public Guid Id { get; init; }

    public string Username { get; init; } = default!;

    public byte[] PasswordHash { get; init; } = default!;

    public byte[] PasswordSalt { get; init; } = default!;

}
