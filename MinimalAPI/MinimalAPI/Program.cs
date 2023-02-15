using Microsoft.EntityFrameworkCore;
using MinimalAPI.Entities;
using System.Reflection.Metadata.Ecma335;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AssociatesDbContext>(options =>
options.UseSqlServer("BusinessConnection"));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/", () => "Hello everyone");
app.MapGet("/MinimalAPI/Entities", (AssociatesDbContext db) =>
{
    return db.SivaTrDetails.ToList();
});
app.MapPost("/MinimalAPI/Entities", (SivaTrDetail sivatrdetail,AssociatesDbContext db) =>
{
    db.SivaTrDetails.Add(sivatrdetail);
    db.SaveChanges();
    return Results.Ok(sivatrdetail);
});
app.MapPut("/update", (AssociatesDbContext db) =>
{
    return db.SivaTrDetails.ToList();

});
app.MapDelete("/MinimalAPI/Entities",(AssociatesDbContext db)=>
{
    return Results.Ok("call ");
});




app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}