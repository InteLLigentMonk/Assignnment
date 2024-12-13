using Business.Models;

namespace Business.Interface;

public interface IContactService
{
    public void CreateContact(ContactRegForm regForm);

    public void UpdateContact(ContactRegForm regForm);
    public void DeleteContact(ContactRegForm regForm);

    public IEnumerable<ContactRegForm> ReadContacts();
}
