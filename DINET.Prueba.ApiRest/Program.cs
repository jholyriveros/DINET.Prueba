using DINET.Prueba.Repositories.Implementaciones;
using DINET.Prueba.Repositories.Interfaces;
using DINET.Prueba.Services.Implementaciones;
using DINET.Prueba.Services.Interfaces;
using DINET.Prueba.Services.Profiles;

var builder = WebApplication.CreateBuilder(args);

// AutoMapper
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<DINETWebProfile>();
});

#region[Inyectar dependencias]
builder.Services.AddTransient<IMovInventarioRepository, MovInventarioRepository>();
builder.Services.AddTransient<IMovInventarioService, MovInventarioService>();
#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
    app.UseSwagger();
    app.UseSwaggerUI();
//}

//app.UseAuthorization();
app.MapControllers();
app.Run();
