using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Host;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using People.Models.Service;
using People.Models.MetaData;
using People.Models.ViewModel;
using ILanguageService = People.Models.Service.ILanguageService;
using People.Models.PersonData;

namespace People.Controllers
{
    public class LanguageController : Controller
    {
        // GET: LanuageController
      private readonly ILanguageService _languageService;
        public LanguageController(ILanguageService languageService)
        {
       _languageService = languageService;
          
        }
        [HttpGet]
        public ActionResult Index()
        {
           return View(_languageService.All());
          
        }

        // GET: LanuageController/Details/5
        public ActionResult Details(int id)
        {


            
            return View();
        }

        // GET: LanuageController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: LanuageController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateLanguageViewModel createLanguageViewModel)
        {


            if (ModelState.IsValid)
            {
           _languageService.Add(createLanguageViewModel);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(createLanguageViewModel);
            }
         
            
        }

        // GET: LanuageController/Edit/5
        public ActionResult Edit(int id)
        {



            
            return View();
        }

        // POST: LanuageController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LanuageController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LanuageController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
