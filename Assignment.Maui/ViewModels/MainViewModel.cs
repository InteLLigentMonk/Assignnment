using System.Collections.ObjectModel;
using Business.Interface;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Assignment.Maui.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IContactService _contactService;

    [ObservableProperty]
    private ObservableCollection<ContactRegForm> _contacts = [];

    public MainViewModel(IContactService contactService)
    {
        _contactService = contactService;
        _contacts = new ObservableCollection<ContactRegForm>(_contactService.ReadContacts());
    }

}
