using MvvmHelpers;
using NorthDallas.Contacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthDallas.Contacts.ViewModels
{
    public class ContactDetailViewModel
        : BaseViewModel
    {
        public ContactDetailViewModel(Result contact)
        {
            Contact = contact;
            Title = $"{contact.name.first} {contact.name.last}";
        }

        public Result Contact { get; set; }
    }
}
