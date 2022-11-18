using templateAPI.Contracts.Responses;
using FastEndpoints;
using templateAPI.Endpoints.Auth;
using YamlDotNet.Core.Tokens;
using templateAPI.Domain.Contracts.Responses;

namespace templateAPI.Summaries;

public class SigninWithUsernameSummary : Summary<SigninWithUsernameEndpoint>
{
    public SigninWithUsernameSummary()
    {
        Summary = "Returns a token for logging user";
        Description = "Returns a token for logging user";
        Response<SigninResponse>(201, "Successfully found and returned the token");
        Response<ValidationFailureResponse>(400, "The user does not exist in the system");
    }
}
