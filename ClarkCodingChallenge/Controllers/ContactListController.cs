using ClarkCodingChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace ClarkCodingChallenge.Controllers
{
    //TODO: Just a quick controller as an endpoint instead of scaffolding out full webapi endpoint project
    [ApiController]
    public class ContactListController : Controller
    {
        [HttpGet]
        [Route("api/contacts/{lastName}/{order}")]

        public IActionResult Get(string lastName, string order)
        {
            var contacts = Contacts.GetContacts();
            var result = new List<Contact>();

            if (!string.IsNullOrEmpty(lastName))
                result = contacts.Where(x => x.LastName == lastName.Trim()).ToList();

            switch (order.Trim().ToLower())
            {
                case "asc":
                    result = result.OrderBy(x=>x.LastName).ToList();
                    break;
                case "desc":
                    result = result.OrderByDescending(x => x.LastName).ToList();
                    break;
            }

            return Json(new { data = result });
        }
    }
}


