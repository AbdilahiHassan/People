using Microsoft.AspNetCore.Http;
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

    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        private readonly IPeopelService _peopleService;
        public CityController(ICityService cityService, ICountryService countryService, IPeopelService peopleService)
        {
            this._cityService = cityService;
            this._countryService = countryService;
            this._peopleService = peopleService;


        }
        // GET: CityController
        public ActionResult Index()
        {
            return View(_cityService.All());
        }

        // GET: CityController/Details/5
        public ActionResult Details(int id)
        {
            City city = _cityService.FindBy(id);

            if (city == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(city);
        }

        // GET: CityController/Create
        
        public ActionResult Create()
        {
            CreateCityViewModel createCityViewModel = new CreateCityViewModel();

            createCityViewModel.Countries = _countryService.All().Nations;

            return View(createCityViewModel);



        }

        // POST: CityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCityViewModel createcitys)
        {
            if (ModelState.IsValid)
            {
                _cityService.Add(createcitys);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createcitys);
            }
        }

        // GET: CityController/Edit/5
        public ActionResult Edit(int id)
        {
            City city = _cityService.FindBy(id);

            if (city == null)
            {
                return RedirectToAction("Index");
            }
            EditCityViewModel cityViewModel = new EditCityViewModel();

            return View(city);
        }

        // POST: CityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCityViewModel editCityViewModel)
        {
            City city = _cityService.Edit(id, editCityViewModel);
            if (ModelState.IsValid)
            {
                _cityService.Edit(id, editCityViewModel);
                return RedirectToAction(nameof(Index));

            }

            return View(editCityViewModel);

        } 


        // GET: CityController/Delete/5
        public ActionResult Delete(int id)
        {
            //goback and see
            //City city = _cityService.FindBy(id);
            //city.CountryNationsName = _peopleService.FindBy(id);
           return View();
        }

        // POST: CityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            bool result = _cityService.Remove(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }

         
            return RedirectToAction(nameof(Index));
        }

    }
    }


