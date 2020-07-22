using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Hawk.Core.Data.Model;


/// <summary>
/// This is a utility class that creates the database and inserts a few records 
/// if it does not exist.
/// </summary>
namespace Hawk.Core.Data
{
    class CreateDb : Microsoft.EntityFrameworkCore.DbContext
    {
        public bool DbExists() => Database.CanConnect();
        public void CreateDatabase()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            this.Contacts.Add(new Contact() { ContactId = 1, Name = "Hawkeye", Email = "he@gmail.com", Address = "MCU" });
            this.Contacts.Add(new Contact() { ContactId = 2, Name = "Starlord", Email = "sl@gmail.com", Address = "Oregon" });
            this.Contacts.Add(new Contact() { ContactId = 3, Name = "Black Widow", Email = "bw@gmail.com", Address = "NY" });
            this.SaveChanges();

            foreach (var con in this.Contacts)
            {
                Console.WriteLine($"ContactId = {con.ContactId}, Name = {con.Name},Email = {con.Name}, Address={con.Address}");
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            string dir = Directory.GetCurrentDirectory();
            optionbuilder.UseSqlite($"Data Source={Directory.GetCurrentDirectory()}Contact.db");
        }

        public DbSet<Contact> Contacts { get; set; }
    }
}
