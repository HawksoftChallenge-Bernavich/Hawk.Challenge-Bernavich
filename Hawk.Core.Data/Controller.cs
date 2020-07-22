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
            throw new NotImplementedException();
        }

        public void Delete(Contact row)
        {
            throw new NotImplementedException();
        }

        public void Update(Contact row)
        {
            throw new NotImplementedException();
        }
    }
}
