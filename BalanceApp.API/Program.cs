using BalanceApp.Application;
using BalanceApp.Infrastructure;
using BalanceApp.Infrastructure.Datas;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var port = Convert.ToInt32(Environment.GetEnvironmentVariable("PORT"));
// Add services to the container.

string defaultCors = "origins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(defaultCors,
                          builder =>
                          {
                              builder.WithOrigins("http://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowAnyOrigin();
                              builder.WithOrigins("https://balanceappclient.pages.dev")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod()
                                                  .AllowAnyOrigin();
                          });
});

builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateAudience = false,
        ValidateIssuer = false,
        ValidateLifetime = true,
    };
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    var scope = app.Services.CreateScope();
    var dataContext = scope.ServiceProvider.GetRequiredService<Context>();
    dataContext.Database.Migrate();
    app.UseHsts();
}

app.UseRouting();
app.UseCors(defaultCors);
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
