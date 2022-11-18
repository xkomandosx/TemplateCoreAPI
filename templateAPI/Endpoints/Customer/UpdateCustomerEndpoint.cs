using templateAPI.Contracts.Requests;
using templateAPI.Contracts.Responses;
using templateAPI.Mapping;
using templateAPI.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace templateAPI.Endpoints.Customer;

public class UpdateCustomerEndpoint : Endpoint<UpdateCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public UpdateCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public override void Configure()
    {
        Put("/customers/{id:guid}");
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(UpdateCustomerRequest req, CancellationToken ct)
    {
        var existingCustomer = await _customerService.GetAsync(req.Id);

        if (existingCustomer is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        var customer = req.ToCustomer();
        await _customerService.UpdateAsync(customer);

        var customerResponse = customer.ToCustomerResponse();
        await SendOkAsync(customerResponse, ct);
    }
}
