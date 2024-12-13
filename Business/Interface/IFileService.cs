using Business.Models;

namespace Business.Interface;

public interface IFileService
{

    bool Save(List<ContactRegForm> regForm);

    IEnumerable<ContactRegForm> Load();

}
