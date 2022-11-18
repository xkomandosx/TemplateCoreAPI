using templateAPI.Contracts.Requests;
using templateAPI.Contracts.Responses;
using templateAPI.Mapping;
using templateAPI.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace templateAPI.Endpoints.Customer;

public class CreateCustomerEndpoint : Endpoint<CreateCustomerRequest, CustomerResponse>
{
    private readonly ICustomerService _customerService;

    public CreateCustomerEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }
    public override void Configure()
    {
        Post("/customers");
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(CreateCustomerRequest req, CancellationToken ct)
    {
        var customer = req.ToCustomer();

        await _customerService.CreateAsync(customer);

        var customerResponse = customer.ToCustomerResponse();
        await SendCreatedAtAsync<GetCustomerEndpoint>(
            new { Id = customer.Id.Value }, customerResponse, generateAbsoluteUrl: true, cancellation: ct);
    }
}
