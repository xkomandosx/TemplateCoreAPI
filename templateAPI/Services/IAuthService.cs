using templateAPI.Domain.Contracts.Requests;
using templateAPI.Domain.Contracts.Responses;

namespace templateAPI.Services;

public interface IAuthService
{
    Task<SignupResponse> SignupAsync(SignupRequest request);
    Task<SigninResponse> SigninAsync(SigninWithUsernameRequest request);
    Task<SigninResponse> SigninAsync(SigninWithEmailRequest request);
}