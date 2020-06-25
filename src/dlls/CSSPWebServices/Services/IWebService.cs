/*
 * Manually edited
 * 
 */
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public interface IWebService
    {
        Task<ActionResult<WebRoot>> GetWebRoot();
        Task<ActionResult<WebCountry>> GetWebCountry(int TVItemID);
        Task<ActionResult<WebProvince>> GetWebProvince(int TVItemID);
        Task<ActionResult<WebArea>> GetWebArea(int TVItemID);
        Task<ActionResult<WebSector>> GetWebSector(int TVItemID);
        Task<ActionResult<WebSubsector>> GetWebSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSample1980_1989FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSample1990_1999FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSample2000_2009FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSample2010_2019FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSample2020_2029FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSample2030_2039FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSample2040_2049FromSubsector(int TVItemID);
        Task<ActionResult<WebSample>> GetWeb10YearOfSample2050_2059FromSubsector(int TVItemID);
        Task<ActionResult<WebSamplingPlan>> GetWebSamplingPlan(int SamplingPlanID);
        Task<ActionResult<WebMunicipality>> GetWebMunicipality(int TVItemID);
    }

}
