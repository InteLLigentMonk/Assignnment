using Assignment.Maui.ViewModels;

namespace Assignment.Maui.Pages;

public partial class EditContactPage : ContentPage
{
	public EditContactPage(EditContactViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}