using LabSoftwareLicense.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<LicenseDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<LabSoftwareLicense.Repository.LicenseRepository>();

// ✅ Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "License API",
        Version = "v1"
    });
});

var app = builder.Build();

// Enable Swagger only in Development

    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "License API V1");
        c.RoutePrefix = string.Empty; // Makes Swagger UI load at root URL
    });


app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
