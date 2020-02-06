using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CSSPWebAPI.Controllers
{
    [Route("api/address")]
    public partial class AddressController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        //public AddressController() : base()
        //{
        //}
        public AddressController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/address
        [Route("")]
        [HttpGet]
        public IActionResult GetAddressList([FromQuery]string lang = "en", [FromQuery]int skip = 0, [FromQuery]int take = 200,
            [FromQuery]string asc = "", [FromQuery]string desc = "", [FromQuery]string where = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Lang = lang }, db, ContactID);

                addressService.Query = addressService.FillQuery(typeof(Address), lang, skip, take, asc, desc, where);

                 if (addressService.Query.HasErrors)
                 {
                     return Ok(new List<Address>()
                     {
                         new Address()
                         {
                             HasErrors = addressService.Query.HasErrors,
                             ValidationResults = addressService.Query.ValidationResults,
                         },
                     }.ToList());
                 }
                 else
                 {
                     return Ok(addressService.GetAddressList().ToList());
                 }
            }
        }
        // GET api/address/1
        [Route("{AddressID:int}")]
        [HttpGet("{AddressID}")]
        public IActionResult GetAddressWithID([FromQuery]int AddressID, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                addressService.Query = addressService.FillQuery(typeof(Address), lang, 0, 1, "", "");

                Address address = new Address();
                address = addressService.GetAddressWithAddressID(AddressID);

                if (address == null)
                {
                    return NotFound();
                }

                return Ok(address);
            }
        }
        // POST api/address
        [Route("")]
        [HttpPost]
        public IActionResult Post([FromBody]Address address, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!addressService.Add(address))
                {
                    return BadRequest(String.Join("|||", address.ValidationResults));
                }
                else
                {
                    address.ValidationResults = null;
                    return Created(Url.ToString(), address);
                }
            }
        }
        // PUT api/address
        [Route("")]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Address address, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!addressService.Update(address))
                {
                    return BadRequest(String.Join("|||", address.ValidationResults));
                }
                else
                {
                    address.ValidationResults = null;
                    return Ok(address);
                }
            }
        }
        // DELETE api/address
        [Route("")]
        [HttpDelete("{id}")]
        public IActionResult Delete([FromBody]Address address, [FromQuery]string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                if (!addressService.Delete(address))
                {
                    return BadRequest(String.Join("|||", address.ValidationResults));
                }
                else
                {
                    address.ValidationResults = null;
                    return Ok(address);
                }
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
