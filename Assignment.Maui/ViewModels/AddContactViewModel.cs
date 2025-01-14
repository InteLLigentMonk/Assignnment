﻿using Business.Factories;
using Business.Interface;
using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Assignment.Maui.ViewModels;

public partial class AddContactViewModel : ObservableObject
{
    private readonly IContactService _contactService;
    
    [ObservableProperty]
    private ContactRegForm _contact;

    public AddContactViewModel(IContactService contactService)
    {
        _contactService = contactService;
        Contact = ContactFactory.CreateContact();
    }

    [RelayCommand]
    async Task SaveContact()
    {
        _contactService.CreateContact(Contact);
        Contact = new ContactRegForm();
        await Shell.Current.GoToAsync($"//{nameof(MainPage)}");

    }

    [RelayCommand]
    async Task Cancel()
    {
        await Shell.Current.GoToAsync("..");
    }

}
