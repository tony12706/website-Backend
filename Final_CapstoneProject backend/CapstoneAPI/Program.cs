using CapstoneAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using CapstoneAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
<<<<<<< HEAD

builder.Services.AddDbContext<CapstoneAPIDbContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
builder.Services.AddCors(c => c.AddPolicy("CapstoneProject", c => c.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));
=======
builder.Services.AddDbContext<CapstoneAPIDbContext>(x =>
x.UseSqlServer(builder.Configuration.GetConnectionString("Conn")));
builder.Services.AddCors(c => c.AddPolicy("CapstoneProject", c => c.AllowAnyMethod().AllowAnyOrigin().AllowAnyHeader()));
builder.Services.AddScoped<IAuthenticate, AuthenticateImpl>();
builder.Services.AddScoped<ICustomer, CustomerImpl>();
builder.Services.AddScoped<ISeller, SellerImpl>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


>>>>>>> 184c10a3830e97552c06315e7d5008be44f13996
builder.Services.AddEndpointsApiExplorer();

// Configure the HTTP request pipeline.
<<<<<<< HEAD
builder.Services.AddScoped<IAuthenticate, AuthenticateImpl>();
builder.Services.AddScoped<ICustomer, CustomerImpl>();
builder.Services.AddScoped<ISeller, SellerImpl>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
=======

>>>>>>> 184c10a3830e97552c06315e7d5008be44f13996

app.UseAuthorization();
app.UseRouting();
app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapControllers();
app.Run();