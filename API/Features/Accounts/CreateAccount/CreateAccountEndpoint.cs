using System;
using API.Models;
using API.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static API.Features.Accounts.CreateAccount.CreateAccountDtos;

namespace API.Features.Accounts.CreateAccount;

public static class CreateAccountEndpoint
{
    public static void MapCreateAccount(this IEndpointRouteBuilder app)
    {
        app.MapPost("/register", async (UserManager<AppUser> userManager,
                                        [FromForm] CreateAccountRequest request,
                                        HttpContext context) =>
        {
            var userFromDb = await userManager.FindByEmailAsync(request.Email);

            if (userFromDb is not null)
                return Results.BadRequest(Response<string>.Failure("User already exist."));

            AppUser user = new() { Email = request.Email, FullName = request.FullName, UserName = request.UserName };

            IdentityResult result = await userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return Results.BadRequest(Response<string>.Failure(
                    result.Errors.Select(x => x.Description).FirstOrDefault()!
                ));

            return Results.Ok(Response<string>.Success("", "Account created successfully"));
        })
        .DisableAntiforgery();
    }
}
