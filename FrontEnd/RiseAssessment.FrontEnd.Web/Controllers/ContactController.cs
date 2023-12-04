using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RiseAssessment.FrontEnd.Web.Models;
using RiseAssessment.FrontEnd.Web.Services.Interfaces;
using System.Collections.Generic;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RiseAssessment.FrontEnd.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly ILogger<ContactController> _logger;

        private readonly IPersonService _personService;
        private readonly IContactService _contactService;
        List<SelectListItem> ContactTypeList;
        public ContactController(ILogger<ContactController> logger, IPersonService personService, IContactService contactService)
        {
            _logger = logger;
            _personService = personService;
            _contactService = contactService;
            ContactTypeList = new List<SelectListItem>(){
                new SelectListItem(){Text="Telephone", Value="Telephone"},
                new SelectListItem(){Text="Fax", Value="Fax"},
                new SelectListItem(){Text="Email", Value="Email"},
                new SelectListItem(){Text="Location", Value="Location"}
            };


        }

        public async Task<IActionResult> Create(string id)
        {
            ViewBag.id = id;
            ViewBag.typeList = new SelectList(ContactTypeList, "Text", "Value");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ContactDto data)
        {
            data.Id = null;
            data.Name = "";
            data.Surname = "";
            ViewBag.typeList = new SelectList(ContactTypeList, "Text", "Value");

            if (!ModelState.IsValid)
            {
                return View();
            }
            await _contactService.CreateAsync(data);

            return RedirectToAction("Detail", "Home", new { id = data.PersonId });
        }

        public async Task<IActionResult> Update(string id)
        {

            var model = await _contactService.GetById(id);
            ViewBag.typeList = new SelectList(ContactTypeList, "Text", "Value", model.Type);

            if (model == null)
            {
                RedirectToAction("Detail", "Home", new { id = model.PersonId });
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(ContactDto data)
        {
            var model = await _contactService.UpdateAsync(data);
            ViewBag.typeList = new SelectList(ContactTypeList, "Text", "Value", data.Type);
            if (!ModelState.IsValid)
            {
                return View();
            }
            return RedirectToAction("Detail", "Home", new { id = data.PersonId });
        }

        public async Task<IActionResult> Delete(string id)
        {
            var result = await _contactService.DeleteAsync(id);

            return RedirectToAction("Index", "Home");
        }
    }
}