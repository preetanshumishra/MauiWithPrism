namespace MauiWithPrism
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			return MauiApp.CreateBuilder()
				.UseMauiApp<App>()
				.UsePrism()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				})
				.Build();
		}
	}
}