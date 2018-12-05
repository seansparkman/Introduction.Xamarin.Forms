using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthDallas.Contacts.ViewModels
{
    public class ContactListViewModel
        : BaseViewModel
    {
        public ContactListViewModel()
        {
            Contacts.AddRange(new string[]
            {
                "Sean",
                "Homero",
                "Gabrielle",
                "Anna",
                "Annette",
                "Bella",
                "Brett",
                "Stephen"
            });
        }

        public ObservableRangeCollection<string> Contacts { get; set; } =
            new ObservableRangeCollection<string>();
    }
}
