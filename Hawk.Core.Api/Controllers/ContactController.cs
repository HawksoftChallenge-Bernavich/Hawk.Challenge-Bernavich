using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Hawk.Core.Data;
using Hawk.Core.Data.Model;

namespace Hawk.Core.Api.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        Hawk.Core.Data.Controller c = new Data.Controller();

        [HttpGet]
        public IEnumerable<Hawk.Core.Data.Model.Contact> Get()
        {
            return c.Context.Contacts.ToList();
        }
    }
}

