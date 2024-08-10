using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Data.Repositories;
using CustomerCampaign.Infrastructure.Settings;
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
    options.UseLazyLoadingProxies()
    .UseSqlServer(DatabaseSettings.Connection_String,
        b => b.MigrationsAssembly(DatabaseSettings.Migrations_Assembly)));

// Services
builder.Services.AddScoped<IRewardService, RewardService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IReportService, ReportService>();

// Repositories
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IAgentRepository, AgentRepository>();
builder.Services.AddScoped<IRewardRepository, RewardRepository>();
builder.Services.AddScoped<IPurchaseRepository, PurchaseRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseSoapEndpoint<IRewardService>("/RewardService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<ICustomerService>("/CustomerService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<IAgentService>("/AgentService.asmx", new SoapEncoderOptions());
app.UseSoapEndpoint<IReportService>("/ReportService.asmx", new SoapEncoderOptions());

app.Run();
