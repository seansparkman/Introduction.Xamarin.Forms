using NorthDallas.Contacts.Models;
using NorthDallas.Contacts.Services;
using NorthDallas.Contacts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NorthDallas.Contacts.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ContactListView : ContentPage
	{
        private ContactListViewModel _viewModel;
        public ContactListView ()
		{
            BindingContext = _viewModel = new ContactListViewModel(new UserService());
            InitializeComponent ();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            _viewModel.RefreshCommand.Execute(null);
        }

        private void OnContactSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is Result)
            {
                Navigation.PushAsync(new ContactDetailView(new ContactDetailViewModel((Result)e.SelectedItem)));
                var listView = (ListView)sender;
                listView.SelectedItem = null;
            }
        }
    }
}