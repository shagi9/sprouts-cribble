using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SproutScribble.Api.Extensions;
using SproutScribble.Biz.DatabaseContext;
using SproutScribble.Biz.Users;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.ConfigureCors();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);

builder.Services.AddDbContext<SproutScribbleDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

builder.Services.AddIdentityCore<UserEntity>()
    .AddEntityFrameworkStores<SproutScribbleDbContext>()
    .AddApiEndpoints();

var app = builder.Build();

app.MapIdentityApi<UserEntity>();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseStaticFiles();
app.UseCors("CorsPolicy");

app.MapGet("/weathercasr", () => "Hello World!")
.WithName("GetWeatherForecast")
.WithOpenApi();


app.Run();
