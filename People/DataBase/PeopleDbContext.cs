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
        public DbSet<City> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
      
    }

    /* Rebuild
     * Package manage console
     *dotnet ef migrations add (addedsales.change your databaseName)
      *dotnet ef database
      *
     */
}
