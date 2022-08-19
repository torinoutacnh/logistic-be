using API.Models.Response;
using API.SignalR;
using Autofac.Core;
using FU.Domain.Base;
using FU.Domain.Models;
using FU.Infras.Application;
using FU.Infras.Loging;
using FU.Repository.Base;
using FU.Repository.DbStore;
using FU.Repository.Extension;
using FU.Service.Extension;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSystemSetting(builder.Configuration.GetSection("SystemHelper").Get<SystemHelperModel>());
builder.Services.AddCustomLog(SystemHelper.Setting.SeriLogLevel, SystemHelper.Setting.SeriLogInterval);

// Config signalr log
if (builder.Environment.IsDevelopment())
{
    builder.Logging.AddFilter("Microsoft.AspNetCore.SignalR", LogLevel.Debug);
    builder.Logging.AddFilter("Microsoft.AspNetCore.Http.Connections", LogLevel.Debug);
}

// Add services to the container.
builder.Services.AddControllers()
    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve); ;
builder.Services.AddSignalR();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Some API v1", Version = "v1" });
    // here some other configurations maybe...
    options.AddSignalRSwaggerGen();
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
builder.Services.AddHealthChecks();
builder.Services.AddDataProtection();

// Register db context, unit of work
builder.Services.AddDbContext<Store>();

// Register repositories
builder.Services.AddRepositories();
// Register services
builder.Services.AddDomainServices();
builder.Services.AddServices();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSystemSetting();
app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.UseAuthentication();
app.MapHealthChecks("health");

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();

    // Signalr endpoint
    endpoints.MapHub<NotifyHub>("/signalr", option =>
    {
    });
});


// Exception middleware
app.UseExceptionHandler((request) =>
{
    request.Run(async context =>
    {
        var exceptionHandlerPathFeature =
                context.Features.Get<IExceptionHandlerPathFeature>();
        if(exceptionHandlerPathFeature != null)
        {
            if (exceptionHandlerPathFeature.Error is ArgumentNullException
            || exceptionHandlerPathFeature.Error is ArgumentException) {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsJsonAsync(new ErrorResponse(exceptionHandlerPathFeature.Error.Message));
                await context.Response.StartAsync();
            }else if (exceptionHandlerPathFeature.Error is DomainException){
                context.Response.StatusCode = (exceptionHandlerPathFeature.Error as DomainException).Code;
                await context.Response.WriteAsJsonAsync(new ErrorResponse(exceptionHandlerPathFeature.Error.Message));
                await context.Response.StartAsync();
            }else{
                await context.Response.WriteAsync(exceptionHandlerPathFeature.Error.Message);
            }
        }

    });
});

app.Run();
