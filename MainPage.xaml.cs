using MauiWithPrism.ViewModels;

namespace MauiWithPrism
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
			BindingContext = new MainViewModel();
		}
	}
}