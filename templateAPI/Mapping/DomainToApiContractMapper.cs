using templateAPI.Contracts.Responses;
using templateAPI.Domain;
using templateAPI.Domain.Contracts.Responses;

namespace templateAPI.Mapping;

public static class DomainToApiContractMapper
{
    public static CustomerResponse ToCustomerResponse(this Customer customer)
    {
        return new CustomerResponse
        {
            Id = customer.Id.Value,
            Email = customer.Email.Value,
            Username = customer.Username.Value,
            FullName = customer.FullName.Value,
            DateOfBirth = customer.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
        };
    }

    public static GetAllCustomersResponse ToCustomersResponse(this IEnumerable<Customer> customers)
    {
        return new GetAllCustomersResponse
        {
            Customers = customers.Select(x => new CustomerResponse
            {
                Id = x.Id.Value,
                Email = x.Email.Value,
                Username = x.Username.Value,
                FullName = x.FullName.Value,
                DateOfBirth = x.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
            })
        };
    }

    public static UserResponse ToUserResponse(this User user)
    {
        return new UserResponse()
        {
            Id = user.Id,
            EmailAddress = user.EmailAddress,
            Username = user.Username,
            EmailAddressConfirmed = user.EmailAddressConfirmed
        };
    }
}
