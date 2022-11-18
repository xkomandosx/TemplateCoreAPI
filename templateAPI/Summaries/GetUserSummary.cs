using templateAPI.Contracts.Responses;
using FastEndpoints;
using templateAPI.Endpoints.Auth;
using YamlDotNet.Core.Tokens;
using templateAPI.Domain.Contracts.Responses;

namespace templateAPI.Summaries;

public class GetUserSummary : Summary<GetUserEndpoint>
{
    public GetUserSummary()
    {
        Summary = "Returns a current user data";
        Description = "Returns a current user data";
        Response<UserResponse>(201, "Successfully found and returned the user");
        Response<ValidationFailureResponse>(400, "The user does not exist in the system");
    }
}
