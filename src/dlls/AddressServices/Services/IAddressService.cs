using CSSPModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace AddressServices.Services
{
    public interface IAddressService
    {
        Task<ActionResult<List<Address>>> GetAddressList();
        Task SetCulture(CultureInfo culture);
    }
}