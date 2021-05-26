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
        IPeopelService _peopleService;
        ICityService _cityService;

        private readonly ILanguageService _languageService;
        private readonly IPersonLanguageService _personLanguageService;
        public IPeopleController(IPeopelService peopleservice,
            ICityService cityService,
            ILanguageService languageService,
            IPersonLanguageService personLanguageServic) //constructur for Dependency injection
        {
            _peopleService = peopleservice;
            _cityService = cityService;
            _languageService = languageService;
            _personLanguageService = personLanguageServic;

        }

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
        public IActionResult Edit(int id)
        {
            Person person = _peopleService.FindById(id);

            if (person != null)
            {
                return RedirectToAction(nameof(Index));
            }

            EditPersonViewModel editPerson = new EditPersonViewModel(id, person);

            editPerson.Id = id;
            editPerson.CreatePerson.ListofCity = _cityService.All().Towns;


            return View(editPerson);

        }


        [HttpPost]

        public IActionResult Edit(int id, EditPersonViewModel personvmodel)
        {
              Person editPerson = _peopleService.FindById(personvmodel.Id); //I'm not sure it working or not

            if (editPerson == null)
            {
                return RedirectToAction(nameof(Index));
            }

            if (ModelState.IsValid)
            {
             _peopleService.Edit(personvmodel.Id, personvmodel);

                return RedirectToAction(nameof(Index));
            }


            return View(personvmodel);
        }
    

        // Person personn = _peopleService.FindById(id);
        // if (personn == null)
        // {
        //     return RedirectToAction(nameof(Index));
        // }

        // if (ModelState.IsValid)
        // {
        //// _peopleService.Edit(id, createPerson);


        //     return RedirectToAction(nameof(Index));
        // }
        // EditPersonViewModel editPerson = new EditPersonViewModel(id, personedit: createPerson);
        // editPerson.ListofCity = _cityService.All().Towns;

        // return View(editPerson);


    }

        }
        
    



