using Business.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Assignment.Maui.ViewModels;

public partial class AddContactViewModel : ObservableObject
{

    [ObservableProperty]
    private ContactRegForm _contactRegForm = new();
}
