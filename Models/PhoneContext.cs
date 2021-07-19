using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ch04MultiPageAmbroson.Models
{
    public class PhoneContext : DbContext
    {
        public PhoneContext(DbContextOptions<PhoneContext> options) : base(options)
        { }

        public DbSet<Phone> PhoneContacts { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().HasData(
                new Contact { ContactId = "M", Name = "Mobile" },
                new Contact { ContactId = "W", Name = "Work" },
                new Contact { ContactId = "H", Name = "Home" }
                );

            modelBuilder.Entity<Phone>().HasData(
                new Phone
                {
                    PhoneId = 1,
                    Name = "Nick",
                    Number = "515-555-1234",
                    Notes = "Its me!",
                    ContactId = "M"
                },

                new Phone
                {
                    PhoneId = 2,
                    Name = "Hayley",
                    Number = "515-555-4321",
                    Notes = "Wifey",
                    ContactId = "W"
                },

                new Phone
                {
                    PhoneId = 3,
                    Name = "Griff",
                    Number = "515-555-1111",
                    Notes = "Big man Griffin",
                    ContactId = "H"
                }
            );
        }
    }
}
