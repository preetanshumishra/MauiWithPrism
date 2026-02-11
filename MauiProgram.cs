using MauiWithPrism.ViewModels;

namespace MauiWithPrism
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			return MauiApp.CreateBuilder()
				.UseMauiApp<App>()
				.UsePrism(new DryIocContainerExtension(), prism =>
				{
					prism.RegisterTypes(containerRegistry =>
					{
						containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
					});
					prism.CreateWindow("MainPage");
				})
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				.Build();
		}
	}
}