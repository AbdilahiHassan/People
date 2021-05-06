using Microsoft.EntityFrameworkCore;
using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.DataBase
{
    public class PeopleDbContext: DbContext
    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {
        }

     public   DbSet<Person> persons { get; set; }
        public object People { get; internal set; }
    }


}
