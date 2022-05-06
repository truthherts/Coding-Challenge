using ClarkCodingChallenge.Controllers;
using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClarkCodingChallenge.Tests.ControllerTest
{
    [TestClass]
    public class ContactsControllerTests
    {
        private readonly HttpContextAccessor _httpContextAccessor;

        public ContactsControllerTests()
        {
            _httpContextAccessor = new HttpContextAccessor();
        }

        [TestMethod]
        public void TestMethod1()
        {
            var controller = new ContactsController(_httpContextAccessor);
            var result = controller.Index(new Models.Contact { FirstName = "a", LastName = "b", Email = "test@geezee.com" }) as ViewResult;
            var contactList = Contacts.GetContacts();
            Assert.AreEqual("a", contactList[0].FirstName);
        }
    }
}
