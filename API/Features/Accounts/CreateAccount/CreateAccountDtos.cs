using System;
using API.Models;

namespace API.Features.Accounts.CreateAccount;

public static class CreateAccountDtos
{
    public record CreateAccountRequest(string FullName, string Email, string Password);
}
