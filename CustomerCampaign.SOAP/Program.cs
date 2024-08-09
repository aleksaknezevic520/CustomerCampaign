using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Data.Repositories;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Services;
using Microsoft.EntityFrameworkCore;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSoapCore();

// Add db connection
builder.Services.AddDbContext<CustomerCampaignDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CustomerCampaign;TrustServerCertificate=True;",
        b => b.MigrationsAssembly("CustomerCampaign.SOAP")));

// Add services
builder.Services.AddScoped<IRewardService, RewardService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseSoapEndpoint<IRewardService>("/RewardService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<ICustomerService>("/CustomerService.asmx", new SoapEncoderOptions());

app.Run();
