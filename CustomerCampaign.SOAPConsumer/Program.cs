using CustomerCampaign.Data.Interfaces;
using CustomerCampaign.Data.Repositories;
using CustomerCampaign.Repositories.Models;
using CustomerCampaign.Services.Interfaces;
using CustomerCampaign.Services.Services;
using CustomerCampaign.SOAPConsumer.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add db connection
builder.Services.AddDbContext<CustomerCampaignDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=CustomerCampaign;TrustServerCertificate=True;"));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<CustomerFactory>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
