using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_SQLSERVER2.Services;
using MVVM_SQLSERVER2.Services.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MVVM_SQLSERVER2.ViewModels.Auth
{
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        [Required(ErrorMessage = "Email es requerido")]
        [EmailAddress(ErrorMessage = "Formato inválido")]
        private string _email;

        [ObservableProperty]
        [Required(ErrorMessage = "Contraseña requerida")]
        [MinLength(6, ErrorMessage = "Mínimo 6 caracteres")]
        private string _password;

        public LoginViewModel(IAuthService authService)
        {
            _authService = authService;
        }

        [RelayCommand]
        private async Task Login()
        {
            ValidateAllProperties();
            if (HasErrors) return;

            try
            {
                IsBusy = true;
                var success = await _authService.LoginAsync(Email, Password);
                if (success)
                    await Shell.Current.GoToAsync("//Dashboard");
                else
                    await Shell.Current.DisplayAlert("Error", "Credenciales inválidas", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}