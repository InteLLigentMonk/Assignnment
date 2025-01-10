using Business.Interface;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignment.Maui.ViewModels;


public partial class EditContactViewModel : ObservableObject, IQueryAttributable
{
    IContactService _contactService;

    [ObservableProperty]
    ContactRegForm? contact;

    public EditContactViewModel(IContactService contactService)
    {
        _contactService = contactService;
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        Contact = (query["Contact"] as ContactRegForm)!;
    }

    [RelayCommand]
    async Task SaveContact()
    {
        _contactService.UpdateContact(Contact);
        Contact = new ContactRegForm();
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

    }

    [RelayCommand]
    async Task Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }
}
