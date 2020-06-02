using CSSPModels;
using CSSPServices;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPWebAPI.Controllers
{
    public partial interface IAddressController
    {
        Task<ActionResult<List<Address>>> Get();
        Task<ActionResult<Address>> Get(int AddressID);
        Task<ActionResult<Address>> Post(Address address);
        Task<ActionResult<Address>> Put(Address address);
        Task<ActionResult<Address>> Delete(Address address);
    }

    [Route("api/{culture}/[controller]")]
    [ApiController]
    [Authorize]
    public partial class AddressController : ControllerBase, IAddressController
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IAddressService addressService { get; }
        private CSSPDBContext db { get; }
        private ILoggedInService loggedInService { get; }
        #endregion Properties

        #region Constructors
        public AddressController(IAddressService addressService, CSSPDBContext db, ILoggedInService loggedInService)
        {
            this.addressService = addressService;
            this.db = db;
            this.loggedInService = loggedInService;
        }
        #endregion Constructors

        #region Functions public
        [HttpGet]
        public async Task<ActionResult<List<Address>>> Get()
        {
            return await addressService.GetAddressList();
        }
        [HttpGet("{AddressID}")]
        public async Task<ActionResult<Address>> Get(int AddressID)
        {
            return await addressService.GetAddressWithAddressID(AddressID);
        }
        [HttpPost]
        public async Task<ActionResult<Address>> Post(Address address)
        {
            return await addressService.Add(address);
        }
        [HttpPut]
        public async Task<ActionResult<Address>> Put(Address address)
        {
            return await addressService.Update(address);
        }
        [HttpDelete]
        public async Task<ActionResult<Address>> Delete(Address address)
        {
            return await addressService.Delete(address);
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
