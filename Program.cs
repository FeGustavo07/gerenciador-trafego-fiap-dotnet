using AutoMapper;
using fiap.gerenciador_trafego.Data.Repository.Semaforo;
using fiap.gerenciador_trafego.Models;
using fiap.gerenciador_trafego.Services.Semaforo;
using fiap.gerenciador_trafego.ViewModel.Semaforo;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using fiap.gerenciador_trafego.Data;
using fiap.gerenciador_trafego.Data.Repository.Clima;
using fiap.gerenciador_trafego.Services.Clima;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

#region Inicialização DB Oracle

var connectionString = builder.Configuration.GetConnectionString("DatabaseConnection");
builder.Services.AddDbContext<DatabaseContext>(
    options => options.UseOracle(connectionString).EnableSensitiveDataLogging()
);

#endregion

#region Repositorie
builder.Services.AddScoped<IClimaRepository, ClimaRepository>();
builder.Services.AddScoped<ISemaforoRepository, SemaforoRepository>();


#endregion

#region Services

builder.Services.AddScoped<IClimaService, ClimaService>();
builder.Services.AddScoped<ISemaforoService, SemaforoService>();

#endregion

#region AutoMapper

var mapperConfig = new AutoMapper.MapperConfiguration(c =>
    {
        c.AllowNullCollections = true;
        c.AllowNullDestinationValues = true;

        c.CreateMap<SemaforoCreateViewModel, SemaforoModel>();
        c.CreateMap<SemaforoUpdateViewModel, SemaforoModel>();
        c.CreateMap<SemaforoGetViewlModel, SemaforoModel>();
        c.CreateMap<SemaforoModel, SemaforoCreateViewModel>();
        c.CreateMap<SemaforoModel, SemaforoUpdateViewModel>();
        c.CreateMap<SemaforoModel, SemaforoGetViewlModel>();
        
        c.CreateMap<ClimaCreateViewModel, ClimaModel>();
        c.CreateMap<ClimaUpdateViewModel, ClimaModel>();
        c.CreateMap<ClimaGetViewlModel, ClimaModel>();
        c.CreateMap<ClimaModel, ClimaCreateViewModel>();
        c.CreateMap<ClimaModel, ClimaUpdateViewModel>();
        c.CreateMap<ClimaModel, ClimaGetViewlModel>();
    }
);

IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

#endregion

#region Auth

// builder.Services.AddAuthentication(options =>
// {
//     options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//     options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
// })
//     .AddJwtBearer(options =>
//     {
//         options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
//         {
//             ValidateIssuerSigningKey = true,
//             IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("f57fd9bbe041d379720eec80199cee4ec2d9a7a7800f486baec2711de5651208b6153bf41028d9d56ff3f1666df9803a83296a37eb8087aee70d313004345e0c32d91784a46dabef8cc88c13a180e0909798c796659d950266047dda28f95b20e14bf72032ea423f657393654f9e33af3e53e65110d5e6027bfdf55f5a5378\r\n")),
//             ValidateIssuer = false,
//             ValidateAudience = false
//         };
//     });

#endregion

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// app.UseAuthorization();

app.MapControllers();

app.Run();