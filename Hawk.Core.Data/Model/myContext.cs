using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Hawk.Core.Data.Model
{
    /*
   * TO DO: 
   * Impliment Lazy Loading to increase performance
   * Move Data access methods to controller and out of context 
   * 
   */

    /// <summary>
    /// This is primary context class that represents the current data load to SQLLite DB
    /// via EntityFrameworkCore.  
    /// </summary>

    public class myContext: DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        public myContext()
        {
            //If embedded database does not exist yet, set it up and 
            //create test records
            CreateDb setup = new CreateDb();
            if (!setup.DbExists()) setup.CreateDatabase();
        }

      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={Directory.GetCurrentDirectory()}Contact.db");
        }

        /// <summary>
        /// Set our mapping to models as well as set our primary key
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().ToTable("Contacts");
            modelBuilder.Entity<Contact>(entity => {entity.HasKey(p => p.ContactId); }); //set our key

            base.OnModelCreating(modelBuilder);
        }
    }
}
