using Microsoft.AspNetCore.Mvc;
using RiseAssessment.FrontEnd.Web.Models;
using RiseAssessment.FrontEnd.Web.Services.Interfaces;

namespace RiseAssessment.FrontEnd.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;
        private readonly IContactService _contactService;

        public HomeController(ILogger<HomeController> logger, IPersonService personService, IContactService contactService)
        {
            _logger = logger;
            _personService = personService;
            _contactService = contactService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _personService.GetAllAsync());
        }

        public async Task<IActionResult> Detail(string id)
        {
            var model = new PersonContactDetailModel();
            var person = await _personService.GetById(id);
            var contacts = await _contactService.GetContactByPersonAsync(id);
            model.Person = person;
            model.Contacts = contacts;
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(PersonDto data)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            await _personService.CreateAsync(data);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(string id)
        {
            var model = await _personService.GetById(id);

            if (model == null)
            {
                RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(PersonDto data)
        {
            var result = await _personService.UpdateAsync(data);
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> RemovePersonItem(string id)
        {
            var result = await _personService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}