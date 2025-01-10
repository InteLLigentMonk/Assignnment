//This file has been improved with the help of GitHub Copilot

using System.Text.Json;
using Business.Models;
using Business.Services;

namespace Business.Tests.Services;

public class FileService_Tests
{
    private readonly string _testDirectoryPath;
    private readonly string _testFilePath;
    private readonly FileService _fileService;

    public FileService_Tests()
    {
        _testDirectoryPath = Path.Combine(Path.GetTempPath(), "TestDirectory");
        _testFilePath = Path.Combine(_testDirectoryPath, "contactList.json");
        _fileService = new FileService("contactList.json", _testDirectoryPath);
    }

    [Fact]
    public void Save_WhenCalled_SavesFile_AndReturnsTrue()
    {
        //Arrange
        List<ContactRegForm> contacts =
        [
            new ContactRegForm
            {
            Id = "1",
            FirstName = "Bruce",
            LastName = "Wayne",
            Phone = "555-1234",
            Email = "Bruce.Wayne@Wayneenterprises.com",
            Street = "1007 Mountain Drive",
            City = "Gotham",
            ZipCode = "10027"
            }
        ];

        //Act
        var result = _fileService.Save(contacts);

        //Assert
        Assert.True(File.Exists(_testFilePath));
        Assert.True(result);
        var json = File.ReadAllText(_testFilePath);
        Assert.NotEmpty(json);
    }

    [Fact]
    public void Load_ReturnsContacts_WhenFileExists()
    {
        //Arrange
        List<ContactRegForm> contacts =
        [
            new ContactRegForm
            {
            Id = "1",
            FirstName = "Bruce",
            LastName = "Wayne",
            Phone = "555-1234",
            Email = "Bruce.Wayne@Wayneenterprises.com",
            Street = "1007 Mountain Drive",
            City = "Gotham",
            ZipCode = "10027"
            }
        ];
        var json = JsonSerializer.Serialize(contacts);
        File.WriteAllText(_testFilePath, json);

        //Act
        var result = _fileService.Load();

        //Assert
        Assert.NotNull(result);
        Assert.Single(result);
        var contact = result.First();
        Assert.Equal("1", contact.Id);
        Assert.Equal("Bruce", contact.FirstName);
        Assert.Equal("Wayne", contact.LastName);
        Assert.Equal("555-1234", contact.Phone);
        Assert.Equal("1007 Mountain Drive", contact.Street);
        Assert.Equal("Gotham", contact.City);
        Assert.Equal("10027", contact.ZipCode);
    }
}
