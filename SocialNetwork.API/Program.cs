using SocialNetwork.DataAccess;
using SocialNetwork.Business;
using SocialNetwork.API.Extensions;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(p => p.AddPolicy("Cors", build =>
{
    build.AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddServicesDAL(builder.Configuration);
builder.Services.AddServicesBLL(builder.Configuration);
builder.Services.ConfigureAuth(builder.Configuration);



var app = builder.Build();

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Cors");


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
