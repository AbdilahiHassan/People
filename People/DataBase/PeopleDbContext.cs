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

        //Join table configured using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PersonLanguage>().HasKey(PL =>
            new
            {
                PL.PersonId,
                PL.LanguageId

            });

        }

        public DbSet<Person> persons { get; set; }
        public DbSet<City> Towns { get; set; }
        public DbSet<Country> Countries { get; set; }
        //Many to many DBSets
        public DbSet<PersonLanguage> PersonLanguage { get; set; }
        public DbSet<Language> Language { get; set; }
    }

    /* Rebuild
     * Package manage console
     *dotnet ef migrations add (addedsales.change your databaseName)
      *dotnet ef database
      *
     */
}
