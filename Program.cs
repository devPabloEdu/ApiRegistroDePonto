using Microsoft.EntityFrameworkCore;
using RegistroDePontosApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<RegistroContext>(opt => opt.UseInMemoryDatabase("RegistrosDePonto"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Criar um funcionário automaticamente ao iniciar a aplicação
//adicionei só de teste enquanto desenvolvia a aplicação
using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<RegistroContext>();

    // Adicione um funcionário com um ID inicial
    if (!context.RegistroPonto.Any())
    {
        context.RegistroPonto.Add(new RegistroPonto { Id = 1 });
        context.SaveChanges();
    }
}



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
