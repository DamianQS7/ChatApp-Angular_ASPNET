using System;
using API.Features.Accounts.CreateAccount;

namespace API.Features.Accounts;

public static class AccountsEndpoint
{
    public static void MapGames(this IEndpointRouteBuilder app)
    {
        RouteGroupBuilder group = app.MapGroup("/api/accounts");

        group.MapCreateAccount(); // accounts/register
    }
}
