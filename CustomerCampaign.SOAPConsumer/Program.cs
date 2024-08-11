using CustomerCampaign.SOAPConsumer.Factories;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Factories
builder.Services.AddScoped<CustomerFactory>();
builder.Services.AddScoped<AgentFactory>();
builder.Services.AddScoped<RewardFactory>();
builder.Services.AddScoped<ReportFactory>();
builder.Services.AddScoped<AuthenticationFactory>();

// External services
builder.Services.AddScoped<AuthenticationService.AuthenticationServiceClient>();
builder.Services.AddScoped<CustomerService.CustomerServiceClient>();
builder.Services.AddScoped<AgentService.AgentServiceClient>();
builder.Services.AddScoped<RewardService.RewardServiceClient>();
builder.Services.AddScoped<ReportService.ReportServiceClient>();

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
