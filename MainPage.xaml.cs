using MauiWithPrism.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace MauiWithPrism
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = MauiProgram.ServiceProvider.GetRequiredService<MainViewModel>();
		}
	}
}