using Business.Interface;
using Business.Models;

namespace Business.Services;

public class ContactService : IContactService
{
    private readonly IFileService _fileService;
    public List<ContactRegForm> _contacts;

    public event EventHandler? ContactsChanged;


    public ContactService(IFileService fileService)
    {
        _fileService = fileService;
        _contacts = ReformatContacts();
    }


    public void CreateContact(ContactRegForm contact)
    {
        _contacts.Add(contact);
        _fileService.Save(_contacts);
        ContactsChanged?.Invoke(this, EventArgs.Empty);

    }


    public IEnumerable<ContactRegForm> ReadContacts()
    {
        return _fileService.Load();
    }


    public void UpdateContact(ContactRegForm contact)
    {
        var contactToUpdate = _contacts.FirstOrDefault(c => c.Id == contact.Id);
        if (contactToUpdate != null) 
        {
            contactToUpdate.FirstName = contact.FirstName;
            contactToUpdate.LastName = contact.LastName;
            contactToUpdate.Phone = contact.Phone;
            contactToUpdate.Email = contact.Email;
            contactToUpdate.Street = contact.Street;
            contactToUpdate.City = contact.City;
            contactToUpdate.ZipCode = contact.ZipCode;
            _fileService.Save(_contacts);
            ContactsChanged?.Invoke(this, EventArgs.Empty);
        }
    }


    public void DeleteContact(string Id)
    {
        _contacts.Remove(_contacts.FirstOrDefault(c => c.Id == Id)!);
        _fileService.Save(_contacts);
        ContactsChanged?.Invoke(this, EventArgs.Empty);
    }


    public List<ContactRegForm> ReformatContacts()
    {
        var oldList = _fileService.Load();
        var newList = new List<ContactRegForm>();

        foreach (ContactRegForm contact in oldList)
        {
            newList.Add(contact);
        }
        return newList;
    }
}
