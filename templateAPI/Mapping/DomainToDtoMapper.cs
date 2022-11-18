using templateAPI.Contracts.Data;
using templateAPI.Domain;

namespace templateAPI.Mapping;

public static class DomainToDtoMapper
{
    public static CustomerDto ToCustomerDto(this Customer customer)
    {
        return new CustomerDto
        {
            Id = customer.Id.Value.ToString(),
            Email = customer.Email.Value,
            Username = customer.Username.Value,
            FullName = customer.FullName.Value,
            DateOfBirth = customer.DateOfBirth.Value.ToDateTime(TimeOnly.MinValue)
        };
    }
}
