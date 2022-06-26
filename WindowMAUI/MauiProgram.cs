using Microsoft.Maui.LifecycleEvents;
using WindowsMAUI.Common;

namespace WindowMAUI;

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
			})
            .ConfigureLifecycleEvents(events =>
            {
#if WINDOWS
				events.AddWindows(windows =>
				{
					windows.OnActivated((window, args) => GlobalConfig.Init());
					windows.OnClosed((window, args) => GlobalConfig.SaveWindowLocation());
					windows.OnWindowCreated(window => window.SizeChanged += (e, args) => GlobalConfig.SaveWindowSize());
					windows.OnPlatformMessage((app, args) =>
					{
						if (args.MessageId == Convert.ToUInt32(3))
						{
							GlobalConfig.SaveWindowLocation();
						}

					});
				});
#endif
            });

        return builder.Build();
	}
}
