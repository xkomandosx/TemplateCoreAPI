using templateAPI.Contracts.Requests;
using templateAPI.Contracts.Responses;
using templateAPI.Mapping;
using templateAPI.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace templateAPI.Endpoints.Customer;

public class GetCustomerEndpoint : Endpoint<GetCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public GetCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override void Configure()
    {
        Get("/customers/{id:guid}");
        Description(x => x.WithName("GetCustomer"));
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(GetCustomerRequest req, CancellationToken ct)
    {
        var customer = await _customerService.GetAsync(req.Id);

        if (customer is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var customerResponse = customer.ToCustomerResponse();
        await SendOkAsync(customerResponse, ct);
    }
}
