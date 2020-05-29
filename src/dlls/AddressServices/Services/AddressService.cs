using CSSPModels;
using CultureServices.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AddressServices.Services
{
    public class AddressService : ControllerBase, IAddressService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; }
        private CSSPDBContext db { get; }
        #endregion Properties

        #region Constructors
        public AddressService(IConfiguration configuration, CSSPDBContext db)
        {
            this.configuration = configuration;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<List<Address>>> GetAddressList()
        {
            List<Address> addressList = (from c in db.Addresses
                                         orderby c.AddressID
                                         select c).ToList();

            return Ok(addressList);
        }
        public async Task SetCulture(CultureInfo culture)
        {
            CultureServicesRes.Culture = culture;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}