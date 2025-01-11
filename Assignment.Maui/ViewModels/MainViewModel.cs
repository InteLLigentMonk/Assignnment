using System.Collections.ObjectModel;
using Assignment.Maui.Pages;
using Business.Interface;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignment.Maui.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    [ObservableProperty]
    private ObservableCollection<ContactRegForm> _contacts = [];


    public MainViewModel(IContactService contactService)
    {
        _contactService = contactService;
        Contacts = ReformatContacts();
        _contactService.ContactsChanged += (s, e) => Contacts = ReformatContacts();

    }

    [RelayCommand]
    async Task AddContact() => await Shell.Current.GoToAsync(nameof(AddContactPage));

    [RelayCommand]
    public void DeleteContact(ContactRegForm contact)
    {
        if (contact != null)
        {
            _contactService.DeleteContact(contact.Id);
            Contacts = ReformatContacts();
        }
    }

    [RelayCommand]
    async Task EditContact(ContactRegForm contact)
    {
        var parameters = new ShellNavigationQueryParameters
        {
            { "Contact", contact }
        };

        await Shell.Current.GoToAsync(nameof(EditContactPage), parameters);
    }

    [RelayCommand]
    public void ToggleExpand(ContactRegForm contact)
    {
        if (contact != null)
        {
            contact.IsExpanded = !contact.IsExpanded;
        }
    }

    private ObservableCollection<ContactRegForm> ReformatContacts()
    {
        var oldList = _contactService.ReadContacts();
        ObservableCollection<ContactRegForm> newList = [];

        foreach (ContactRegForm contact in oldList)
        {
            newList.Add(contact);
        }
        return newList;

    }


}
