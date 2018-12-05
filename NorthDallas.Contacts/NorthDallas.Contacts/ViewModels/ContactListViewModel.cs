using MvvmHelpers;
using NorthDallas.Contacts.Models;
using NorthDallas.Contacts.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace NorthDallas.Contacts.ViewModels
{
    public class ContactListViewModel
        : BaseViewModel
    {
        private UserService _userService;
        public ContactListViewModel(UserService userService)
        {
            _userService = userService;
        }

        public ObservableRangeCollection<Result> Contacts { get; set; } =
            new ObservableRangeCollection<Result>();

        private ICommand _refreshCommand;
        public ICommand RefreshCommand =>
            _refreshCommand ?? (_refreshCommand = new Command(async () => await ExecuteRefreshCommandAsync()));

        private async Task ExecuteRefreshCommandAsync()
        {
            try
            {
                IsBusy = true;
                Contacts.Clear();
                Contacts.AddRange(await _userService.GetUsersAsync(100));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
