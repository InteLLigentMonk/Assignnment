using Assignment.Maui.ViewModels;

namespace Assignment.Maui.Pages;

public partial class AddContactPage : ContentPage
{
	public AddContactPage(AddContactViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}