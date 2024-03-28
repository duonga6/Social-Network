using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using SocialNetwork.API.Infrastructure.Extensions;
using SocialNetwork.API.Infrastructure.SignalR;
using SocialNetwork.Business;
using SocialNetwork.DataAccess;
using SocialNetwork.DataAccess.Context;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();


// Add services to the container.

builder.Services.AddCors(options =>
{

    options.AddPolicy("Cors", policy =>
    {
        policy.WithOrigins("http://localhost:8080").AllowAnyHeader().AllowAnyMethod().AllowCredentials();
    });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Social Network API",
        Description = "An ASP.NET Core Web API",
    });

    List<string> xmlFiles = Directory.GetFiles(AppContext.BaseDirectory, "*.xml", SearchOption.TopDirectoryOnly).ToList();
    xmlFiles.ForEach(xmlFile => options.IncludeXmlComments(xmlFile));

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Insert access token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
             new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
               Type = ReferenceType.SecurityScheme,
               Id = "Bearer"
            }
        }, new string[]{}
        }
    });

});

builder.Services.AddServicesDAL(builder.Configuration);
builder.Services.AddServicesBLL(builder.Configuration);
builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.RegistrationSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI(c =>
//    {
//        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Network API");
//    });
//}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Social Network API");
});

app.MapHub<CenterHub>("/hub");

app.UseCors("Cors");

app.UseStaticFiles();

//app.UseCustomExceptionMiddleware();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


using (var scopeService = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope())
{
    var _context = scopeService.ServiceProvider.GetService<AppDbContext>();
    if (_context != null && _context.Database.GetPendingMigrations().Any())
    {
        _context.Database.Migrate();
    }
}

app.Run();
