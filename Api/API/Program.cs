using API.Models.Response;
using FU.Domain.Base;
using FU.Repository.Base;
using FU.Repository.DbStore;
using FU.Repository.Extension;
using FU.Service.Extension;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); ;
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register db context, unit of work
builder.Services.AddDbContext<Store>();

// Register repositories
builder.Services.AddRepositories();
// Register services
builder.Services.AddServices();


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


// Exception middleware
app.UseExceptionHandler((request) =>
{
    request.Run(async context =>
    {
        var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error is ArgumentNullException
            || exceptionHandlerPathFeature?.Error is ArgumentException)
        {
            context.Response.StatusCode = 400;
            await context.Response.WriteAsJsonAsync(new ErrorResponse(exceptionHandlerPathFeature.Error.Message));
            await context.Response.StartAsync();
        }
        else
        {
            if(exceptionHandlerPathFeature!=null)
                await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.Message);
        }

    });
});

app.Run();
