using CatalogoApi.Models;
using CatalogoApi.Services;
using Microsoft.AspNetCore.Authorization;
using System.Runtime.CompilerServices;

namespace CatalogoApi.ApiEndpoints
{
    public static class AutenticacaoEndpoints
    {
        public static void MapAutenticacaoEndpoints(this WebApplication app)
        {
            //endpoint para login

            app.MapPost("/login", [AllowAnonymous] (UserModel userModel, ITokenService tokenService) =>
            {
                if (userModel == null)
                {
                    return Results.BadRequest("Login Inv�lido");
                }
                if (userModel.Username == "macoratti" && userModel.Password == "numsey#123")
                {
                    var tokenString = tokenService.GerarToken(app.Configuration["Jwt:Key"],
                        app.Configuration["Jwt:Issuer"],
                        app.Configuration["Jwt:Audience"],
                        userModel);
                    return Results.Ok(new { token = tokenString });
                }
                else
                {
                    return Results.BadRequest("Login Inv�lido");
                }
            }).Produces(StatusCodes.Status400BadRequest)
                          .Produces(StatusCodes.Status200OK)
                          .WithName("Login")
                          .WithTags("Autenticacao");
        }
    }
}
