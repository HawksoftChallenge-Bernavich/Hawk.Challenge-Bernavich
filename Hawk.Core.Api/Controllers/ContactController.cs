using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Hawk.Core.Data;
using Hawk.Core.Data.Model;

namespace Hawk.Core.Api.Controllers
{
    /// <summary>
    /// Primary data controller for our REST Api
    /// </summary>
    [ApiController]
    [Route("contact")]
    public class ContactController : ControllerBase
    {
        Data.Controller data = new Data.Controller();
      
        [HttpGet]
        public IEnumerable<Hawk.Core.Data.Model.Contact> Get()
        {
            return data.Context.Contacts;
        }

        [HttpGet("{id}")]
        public Hawk.Core.Data.Model.Contact Get(int id)
        {
            return data.Context.Contacts.Where(c=>c.ContactId == id).FirstOrDefault();
        }

        /* TO IMPLEMENT
         [HttpPost]
         public void Post([FromBody] string value){} 

         [HttpPut("{id}")]
         public void Put(int id, [FromBody] string value)
         {
         }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
         */
    }
}
