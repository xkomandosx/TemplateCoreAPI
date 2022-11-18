using templateAPI.Contracts.Responses;
using templateAPI.Database;
using templateAPI.Repositories;
using templateAPI.Services;
using templateAPI.Validation;
using FastEndpoints;
using FastEndpoints.Swagger;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using NSwag;

var builder = WebApplication.CreateBuilder(args);
var config = builder.Configuration;

builder.Services.AddFastEndpoints();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration.GetValue<string>("JWT:Issuer"),
            ValidateAudience = true,
            ValidAudience = builder.Configuration.GetValue<string>("JWT:Audience"),
            ValidateLifetime = true,
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWT:Key"))),
            ValidateIssuerSigningKey = true,
            ClockSkew = TimeSpan.Zero,
        };
    });

builder.Services.AddSwaggerDoc(s =>
{
    s.AddAuth(JwtBearerDefaults.AuthenticationScheme, new OpenApiSecurityScheme()
    {
        In = OpenApiSecurityApiKeyLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = OpenApiSecuritySchemeType.ApiKey,
    });
});

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                       ?? builder.Configuration.GetValue<string>("Database:ConnectionString");

builder.Services.AddSingleton<IDbConnectionFactory>(_ =>
    new PostgresConnectionFactory(connectionString));
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IAuthService, AuthService>();
builder.Services.AddSingleton<IEncryptionService, EncryptionService>();

builder.Services.AddSingleton<ICustomerRepository, CustomerRepository>();
builder.Services.AddSingleton<ICustomerService, CustomerService>();

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();


var app = builder.Build();

app.UseMiddleware<ValidationExceptionMiddleware>();

app.UseFastEndpoints(x =>
{
    x.ErrorResponseBuilder = (failures, _) =>
    {
        return new ValidationFailureResponse
        {
            Errors = failures.Select(y => y.ErrorMessage).ToList()
        };
    };
});

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi3(x => x.ConfigureDefaults());
}

app.Run();
