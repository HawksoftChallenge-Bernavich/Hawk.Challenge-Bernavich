using System;
using System.Collections.Generic;
using System.Text;
using Hawk.Core.Data;
using Hawk.Core.Data.Model;

namespace Hawk.Core.Data
{
    /// <summary>
    /// Primary execution methods for data control to the data context
    /// </summary>
    public interface IController
    {
        public myContext Context {get; set;}

        public void Create(Contact row);
        public void Update(Contact row);
        public void Delete(Contact row);
    }
}
