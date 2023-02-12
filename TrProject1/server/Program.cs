using BusinessLogic;
using Microsoft.EntityFrameworkCore;
using Modules;
using TEntityApi.Entities;
using TEntityApi;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var config = builder.Configuration.GetConnectionString("AssociatesDb");
builder.Services.AddDbContext<AssociatesDbContext>(options => options.UseSqlServer(config));

builder.Services.AddScoped<IRepo<TEntityApi.Entities.SivaTrDetail>, TEntityApi.EFRepo>();
builder.Services.AddScoped<ISRepo<TEntityApi.Entities.SivaTrSkill>, TEntityApi.SEFRepo>();
builder.Services.AddScoped<IERepo<TEntityApi.Entities.SivaTrEducation>, TEntityApi.TEFRepo>();
builder.Services.AddScoped<ICTRepo<TEntityApi.Entities.SivaTrContact>, TEntityApi.CEFRepo>();
builder.Services.AddScoped<ICRepo<TEntityApi.Entities.SivaTrcompany>, TEntityApi.MEFRepo>();


//We are creating the instance of Logic by Dependency Inverison
builder.Services.AddScoped<ILogic, Logic>();
builder.Services.AddScoped<ISkillLogic,SLogic>();
builder.Services.AddScoped<IELogic, ELogic>();
builder.Services.AddScoped<ICTLogic,CTLogic>();
builder.Services.AddScoped<ICLogic, CLogic>();
builder.Services.AddScoped<Tvalidation, Tvalidation>();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.UseHttpsRedirection();


app.MapControllers();

app.Run();
