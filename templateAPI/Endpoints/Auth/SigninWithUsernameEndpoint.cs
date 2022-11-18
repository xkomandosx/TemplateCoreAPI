using FastEndpoints;
using templateAPI.Domain;
using templateAPI.Domain.Contracts.Requests;
using templateAPI.Domain.Contracts.Responses;
using templateAPI.Mapping;
using templateAPI.Repositories;
using templateAPI.Services;

namespace templateAPI.Endpoints.Auth;

public class SigninWithUsernameEndpoint : Endpoint<SigninWithUsernameRequest, SigninResponse>
{
    private readonly IAuthService _authService;

    public SigninWithUsernameEndpoint(IAuthService authService)
    {
        _authService = authService;
    }

    public override void Configure()
    {
        Post("/auth/signin/username");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SigninWithUsernameRequest req, CancellationToken ct)
    {
        var response = await _authService.SigninAsync(req);
        await SendAsync(response, 200, ct);
    }
}