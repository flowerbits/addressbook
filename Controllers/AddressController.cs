using AddressbookServer.Data;
using AddressbookServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AddressbookServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AddressController : Controller
    {
        private readonly IBaseProvider<EntryModel> entries;
        public AddressController(IBaseProvider<EntryModel> entryProvider)
        {
            entries = entryProvider;
        }

        [HttpGet]
        public JsonResult All()
        {
            return new JsonResult(new JsonReturnData(true, entries.GetAll()));
        }

        [HttpGet("{id:Guid}")]
        public async Task<JsonResult> Entry(Guid id)
        {
            return new JsonResult(new JsonReturnData(true, await entries.GetById(id)));
        }
                
    }
}
