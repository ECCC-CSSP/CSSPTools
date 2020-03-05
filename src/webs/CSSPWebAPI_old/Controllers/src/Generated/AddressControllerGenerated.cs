/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ModelClassName]ControllerGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using CSSPWebAPI.Controllers.Resources;

namespace CSSPWebAPI.Controllers
{
    [Route("api/[controller]")]
    public partial class AddressController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AddressController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/address
        [HttpGet]
        public IActionResult GetAddressList(string lang = "en", int skip = 0, int take = 200,
            string asc = "", string desc = "", string where = "")
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
        [HttpGet("{AddressID}")]
        public IActionResult GetAddressWithID(int AddressID, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpPost]
        public IActionResult Post(Address address, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Lang = lang }, db, ContactID);

                if (!addressService.Add(address))
                {
                    return BadRequest(String.Join("|||", address.ValidationResults));
                }
                else
                {
                    address.ValidationResults = null;
                    return Created("/api/address/" + address.AddressID, address);
                }
            }
        }
        // PUT api/address
        [HttpPut]
        public IActionResult Put(Address address, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Lang = lang }, db, ContactID);

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
        [HttpDelete]
        public IActionResult Delete(Address address, string lang = "en")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Lang = lang }, db, ContactID);

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