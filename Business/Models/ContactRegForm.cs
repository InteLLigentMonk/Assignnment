using CommunityToolkit.Mvvm.ComponentModel;

namespace Business.Models;

public partial class ContactRegForm : ObservableObject
{
    public string Id { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Street { get; set; } = null!;

    public string ZipCode {  get; set; } = null!;

    public string City { get; set; } = null!;

    public string Name => $"{FirstName} {LastName}";

    public string Address => $"{ZipCode}, {City}";

    public string Initials => $"{FirstName[0]}{LastName[0]}";

    [ObservableProperty]
    private bool _isExpanded;
}
