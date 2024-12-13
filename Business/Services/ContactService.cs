using Business.Interface;
using Business.Models;

namespace Business.Services;

public class ContactService(IFileService fileService) : IContactService
{

    private readonly IFileService _fileService = fileService;
    private List<ContactRegForm> _contacts = (List<ContactRegForm>)fileService.Load();

    public void CreateContact(ContactRegForm contact)
    {
        _contacts.Add(contact);
        _fileService.Save(_contacts);

    }

    public IEnumerable<ContactRegForm> ReadContacts()
    {
        return _fileService.Load();
    }

    public void UpdateContact(ContactRegForm contact)
    {
        throw new NotImplementedException();
    }

    public void DeleteContact(ContactRegForm contact)
    {
        throw new NotImplementedException();
    }
}
