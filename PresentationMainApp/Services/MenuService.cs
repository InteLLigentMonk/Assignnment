using Business.Factories;
using Business.Interface;

namespace PresentationMainApp.Services;

public class MenuService(IContactService contactService) : IMenuService
{

    private readonly IContactService _contactService = contactService;

    public void MainMenu()
    {
        bool running = true;

        do
        {
            Console.Clear();
            Console.WriteLine("*-------- Main Menu --------*");
            Console.WriteLine("1. Show Contacts");
            Console.WriteLine("2. Add Contact");
            Console.WriteLine("3. Update Contact");
            Console.WriteLine("4. Delete Contact");
            Console.WriteLine("5. Exit");
            Console.WriteLine("*---------------------------*");
            Console.Write("Enter your choice: ");
            var choice = Console.ReadLine();

            switch(choice)
            {
                case "1":
                    ShowContacts();
                    break;
                case "2":
                    AddContact();
                    break;
                case "3":
                    UpdateContact();
                    break;
                case "4":
                    DeleteContact();
                    break;
                case "5":
                    Exit();
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
        while (running);
    }

    public void ShowContacts()
    {
        var contacts  = _contactService.ReadContacts();
        Console.Clear() ;
        if (contacts.Count() == 0)
        {
            Console.WriteLine("No contacts found.");
            return;
        }
        foreach (var contact in contacts)
        {
            Console.Write("*-------- Contact ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(contact.Id);
            Console.ResetColor();
            Console.WriteLine(" --------*");
            Console.WriteLine($"Name: {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Email: {contact.Email}");
            Console.WriteLine($"Phone: {contact.Phone}");
            Console.WriteLine($"Address: {contact.Street}, {contact.ZipCode}, {contact.City}");
            Console.WriteLine("*---------------------------------*");
        }
            Console.Read();
    }
    public void AddContact()
    {
        var contact = ContactFactory.CreateContact();

        Console.Clear();
        Console.Write("Enter First Name: ");
        contact.FirstName = Console.ReadLine()!;
        Console.Write("Enter Last Name: ");
        contact.LastName = Console.ReadLine()!;
        Console.Write("Enter Email: ");
        contact.Email = Console.ReadLine()!;
        Console.Write("Enter Phone: ");
        contact.Phone = Console.ReadLine()!;
        Console.Write("Enter Street: ");
        contact.Street = Console.ReadLine()!;
        Console.Write("Enter Zip Code: ");
        contact.ZipCode = Console.ReadLine()!;
        Console.Write("Enter City: ");
        contact.City = Console.ReadLine()!;
        _contactService.CreateContact(contact);

    }

    public void DeleteContact()
    {
        throw new NotImplementedException();
    }
    public void UpdateContact()
    {
        throw new NotImplementedException();
    }

    public void Exit()
    {
        Console.WriteLine("Do you really want to exit? (Y/N)");
        var choice = Console.ReadLine()!.ToLower();
        if (choice == "y")
        {
            Environment.Exit(0);
        }
    }

}
