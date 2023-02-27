using CommunityToolkit.Maui;
using inWMSAndroid.Utilities.DI;
using Microsoft.Extensions.Logging;

namespace MauiApp1;

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
                    fonts.AddFont("Roboto-Medium.ttf", "RobotoMedium");
                    fonts.AddFont("Roboto-Bold.ttf");
                })
                .UseMauiCommunityToolkit();
        //DI
        DependencyInjectionInitializer.Initialize();
        DependencyInjectionManager.GetInstance().BuildContainer();
        return builder.Build();
    }
}
