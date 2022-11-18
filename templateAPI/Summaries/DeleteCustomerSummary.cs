using FastEndpoints;
using templateAPI.Endpoints.Customer;

namespace templateAPI.Summaries;

public class DeleteCustomerSummary : Summary<DeleteCustomerEndpoint>
{
    public DeleteCustomerSummary()
    {
        Summary = "Deleted a customer the system";
        Description = "Deleted a customer the system";
        Response(204, "The customer was deleted successfully");
        Response(404, "The customer was not found in the system");
    }
}
