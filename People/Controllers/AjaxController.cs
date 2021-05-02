using Microsoft.AspNetCore.Mvc;
using People.Models.PersonData;
using People.Models.Service;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Controllers
{
    public class AjaxController : Controller
    {

        private IPeopelService _peopleService;
        public AjaxController()
        {
            _peopleService =  new PeopleService();
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult PeoplePartialView()
        {
         List <Person> personL = _peopleService.All().PersonL;
         return PartialView("_PersonRorPartialView", personL);

           
        }
        [HttpPost]
        public IActionResult DetailsPartialView(int id)
        {
            Person person = _peopleService.FindById(id);
            return PartialView("_PersonRorPartialView", person);

        }

        public IActionResult Removeperson(int id)
        {
          Person RemovedPerson = _peopleService.FindById(id);
                if (RemovedPerson != null)
                {
                    if (_peopleService.Remove(id))
                    {
                        return Ok("Person" +id);
                    }
                }
                return NotFound("Sorry we could not fund");
            }


        }

    }

