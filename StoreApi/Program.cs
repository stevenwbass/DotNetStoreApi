using Microsoft.OpenApi.Models;
using StoreData;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc("v1", new OpenApiInfo { Title = "Store API", Description = "Client, sales, and inventory management", Version = "v1" });
});

// builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//     .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,
//         options => builder.Configuration.Bind("JwtSettings", options))
//     .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme,
//         options => builder.Configuration.Bind("CookieSettings", options));

builder.Services.AddControllers();
builder.Services.RegisterDependencies(builder.Configuration);

var app = builder.Build();

// if (app.Environment.IsDevelopment())
// {
   app.UseSwagger();
   app.UseSwaggerUI(c =>
   {
      c.SwaggerEndpoint("/swagger/v1/swagger.json", "Store API V1");
   });
// }

app.MapControllers();

app.Run();

// Make the implicit Program class public so test projects can access it
public partial class Program { }