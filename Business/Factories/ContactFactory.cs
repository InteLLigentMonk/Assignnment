using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public static class ContactFactory
{

    public static ContactRegForm CreateContact()
    {
        return new ContactRegForm
        {
            Id = IdGenerator.UniqueIdGenerator()
        };
    }
}
