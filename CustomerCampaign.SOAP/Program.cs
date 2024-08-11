using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Data.Repositories;
using CustomerCampaign.Infrastructure.Settings;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.SOAP.Interfaces;
using CustomerCampaign.SOAP.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SoapCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSoapCore();

// Auth ???
/*builder.Services.AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        options.SaveToken = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(AuthSettings.JwtKey)),
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });*/

// Add db connection
builder.Services.AddDbContext<CustomerCampaignDbContext>(options =>
    options.UseLazyLoadingProxies()
    .UseSqlServer(DatabaseSettings.Connection_String,
        b => b.MigrationsAssembly(DatabaseSettings.Migrations_Assembly)));

// Services
builder.Services.AddScoped<IAuthenticationService, AuthenticationService>();
builder.Services.AddScoped<IRewardService, RewardService>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<IAgentService, AgentService>();
builder.Services.AddScoped<IReportService, ReportService>();

// External services
builder.Services.AddScoped<SOAPDemo.SOAPDemoSoapClient>();

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
app.UseSoapEndpoint<IAuthenticationService>("/AuthenticationService.asmx", new SoapEncoderOptions());

app.Run();
