using templateAPI.Contracts.Responses;
using FastEndpoints;
using templateAPI.Endpoints.Customer;

namespace templateAPI.Summaries;

public class GetAllCustomersSummary : Summary<GetAllCustomersEndpoint>
{
    public GetAllCustomersSummary()
    {
        Summary = "Returns all the customers in the system";
        Description = "Returns all the customers in the system";
        Response<GetAllCustomersResponse>(200, "All customers in the system are returned");
    }
}
