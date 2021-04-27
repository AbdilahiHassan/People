using Microsoft.AspNetCore.Mvc;
using People.Models.PersonData;
using People.Models.Service;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Controllers
{

    public class IPeopleController : Controller
    {
        IPeopelService _peopleService = new PeopleService();

        [HttpGet]
        public IActionResult Index()
        {
            return View(_peopleService.All());
        }
        [HttpPost]
        public IActionResult Index(PeopleViewModel IndexViewModel)
        {
            //IndexViewModel.PersonL = _peopleService.FindById(IndexViewModel.SearchFilter.co);
            PeopleViewModel filtmodel = _peopleService.FindBy(IndexViewModel);
            IndexViewModel.SearchFilter = filtmodel.SearchFilter;
            ModelState.Clear();
            return View(IndexViewModel);

        }
        //[HttpGet]
        //public IActionResult Create(PeopleViewModel  createPers)
        //{
        //    return View(new CreatePerson());
        //}
        [HttpPost]
        public IActionResult Create(PeopleViewModel createPerso)

        {
            if (ModelState.IsValid)
            {
                _peopleService.Add(createPerso.createPerson);

                return RedirectToAction(nameof(Index));
            }
            createPerso = _peopleService.All();

            return View("Index", createPerso);
        }
        [HttpGet]

        public IActionResult Delete(int id)
        {
            if (_peopleService.Remove(id))
            {
                return RedirectToAction(nameof(Index));
            }
            else 
            {
                return RedirectToAction(nameof(Index));
            }
        }
             [HttpGet]
            public IActionResult Update(int id)
                  {
            Person updPerson = _peopleService.FindById(id);
                if (updPerson != null)
                {
                    updPerson.LastName = updPerson.LastName + " Updated";

                    updPerson = _peopleService.Edit(id, updPerson);
                }
                return RedirectToAction(nameof(Index));
            }
        }
    }

    

