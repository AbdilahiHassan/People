using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using People.Models.MetaData;
using People.Models.PersonData;
using People.Models.Service;
using People.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Controllers
{
    [EnableCors("ReactPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class ReactController : ControllerBase
    {
        private readonly IPeopelService _peopelService;
        private readonly ICityRepo _cityRepo;
        public ReactController(IPeopelService peopelService , ICityRepo cityRepo)
        {
            _peopelService = peopelService;
            _cityRepo = cityRepo;

        }

        [HttpGet]

        public List<Person> Get()
        {
            List<Person> people = _peopelService.All().PersonL;
            foreach (var person in people)
            {
                if (person.InCity != null)
                {
                    person.InCity.townresident = null;
                    if (person.InCity.CountryNationsName != null)
                    {
                        person.InCity.CountryNationsName.Towns = null;
                    }

                }
            }

            return people;
        }




        [HttpGet("{id}")]

        public Person FinByid(int id)
        {

            return _peopelService.FindById(id);
        }



        [HttpPost]

        public ActionResult<Person> Create(CreatePerson person)

        {
            if (ModelState.IsValid)
            {
                return _peopelService.Add(person);
            }
            return BadRequest();

        }


        [HttpDelete("{id}")]

        public void Delete(int id)
        {
            if (_peopelService.Remove(id))
            {
                Response.StatusCode = 200;
            }
            else
            {
                Response.StatusCode = 400;

            }

        }
        //-...............City....

        [HttpGet("/incity")]

        public List <City> Getcity()
        {

            return _cityRepo.Read();

        }
    }
}
