using BusinessLogic;
using DataEntities;
using DataEntities.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = builder.Configuration.GetConnectionString("ProductManagementDB");
builder.Services.AddDbContext<ProductManagementDbContext>(options => options.UseSqlServer(config));

builder.Services.AddScoped<ICategoryLogic,CategoryLogic >();
builder.Services.AddScoped<ICategoryRepo, CategoryRepo>();

builder.Services.AddScoped<IProductLogic, ProductLogic>();
builder.Services.AddScoped<IProductRepo, ProductRepo>();

var Allowpolicy = "AllowPolicy";
builder.Services.AddCors(options => options.AddPolicy(Allowpolicy, policy => { policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); }));

var app = builder.Build();
app.UseCors(Allowpolicy);

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
