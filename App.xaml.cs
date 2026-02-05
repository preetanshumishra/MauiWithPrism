using MauiWithPrism.ViewModels;
using Prism.Ioc;

namespace MauiWithPrism
{
	public partial class App : global::Prism.Maui.PrismApplication
	{
		public App() : base()
		{
		}

		protected override void RegisterTypes(IContainerRegistry containerRegistry)
		{
			// Register pages and ViewModels for Prism navigation
			containerRegistry.RegisterForNavigation<AppShell>();
			containerRegistry.RegisterForNavigation<MainPage, MainViewModel>();
		}

		protected override void OnInitialized()
		{
			InitializeComponent();

			// Navigate to main page using Prism navigation service
			NavigationService.NavigateAsync("MainPage");
		}

		protected override Window CreateWindow(IActivationState activationState)
		{
			return base.CreateWindow(activationState);
		}
	}
}