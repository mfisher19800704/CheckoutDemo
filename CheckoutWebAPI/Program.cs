using Checkout.Core.Interfaces;
using Microsoft.AspNetCore.Builder;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
   .AllowAnyMethod()
   .AllowAnyHeader()
   .SetIsOriginAllowed(origin => true)
   .AllowCredentials());

app.Run();