using FastEndpoints;
using templateAPI.Domain;
using templateAPI.Domain.Contracts.Requests;
using templateAPI.Domain.Contracts.Responses;
using templateAPI.Mapping;
using templateAPI.Repositories;
using templateAPI.Services;

namespace templateAPI.Endpoints.Auth;

public class SignupEndpoint : Endpoint<SignupRequest, SignupResponse>
{
    private readonly IAuthService _authService;

    public SignupEndpoint(IAuthService authService)
    {
        _authService = authService;
    }

    public override void Configure()
    {
        Post("/auth/signup");
        AllowAnonymous();
    }

    public override async Task HandleAsync(SignupRequest req, CancellationToken ct)
    {
        var response = await _authService.SignupAsync(req);
        await SendAsync(response, 200, ct);
    }
}