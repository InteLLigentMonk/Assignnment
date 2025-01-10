using Business.Models;

namespace Business.Interface;

public interface IContactService
{
    public event EventHandler? ContactsChanged;
    public void CreateContact(ContactRegForm regForm);

    public void UpdateContact(ContactRegForm regForm);
    public void DeleteContact(string Id);

    public IEnumerable<ContactRegForm> ReadContacts();

    public List<ContactRegForm> ReformatContacts();
}
