using System;
using System.Collections.Generic;
using System.Text;

namespace Hawk.Core.Data.Model
{
    public class Contact : IContact
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
