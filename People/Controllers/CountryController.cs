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
    public class CountryController : Controller


    {
        private readonly ICityService _cityService;
        private readonly ICountryService _countryService;
        public CountryController(ICityService cityService, ICountryService countryService)
        {
            this._cityService = cityService;
            this._countryService = countryService;
        }


        // GET: CountryController
        public ActionResult Index()
        {
        
            return View(_countryService.All());
        }

        // GET: CountryController/Details/5
        public ActionResult Details(int id)
        {
            Country Editcountry = _countryService.FindBy(id);
            //EditCountryViewModel Editcountry = country.

            if (Editcountry == null)
            {
                return RedirectToAction(nameof(Index));
            }
            EditCountryViewModel editCountry = new EditCountryViewModel(id, Editcountry);
            editCountry.Createveiwmodelforcntr.CityList = _cityService.FindTownresident(id);
            return View(editCountry);
           
        }

        // GET: CountryController/Create
        public ActionResult Create()
        {
            CreateCountryViewModel createCountry = new CreateCountryViewModel();

            return View(createCountry);
        }

        // POST: CountryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateCountryViewModel createCountry)
        {
            if (ModelState.IsValid)
            {
                _countryService.Add(createCountry); //I'm not sure solving
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createCountry);
            }
        }

        // GET: CountryController/Edit/5
        public ActionResult Edit(int id)
        {
            Country editCountry = _countryService.FindBy(id);
            if (editCountry == null)
            {
                return RedirectToAction(nameof(Index));
            }

            EditCountryViewModel editCountryViewModel = new EditCountryViewModel(id, editCountry);

            return View(editCountryViewModel);
        }

        // POST: CountryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, EditCountryViewModel editCountryViewModel)
        {
            Country updCountry = _countryService.FindBy(id);
            if (updCountry == null)
            {
                return RedirectToAction(nameof(Index));
            }
            if (ModelState.IsValid)
            {
                _countryService.Edit(id, editCountryViewModel);
                return RedirectToAction(nameof(Index));
            }
            //invalid modelstate
            return View(editCountryViewModel);
        }

           
        

        // GET: CountryController/Delete/5
        public ActionResult Delete(int id)
        {
            Country Deletecountry = _countryService.FindBy(id);
            Deletecountry.Towns = _cityService.FindTownresident(id);
            return View(Deletecountry);
        }

        // POST: CountryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            bool result = _countryService.Remove(id);
            if (result)
            {
                return RedirectToAction(nameof(Index));
            }


            return RedirectToAction(nameof(Index));
        }
    }
}
