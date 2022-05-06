using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ClarkCodingChallenge.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.AspNetCore.Http;

namespace ClarkCodingChallenge.Controllers
{
    public class ContactsController : Controller
    {
        static HttpClient client = new HttpClient();
        private readonly IHttpContextAccessor _httpContextAccessor;

        //Dependency injection ;)
        public ContactsController(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            //Loads on page load, or if you click the button just as an example
            HttpResponseMessage response = await client.GetAsync("https://" + _httpContextAccessor.HttpContext.Request.Host.Value + "/api/contacts/aaa/desc");
            var payload = await response.Content.ReadAsStringAsync();
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact obj)
        {
            //TODO: Use Entitiy framework and update the db instead of the storing in a singleton

            if (obj != null)
                Contacts.AddPerson(obj);

            ModelState.Clear();
            return View();
        }
    }
}
