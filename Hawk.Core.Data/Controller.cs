using Hawk.Core.Data;
using Hawk.Core.Data.Model;
using System;

namespace Hawk.Core.Data
{
    public class Controller : IController
    {
        public myContext Context {get; set;}
        public Controller()
        {
            Context = new myContext();
        }

        public void Create(Contact row)
        {
            Context.Contacts.Add(row);
            Context.SaveChanges();
        }

        public void Delete(Contact row)
        {
            Context.Contacts.Remove(row);
            Context.SaveChanges();
        }

        public void Update(Contact row)
        { 
            if (row != null)
            {
                Context.SaveChanges();
            }
        }
    }
}
