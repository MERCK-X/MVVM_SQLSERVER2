using Microsoft.Extensions.Logging;
using MVVM_SQLSERVER2.Services;
using MVVM_SQLSERVER.ViewModels.Auth;
using MVVM_SQLSERVER.ViewModels.Main;
using MVVM_SQLSERVER.Views.Auth;
using MVVM_SQLSERVER.Views.Main;
using MVVM_SQLSERVER2.Data;
using MVVM_SQLSERVER2.Services.Interfaces;
using MVVM_SQLSERVER2.ViewModels.Auth;

namespace MVVM_SQLSERVER;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular"));

        // Database
        builder.Services.AddDbContext<LocalDbContext>();

        // Services
        builder.Services.AddSingleton<IAuthService, AuthService>();

        // ViewModels
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<RegisterViewModel>();
        builder.Services.AddTransient<UsersViewModel>();

        // Views
        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<RegisterPage>();
        builder.Services.AddTransient<UsersPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
