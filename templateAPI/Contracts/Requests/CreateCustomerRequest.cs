namespace templateAPI.Contracts.Requests;

public class LoginRequest
{
    public string Username { get; init; } = default!;

    public string Password { get; init; } = default!;

}
