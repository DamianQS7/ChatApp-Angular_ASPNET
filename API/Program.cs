using API.Extensions;
using API.Features.Accounts;
using API.Shared.Configuration;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddOpenApi();
    builder.Services.AddDatabase();
    builder.Services.AddIdentityManagement();
    builder.Services.AddChatAppAuthentication(builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>());
    builder.Services.AddAuthorization();
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
    }

    app.UseHttpsRedirection();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapAccounts();

    app.Run();
}

