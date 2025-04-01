using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MVVM_SQLSERVER2.Models;
using MVVM_SQLSERVER2.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_SQLSERVER2.ViewModels.Main
{
    // UsersViewModel.cs
    public partial class UsersViewModel : BaseViewModel
    {
        private readonly IAuthService _authService;

        [ObservableProperty]
        private List<User> _users;

        public UsersViewModel(IAuthService authService)
        {
            _authService = authService;
            LoadUsersCommand.Execute(null);
        }

        [RelayCommand]
        private async Task LoadUsers()
        {
            IsBusy = true;
            Users = await _authService.GetAllUsersAsync();
            IsBusy = false;
        }

        [RelayCommand]
        private async Task DeleteUser(int id)
        {
            if (await _authService.DeleteUserAsync(id))
                await LoadUsers();
        }
    }
}
