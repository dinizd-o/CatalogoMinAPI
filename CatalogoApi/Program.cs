using CatalogoApi.ApiEndpoints;
using CatalogoApi.AppServiceExtensions;
using CatalogoApi.Context;
using CatalogoApi.Models;
using CatalogoApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.AddApiSwagger();
builder.AddPersistence();
builder.Services.AddCors();
builder.AddAuthenticationJwt();


var app = builder.Build();

app.MapAutenticacaoEndpoints();

app.MapCategoriasEndpoints();

app.MapProdutosEndpoints();

var environment = app.Environment;

app.UseExceptionHandler(environment)
    .UseSwaggerMiddleWare()
    .UseAppCors();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
