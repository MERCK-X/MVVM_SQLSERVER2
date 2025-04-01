using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MVVM_SQLSERVER2.ViewModels
{
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _title;

        [RelayCommand]
        protected virtual async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}