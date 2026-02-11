using MauiWithPrism.ViewModels;

namespace MauiWithPrism
{
	public partial class MainPage
	{
		public MainPage(MainViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
		}
	}
}