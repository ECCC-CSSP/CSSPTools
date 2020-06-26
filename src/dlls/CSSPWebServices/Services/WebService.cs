﻿/*
 * Manually edited
 * 
 */
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private CSSPDBContext db { get; }
        private ICultureService CultureService { get; }
        private ILoggedInService LoggedInService { get; }
        private IEnums enums { get; }
        #endregion Properties

        #region Constructors
        public WebService(ICultureService CultureService, ILoggedInService LoggedInService, IEnums enums, CSSPDBContext db)
        {
            this.CultureService = CultureService;
            this.LoggedInService = LoggedInService;
            this.enums = enums;
            this.db = db;
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<WebRoot>> GetWebRoot()
        {
            return await DoGetWebRoot();
        }
        public async Task<ActionResult<WebCountry>> GetWebCountry(int TVItemID)
        {
            return await DoGetWebCountry(TVItemID);
        }
        public async Task<ActionResult<WebProvince>> GetWebProvince(int TVItemID)
        {
            return await DoGetWebProvince(TVItemID);
        }
        public async Task<ActionResult<WebArea>> GetWebArea(int TVItemID)
        {
            return await DoGetWebArea(TVItemID);
        }
        public async Task<ActionResult<WebSector>> GetWebSector(int TVItemID)
        {
            return await DoGetWebSector(TVItemID);
        }
        public async Task<ActionResult<WebSubsector>> GetWebSubsector(int TVItemID)
        {
            return await DoGetWebSubsector(TVItemID);
        }
        public async Task<ActionResult<WebMunicipality>> GetWebMunicipality(int TVItemID)
        {
            return await DoGetWebMunicipality(TVItemID);
        }
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample1980_1989FromSubsector(int TVItemID)
        {
            return await DoGetWebSample(TVItemID, 1980);
        }
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample1990_1999FromSubsector(int TVItemID)
        {
            return await DoGetWebSample(TVItemID, 1990);
        }
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2000_2009FromSubsector(int TVItemID)
        {
            return await DoGetWebSample(TVItemID, 2000);
        }
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2010_2019FromSubsector(int TVItemID)
        {
            return await DoGetWebSample(TVItemID, 2010);
        }
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2020_2029FromSubsector(int TVItemID)
        {
            return await DoGetWebSample(TVItemID, 2020);
        }
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2030_2039FromSubsector(int TVItemID)
        {
            return await DoGetWebSample(TVItemID, 2030);
        }
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2040_2049FromSubsector(int TVItemID)
        {
            return await DoGetWebSample(TVItemID, 2040);
        }
        public async Task<ActionResult<WebMWQMSample>> GetWeb10YearOfSample2050_2059FromSubsector(int TVItemID)
        {
            return await DoGetWebSample(TVItemID, 2050);
        }
        public async Task<ActionResult<WebSamplingPlan>> GetWebSamplingPlan(int TVItemID)
        {
            return await DoGetWebSamplingPlan(TVItemID);
        }
        public async Task<ActionResult<WebMWQMRun>> GetWebMWQMRun(int TVItemID)
        {
            return await DoGetWebMWQMRun(TVItemID);
        }
        public async Task<ActionResult<WebMWQMSite>> GetWebMWQMSite(int TVItemID)
        {
            return await DoGetWebMWQMSite(TVItemID);
        }
        public async Task<ActionResult<WebContact>> GetWebContact()
        {
            return await DoGetWebContact();
        }
        public async Task<ActionResult<WebClimateSite>> GetWebClimateSite(int TVItemID)
        {
            return await DoGetWebClimateSite(TVItemID);
        }
        public async Task<ActionResult<WebHydrometricSite>> GetWebHydrometricSite(int TVItemID)
        {
            return await DoGetWebHydrometricSite(TVItemID);
        }
        public async Task<ActionResult<WebDrogueRun>> GetWebDrogueRun(int TVItemID)
        {
            return await DoGetWebDrogueRun(TVItemID);
        }
        public async Task<ActionResult<WebMWQMLookupMPN>> GetWebMWQMLookupMPN()
        {
            return await DoGetWebMWQMLookupMPN();
        }
        public async Task<ActionResult<WebMikeScenario>> GetWebMikeScenario(int TVItemID)
        {
            return await DoGetWebMikeScenario(TVItemID);
        }
        public async Task<ActionResult<WebClimateDataValue>> GetWebClimateDataValue(int TVItemID)
        {
            return await DoGetWebClimateDataValue(TVItemID);
        }
        public async Task<ActionResult<WebHydrometricDataValue>> GetWebHydrometricDataValue(int TVItemID)
        {
            return await DoGetWebHydrometricDataValue(TVItemID);
        }
        public async Task<ActionResult<WebHelpDoc>> GetWebHelpDoc()
        {
            return await DoGetWebHelpDoc();
        }
        public async Task<ActionResult<WebTideLocation>> GetWebTideLocation()
        {
            return await DoGetWebTideLocation();
        }
        public async Task<ActionResult<WebPolSourceSite>> GetWebPolSourceSite(int TVItemID)
        {
            return await DoGetWebPolSourceSite(TVItemID);
        }
        public async Task<ActionResult<WebPolSourceGrouping>> GetWebPolSourceGrouping()
        {
            return await DoGetWebPolSourceGrouping();
        }
        public async Task<ActionResult<WebReportType>> GetWebReportType()
        {
            return await DoGetWebReportType();
        }
        #endregion Functions public
    }
}
