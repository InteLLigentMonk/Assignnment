//Denna filen har förbättrats med hjälp av Github Copilot.

using Business.Interface;
using Business.Models;
using Business.Services;
using Moq;

namespace Business.Tests.Services
{
    public class ContactService_Tests
    {
        private readonly IContactService _contactService;
        private readonly Mock<IFileService> _fileServiceMock;
        private readonly ContactRegForm _contact;
        private List<ContactRegForm> _contacts;

        public ContactService_Tests()
        {
            _contacts = new List<ContactRegForm>();
            _contact = new ContactRegForm
            {
                Id = "1",
                FirstName = "Bruce",
                LastName = "Wayne",
                Phone = "555-1234",
                Email = "Bruce.Wayne@Wayneenterprises.com",
                Street = "1007 Mountain Drive",
                City = "Gotham",
                ZipCode = "10027"
            };
            _contacts.Add(_contact);
            _fileServiceMock = new Mock<IFileService>();
            _fileServiceMock.Setup(x => x.Load()).Returns(_contacts);
            _fileServiceMock.Setup(x => x.Save(It.IsAny<List<ContactRegForm>>()))
                .Callback<List<ContactRegForm>>(contacts => _contacts = contacts)
                .Returns(true);
            _contactService = new ContactService(_fileServiceMock.Object);

        }

        [Fact]
        public void CreateContact_ShouldAddContact()
        {

            // Act
            _contactService.CreateContact(_contact);

            // Assert
            _fileServiceMock.Verify(x => x.Save(It.IsAny<List<ContactRegForm>>()), Times.Once);
            Assert.NotNull(_contacts);
            Assert.Contains(_contacts, contact => contact.Id == _contact.Id);
        }

        [Fact]
        public void ReadContacts_ShouldReturnListOfContacts()
        {
            // Act
            var contacts = _contactService.ReadContacts();
            // Assert
            Assert.NotNull(contacts);
            Assert.Single(contacts);
            Assert.Contains(contacts, c => c.Id == _contact.Id);
        }



        [Fact]
        public void DeleteContact_ShouldDeleteContact()
        {

            // Arrange
            _contacts.Add(_contact);

            // Act
            _contactService.DeleteContact(_contact.Id);

            //Assert
            _fileServiceMock.Verify(x => x.Save(It.IsAny<List<ContactRegForm>>()), Times.Once);
            Assert.NotNull(_contacts);
            Assert.DoesNotContain(_contacts, c => c.Id == _contact.Id);
        }

        [Fact]
        public void UpdateContact_ShouldUpdateContact()
        {
            // Arrange
            var updatedContact = new ContactRegForm
            {
                Id = "1",
                FirstName = "Clark",
                LastName = "Kent",
                Phone = "555-4321",
                Email = "clark.kent@dailyplanet.com",
                Street = "344 Clinton Street, Apartment 3B",
                City = "Metropolis",
                ZipCode = "55501"
            };

            // Act
            _contactService.UpdateContact(updatedContact);

            // Assert
            _fileServiceMock.Verify(x => x.Save(It.IsAny<List<ContactRegForm>>()), Times.Once);
            Assert.NotNull(_contacts);
            var contact = _contacts.FirstOrDefault(c => c.Id == updatedContact.Id);
            Assert.NotNull(contact);
            Assert.Equal("Clark", contact.FirstName);
            Assert.Equal("Kent", contact.LastName);
            Assert.Equal("555-4321", contact.Phone);
            Assert.Equal("clark.kent@dailyplanet.com", contact.Email);
            Assert.Equal("344 Clinton Street, Apartment 3B", contact.Street);
            Assert.Equal("Metropolis", contact.City);
            Assert.Equal("55501", contact.ZipCode);

        }

        [Fact]
        public void ReformatContacts_ShouldReturnListOfContacts_NotIEnumerable()
        {
            // Act
            var result = _contactService.ReformatContacts();
            // Assert
            Assert.NotNull(result);
            Assert.IsType<List<ContactRegForm>>(result);
            Assert.Single(result);
            Assert.Contains(result, c => c.Id == _contact.Id);
        }
    }
}
