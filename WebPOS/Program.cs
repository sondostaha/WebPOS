using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebPOS.Controllers;
using WebPOS.Data;
using WebPOS.Extentions;
using WebPOS.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers().AddNewtonsoftJson(); ;
// Add services to the container.
builder.Services.AddDbContext<AppDbContext>
    (b => b.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("SqlConn")));
builder.Services.AddIdentity<Users, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
builder.Services.AddTransient(typeof(ISystemLogService), typeof(SystemLogContoller));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
builder.Services.AddCustoemSwagger();
builder.Services.AddCustomeJwtAuthentication(builder.Configuration);
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
