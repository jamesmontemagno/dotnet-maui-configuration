using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using System.Reflection;

namespace MauiApp27;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddTransient<MainPage>();

        var a = Assembly.GetExecutingAssembly();
        using var stream = a.GetManifestResourceStream("MauiApp27.appsettings.json");

        var config = new ConfigurationBuilder()
            .AddJsonStream(stream)
            .AddEnvironmentVariables()
            .Build();


        builder.Configuration.AddConfiguration(config);

        var app = builder.Build();


        Services = app.Services;

        return app;
    }

    public static IServiceProvider Services { get; private set; }
}


public class Settings
{
    public int KeyOne { get; set; }
    public bool KeyTwo { get; set; }
    public NestedSettings KeyThree { get; set; } = null!;
}

public class NestedSettings
{
    public string Message { get; set; } = null!;
}