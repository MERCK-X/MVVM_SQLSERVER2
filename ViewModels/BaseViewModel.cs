using CommunityToolkit.Mvvm.ComponentModel;

namespace MVVM_SQLSERVER2.ViewModels
{
    public partial class BaseViewModel : ObservableValidator // Cambia aquí
    {
        [ObservableProperty]
        private bool _isBusy;

        [ObservableProperty]
        private string _title;
    }
}