/*
 * Manually edited
 * 
 */
using CSSPCultureServices.Services;
using CSSPEnums;
using CSSPWebModels;
using FileServices;
using LoggedInServices;
using ManageServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace ReadGzFileServices
{
    public partial class ReadGzFileService : ControllerBase, IReadGzFileService
    {
        public async Task<T> GetUncompressJSON<T>(WebTypeEnum webType, int TVItemID = 0)
        {
            var actionRes = await ReadJSON<T>(webType, TVItemID);
            return (T)((OkObjectResult)actionRes.Result).Value;
        }
    }
}
