using CSSPEnums;
using CSSPModels;
using CSSPServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace CSSPWebAPI.Controllers
{
    [RoutePrefix("api/address")]
    public partial class AddressController : BaseController
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public AddressController() : base()
        {
        }
        public AddressController(DatabaseTypeEnum dbt = DatabaseTypeEnum.SqlServerTestDB) : base(dbt)
        {
        }
        #endregion Constructors

        #region Functions public
        // GET api/address
        [Route("")]
        public IHttpActionResult GetAddressList([FromUri]string lang = "en", [FromUri]int skip = 0, [FromUri]int take = 200,
            [FromUri]string asc = "", [FromUri]string desc = "", [FromUri]string where = "", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Lang = lang }, db, ContactID);

                if (extra == "A") // QueryString contains [extra=A]
                {
                   addressService.Query = addressService.FillQuery(typeof(AddressExtraA), lang, skip, take, asc, desc, where, extra);

                    if (addressService.Query.HasErrors)
                    {
                        return Ok(new List<AddressExtraA>()
                        {
                            new AddressExtraA()
                            {
                                HasErrors = addressService.Query.HasErrors,
                                ValidationResults = addressService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(addressService.GetAddressExtraAList().ToList());
                    }
                }
                else if (extra == "B") // QueryString contains [extra=B]
                {
                   addressService.Query = addressService.FillQuery(typeof(AddressExtraB), lang, skip, take, asc, desc, where, extra);

                    if (addressService.Query.HasErrors)
                    {
                        return Ok(new List<AddressExtraB>()
                        {
                            new AddressExtraB()
                            {
                                HasErrors = addressService.Query.HasErrors,
                                ValidationResults = addressService.Query.ValidationResults,
                            },
                        }.ToList());
                    }
                    else
                    {
                        return Ok(addressService.GetAddressExtraBList().ToList());
                    }
                }
                else // QueryString has no parameter [extra] or extra is empty
                {
                   addressService.Query = addressService.FillQuery(typeof(Address), lang, skip, take, asc, desc, where, extra);

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
        }
        // GET api/address/1
        [Route("{AddressID:int}")]
        public IHttpActionResult GetAddressWithID([FromUri]int AddressID, [FromUri]string lang = "en", [FromUri]string extra = "")
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseType))
            {
                AddressService addressService = new AddressService(new Query() { Language = (lang == "fr" ? LanguageEnum.fr : LanguageEnum.en) }, db, ContactID);

                addressService.Query = addressService.FillQuery(typeof(Address), lang, 0, 1, "", "", extra);

                if (addressService.Query.Extra == "A")
                {
                    AddressExtraA addressExtraA = new AddressExtraA();
                    addressExtraA = addressService.GetAddressExtraAWithAddressID(AddressID);

                    if (addressExtraA == null)
                    {
                        return NotFound();
                    }

                    return Ok(addressExtraA);
                }
                else if (addressService.Query.Extra == "B")
                {
                    AddressExtraB addressExtraB = new AddressExtraB();
                    addressExtraB = addressService.GetAddressExtraBWithAddressID(AddressID);

                    if (addressExtraB == null)
                    {
                        return NotFound();
                    }

                    return Ok(addressExtraB);
                }
                else
                {
                    Address address = new Address();
                    address = addressService.GetAddressWithAddressID(AddressID);

                    if (address == null)
                    {
                        return NotFound();
                    }

                    return Ok(address);
                }
            }
        }
        // POST api/address
        [Route("")]
        public IHttpActionResult Post([FromBody]Address address, [FromUri]string lang = "en")
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
                    return Created<Address>(new Uri(Request.RequestUri, address.AddressID.ToString()), address);
                }
            }
        }
        // PUT api/address
        [Route("")]
        public IHttpActionResult Put([FromBody]Address address, [FromUri]string lang = "en")
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
        public IHttpActionResult Delete([FromBody]Address address, [FromUri]string lang = "en")
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
