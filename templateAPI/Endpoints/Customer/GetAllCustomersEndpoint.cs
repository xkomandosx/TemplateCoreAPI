using templateAPI.Contracts.Responses;
using templateAPI.Mapping;
using templateAPI.Services;
using FastEndpoints;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace templateAPI.Endpoints.Customer;

public class GetAllCustomersEndpoint : EndpointWithoutRequest<GetAllCustomersResponse>
{
    private readonly ICustomerService _customerService;

    public GetAllCustomersEndpoint(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    public override void Configure()
    {
        Get("/customers");
        AuthSchemes(JwtBearerDefaults.AuthenticationScheme);
    }

    public override async Task HandleAsync(CancellationToken ct)
    {
        var customers = await _customerService.GetAllAsync();
        var customersResponse = customers.ToCustomersResponse();
        await SendOkAsync(customersResponse, ct);
    }
}
