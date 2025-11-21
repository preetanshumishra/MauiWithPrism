using MauiWithPrism.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MauiWithPrism
{
	public static class MauiProgram
	{
		public static IServiceProvider ServiceProvider { get; private set; } = null!;

		public static MauiApp CreateMauiApp()
		{
			var services = new ServiceCollection();

			services.AddSingleton<AppShell>();
			services.AddSingleton<MainPage>();
			services.AddSingleton<MainViewModel>();

			var serviceProvider = services.BuildServiceProvider();
			ServiceProvider = serviceProvider;

			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			return builder.Build();
		}
	}
}