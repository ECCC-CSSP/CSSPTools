/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\WebAPIClassNameControllerGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPModels;
using CSSPDBLocalServices;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using LocalServices;

namespace CSSPWebAPIs.Controllers
{
    public partial interface IAddressController
    {
        Task<ActionResult<List<Address>>> Get();
        Task<ActionResult<Address>> Get(int AddressID);
        Task<ActionResult<Address>> Post(Address Address);
        Task<ActionResult<Address>> Put(Address Address);
        Task<ActionResult<bool>> Delete(int AddressID);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    public partial class AddressController : ControllerBase, IAddressController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; }
        private ILocalService LocalService { get; }
        private IAddressDBLocalService AddressDBLocalService { get; }
        #endregion Properties

        #region Constructors
        public AddressController(ICSSPCultureService CSSPCultureService, ILocalService LocalService, IAddressDBLocalService AddressDBLocalService)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.LocalService = LocalService;
            this.AddressDBLocalService = AddressDBLocalService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Address>>> Get()
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await AddressDBLocalService.GetAddressList();
        }
        [HttpGet("{AddressID}")]
        public async Task<ActionResult<Address>> Get(int AddressID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await AddressDBLocalService.GetAddressWithAddressID(AddressID);
        }
        [HttpPost]
        public async Task<ActionResult<Address>> Post(Address Address)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await AddressDBLocalService.Post(Address);
        }
        [HttpPut]
        public async Task<ActionResult<Address>> Put(Address Address)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await AddressDBLocalService.Put(Address);
        }
        [HttpDelete("{AddressID}")]
        public async Task<ActionResult<bool>> Delete(int AddressID)
        {
            CSSPCultureService.SetCulture((string)RouteData.Values["culture"]);
            await LocalService.SetLoggedInContactInfo();

            return await AddressDBLocalService.Delete(AddressID);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}