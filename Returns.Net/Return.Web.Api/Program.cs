using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Return.Web.Api;
using Return.Web.Api.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddOptions<DatabaseOptions>(DatabaseOptions.SectionName)
    .ValidateOnStart(); //add options validation

builder.Services
    .AddLogging(logging => 
        logging.ClearProviders().AddSimpleConsole());

builder.Services
    .AddReturnsDbContextFactory()
    .AddMapsterProfiles()
    .AddReturnsService();

builder.Services.AddOpenApi();
var app = builder.Build();

if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.Run();