using System.Drawing;
using System.Security.Claims;
using System.Text.RegularExpressions;
using FastEndpoints;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.ObjectPool;
using NSwag.Annotations;
using templateAPI.Domain.Contracts.Responses;
using templateAPI.Mapping;
using templateAPI.Repositories;

namespace templateAPI.Endpoints.Auth;

public class GetUserEndpoint : EndpointWithoutRequest<UserResponse>
{
    private readonly IUserRepository _userRepository;

    public GetUserEndpoint(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override void Configure()
    {
        Get("/auth/me");
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var id = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        
        var user = await _userRepository.GetAsync(id);

        if (user is null)
        {
            await SendUnauthorizedAsync(ct);
            return;
        }
        
        await SendAsync(DomainToApiContractMapper.ToUserResponse(user), 200, ct);
    }
}