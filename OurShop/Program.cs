using Microsoft.EntityFrameworkCore;
using Repository;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddDbContext<AdoNetManageContext>(options => options.UseSqlServer("Data Source=srv2\\pupils;Initial Catalog = AdoNetManage;Integrated Security = True; Pooling = False"));



var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();
