using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using People.Models;
using People.Models.PersonData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.DataBase
{
    public class PeopleDbContext: IdentityDbContext<UserApplication>


    {
        public PeopleDbContext(DbContextOptions<PeopleDbContext> options) : base(options)
        {
        }

        //Join table configured using Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //Recommend on the first line inside method.
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
