//using CSSPEnums;
//using CSSPDBModels;
//using CSSPCultureServices.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Net.Http;
//using Microsoft.Extensions.Configuration;
//using CSSPDBPreferenceModels;
//using CSSPHelperModels;
//using CSSPWebModels;

//namespace WebAppLoadedServices
//{
//    public interface IWebAppLoadedService
//    {
//        // Functions
//        Task<bool> DoSomething();
//        WebAppLoaded webAppLoaded { get; set; }
//    }
//    public class WebAppLoadedService : IWebAppLoadedService
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        public WebAppLoaded webAppLoaded { get; set; }
//        private ICSSPCultureService CSSPCultureService { get; set; }
//        #endregion Properties

//        #region Constructors
//        public WebAppLoadedService(ICSSPCultureService CSSPCultureService)
//        {
//            this.CSSPCultureService = CSSPCultureService;
//            webAppLoaded = new WebAppLoaded();
//        }
//        #endregion Constructors

//        #region Functions public
//        public async Task<bool> DoSomething()
//        {
//            return await Task.FromResult(true);
//        }
//        #endregion Functions public

//        #region Functions private
//        #endregion Functions private
//    }
//}
