using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Meteo.Services;
using Meteo.ViewModels;
using Meteo.Pages;

namespace Meteo;

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
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("fa-solid-900.ttf", "FontAwesome");
            });

		builder.ConfigureLifecycleEvents(lifecycle =>
		{
#if WINDOWS
			lifecycle.AddWindows(windows => windows.OnWindowCreated((del) => {
				del.ExtendsContentIntoTitleBar = true;
			}));
#endif
        });

		var services = builder.Services;

#if WINDOWS
		//services.AddSingleton<ITrayService, WinUI.>();
		//services.AddSingleton<INotificationService, WinIU.NotificationService>();

#elif MACCATALYST
		//services.AddSingleton<ITrayService, MacCatalyst.TrayService>();
		//services.AddSingleton<INotificationService, MacCatalyst.NotificationService>();

#endif

		services.AddSingleton<HomeViewModel>();
		services.AddSingleton<HomePage>();

		services.AddSingleton<FavoritesViewModel>();
		services.AddSingleton<FavoritesPage>();




#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
