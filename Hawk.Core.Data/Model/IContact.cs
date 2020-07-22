using System;
using System.Collections.Generic;
using System.Text;

namespace Hawk.Core.Data.Model
{
    public interface IContact
    {
        int ContactId { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Address { get; set; }
    }
}
