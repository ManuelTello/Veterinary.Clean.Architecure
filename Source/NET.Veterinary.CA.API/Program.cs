using NET.Veterinary.CA.Application;
using NET.Veterinary.CA.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration).AddApplication();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}else{}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();