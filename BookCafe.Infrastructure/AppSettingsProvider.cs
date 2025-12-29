using BookCafe.Application.Interfaces.Infra;
using BookCafe.Infrastructure;
using Microsoft.Extensions.Options;

public class AppSettingsProvider : IAppSetting
{
    private readonly IOptionsMonitor<AppSetting> _options;

    public AppSettingsProvider(IOptionsMonitor<AppSetting> options)
    {
        _options = options;
    }

    public string DefaultConnection => _options.CurrentValue.ConnectionStrings.DefaultConnection;
    public string SecretKey => _options.CurrentValue.JwtSettings.SecretKey;
    public string Issuer => _options.CurrentValue.JwtSettings.Issuer;
    public string Audience => _options.CurrentValue.JwtSettings.Audience;
    public string AccessTokenMinutes => _options.CurrentValue.JwtSettings.AccessTokenMinutes;
    public string RefreshTokenDays => _options.CurrentValue.JwtSettings.RefreshTokenDays;
}