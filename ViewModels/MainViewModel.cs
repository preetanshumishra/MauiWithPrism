using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiWithPrism.ViewModels
{
	public partial class MainViewModel : BaseViewModel
	{
		[ObservableProperty]
		private string _message = "Welcome to MAUI with MVVM!";
		
		public MainViewModel()
		{
			Title = "Main Page";
		}
		
		[RelayCommand]
		private void UpdateMessage()
		{
			Message = $"Updated at {DateTime.Now:HH:mm:ss}";
		}
	}
}