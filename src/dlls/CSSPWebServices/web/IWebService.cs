/*
 * Manually edited
 * 
 */
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSSPWebServices
{
    public interface IWebService
    {
        Task<ActionResult<WebRoot>> GetWebRoot();
        Task<ActionResult<WebCountry>> GetWebCountry(int TVItemID);
        Task<ActionResult<WebProvince>> GetWebProvince(int TVItemID);
        Task<ActionResult<WebArea>> GetWebArea(int TVItemID);
        Task<ActionResult<WebSector>> GetWebSector(int TVItemID);
        Task<ActionResult<WebSubsector>> GetWebSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn1980FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn1990FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2000FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2010FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2020FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2030FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2040FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSampleStartingIn2050FromSubsector(int TVItemID);
        Task<ActionResult<WebSamplingPlan>> GetWebSamplingPlan(int SamplingPlanID);
        Task<ActionResult<WebMunicipality>> GetWebMunicipality(int TVItemID);
    }
}
