using Microsoft.Extensions.DependencyInjection;

namespace MauiWithPrism
{
	public partial class App
	{
		public App()
		{
			InitializeComponent();
		}

		protected override Window CreateWindow(IActivationState? activationState)
		{
			return new Window(MauiProgram.ServiceProvider.GetRequiredService<AppShell>());
		}
	}
}