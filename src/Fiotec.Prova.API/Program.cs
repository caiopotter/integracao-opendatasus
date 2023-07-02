using Fiotec.Prova.API.Extensions;
using Fiotec.Prova.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.RegisterServices(builder.Configuration.GetConnectionString("DefaultConnection"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerDoc(builder.Configuration);

var app = builder.Build();

app.UseSwaggerDoc(builder.Configuration);
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
