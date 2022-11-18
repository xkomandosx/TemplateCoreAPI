using templateAPI.Contracts.Requests;
using templateAPI.Domain;
using templateAPI.Domain.Common;
using templateAPI.Domain.Contracts.Requests;

namespace templateAPI.Mapping;

public static class ApiContractToDomainMapper
{
    public static Customer ToCustomer(this CreateCustomerRequest request)
    {
        return new Customer
        {
            Id = CustomerId.From(Guid.NewGuid()),
            Email = EmailAddress.From(request.Email),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }

    public static Customer ToCustomer(this UpdateCustomerRequest request)
    {
        return new Customer
        {
            Id = CustomerId.From(request.Id),
            Email = EmailAddress.From(request.Email),
            Username = Username.From(request.Username),
            FullName = FullName.From(request.FullName),
            DateOfBirth = DateOfBirth.From(DateOnly.FromDateTime(request.DateOfBirth))
        };
    }

    public static User ToUser(this SignupRequest request)
    {
        return new User()
        {
            Id = Guid.NewGuid().ToString(),
            EmailAddress = request.EmailAddress,
            Username = request.Username,
            PasswordHash = request.Password,
            EmailAddressConfirmed = false,
            CreatedAt = DateTime.Now,
            UpdatedAt = DateTime.Now
        };
    }
}
