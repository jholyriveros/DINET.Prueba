using DINET.Prueba.Repositories.Implementaciones.Acceso;
using DINET.Prueba.Repositories.Implementaciones.Inventario;
using DINET.Prueba.Repositories.Interfaces.Acceso;
using DINET.Prueba.Repositories.Interfaces.Inventario;
using DINET.Prueba.Services.Implementaciones.Acceso;
using DINET.Prueba.Services.Implementaciones.Inventario;
using DINET.Prueba.Services.Interfaces.Acceso;
using DINET.Prueba.Services.Interfaces.Inventario;
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

builder.Services.AddTransient<IAccesoRepository, AccesoRepository>();
builder.Services.AddTransient<IAccesoService, AccesoService>();
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
