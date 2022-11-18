using templateAPI.Contracts.Requests;
using templateAPI.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace templateAPI.Endpoints.Customer;

public class DeleteCustomerEndpoint : Endpoint<DeleteCustomerRequest>
{
    private readonly ICustomerService _customerService;

    public DeleteCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public override void Configure()
    {
        Delete("/customers/{id:guid}");
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(DeleteCustomerRequest req, CancellationToken ct)
    {
        var deleted = await _customerService.DeleteAsync(req.Id);
        if (!deleted)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        await SendNoContentAsync(ct);
    }
}
