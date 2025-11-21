using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiWithPrism.ViewModels
{
	public partial class MainViewModel : BaseViewModel
	{
		[ObservableProperty]
		private string _message = "Welcome to MAUI with Prism!";

		[ObservableProperty]
		private int _counter;

		public MainViewModel()
		{
			Title = "Main Page";
		}

		[RelayCommand]
		private void IncrementCounter()
		{
			Counter++;
			Message = Counter == 1
				? "Clicked 1 time"
				: $"Clicked {Counter} times";
		}
	}
}