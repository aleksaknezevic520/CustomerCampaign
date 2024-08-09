using CustomerCampaign.Repositories.Models;
using CustomerCampaign.Services.Interfaces;
using CustomerCampaign.Services.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SoapCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSoapCore();

// Add db connection
builder.Services.AddDbContext<CustomerCampaignDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CustomerCampaign;TrustServerCertificate=True;",
        b => b.MigrationsAssembly("CustomerCampaign.SOAP")));
builder.Services.AddScoped<IRewardService, RewardService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseRouting();

app.UseSoapEndpoint<IRewardService>("/RewardService.asmx", new SoapEncoderOptions());

app.Run();
