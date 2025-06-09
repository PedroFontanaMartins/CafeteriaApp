using CafeteriaApi;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// CORS liberado para tudo (apenas para testes!)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

// Habilita logs detalhados do EF Core para ajudar no debug
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlite("Data Source=banco.db");
    options.EnableSensitiveDataLogging();
    options.LogTo(Console.WriteLine);
});

var app = builder.Build();

// Cria o banco e aplica migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();

    try
    {
        db.Database.Migrate();  // Tenta aplicar as migrations
    }
    catch (Exception ex)
    {
        Console.WriteLine("Erro ao aplicar migrations: " + ex.Message);
        Console.WriteLine("Tentando criar banco sem migrations...");
        db.Database.EnsureCreated(); // Tenta criar o banco direto, sem migrations (teste)
    }
}

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Cafeteria API V1");
    c.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors("AllowAll"); // <--- aqui

app.UseAuthorization();

app.MapControllers();

app.Run();
