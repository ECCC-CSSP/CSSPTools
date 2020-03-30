using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSSPModels;
using CSSPWebAPIs.Resources;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CSSPWebAPIs.Controllers
{
    [Route("api/{culture}/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        CSSPDBContext _db { get; set; }
        public AddressController(CSSPDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Address>>> Get()
        {
            try
            {
                
                var addressList = _db.Addresses.Take(4).ToList();

                foreach (var a in addressList)
                {
                    a.StreetName = WebSite.test;
                }

                return addressList;
            }
            catch (Exception ex)
            {
                int lsijef = 34;
            }

            return null;
        }
    }
}
