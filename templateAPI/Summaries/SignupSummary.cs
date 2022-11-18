using templateAPI.Contracts.Responses;
using FastEndpoints;
using templateAPI.Endpoints.Auth;
using YamlDotNet.Core.Tokens;
using templateAPI.Domain.Contracts.Responses;

namespace templateAPI.Summaries;

public class SignupSummary : Summary<SignupEndpoint>
{
    public SignupSummary()
    {
        Summary = "Returns the token for the user that is being created";
        Description = "Returns the token for the user that is being created";
        Response<SignupResponse>(201, "Successfully found and returned the token");
        Response<ValidationFailureResponse>(400, "The user does not exist in the system");
    }
}
