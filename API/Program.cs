using Master;
using Microsoft.AspNetCore.Mvc;
using Middleware;
using Middleware.BaseClass;
using System.Text.Json;
using System.Text.Json.Serialization;
using User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(opt =>
    {
        opt.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
        opt.JsonSerializerOptions.AllowTrailingCommas = true;
        opt.JsonSerializerOptions.WriteIndented = true;
        opt.JsonSerializerOptions.PropertyNamingPolicy = null;
        opt.JsonSerializerOptions.ReadCommentHandling = JsonCommentHandling.Skip;
        opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//DI Class Repository
builder.Services.RegisterUserDI();
builder.Services.RegisterMasterDI();
builder.Services.MiddlewareDI();

builder.Services.Configure<ApiBehaviorOptions>(opt =>
{
    BaseResponse resp = new();
    opt.InvalidModelStateResponseFactory = context =>
    {
        var errorCollection = new Dictionary<string, object>();
        foreach (var item in context.ModelState)
        {
            errorCollection.Add(item.Key, item.Value.Errors.Select(x => x.ErrorMessage));
        }
        resp.errorProperty = errorCollection;
        return new BadRequestObjectResult(resp);
    };
});

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
