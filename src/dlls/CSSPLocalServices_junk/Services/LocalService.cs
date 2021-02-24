using CSSPEnums;
using CSSPDBModels;
using CSSPCultureServices.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using CSSPDBPreferenceModels;
using CSSPHelperModels;

namespace LocalServices
{
    public interface ILocalService
    {
        // Functions
        Task<bool> CheckInternetConnection();
    }
    public class LocalService : ILocalService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private ICSSPCultureService CSSPCultureService { get; set; }
        #endregion Properties

        #region Constructors
        public LocalService(ICSSPCultureService CSSPCultureService)
        {
            this.CSSPCultureService = CSSPCultureService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> CheckInternetConnection()
        {
            string url = "https://www.google.com/";

            try
            {
                HttpClient httpClient = new HttpClient();
                string ret = httpClient.GetStringAsync(url).GetAwaiter().GetResult();
                if (!string.IsNullOrWhiteSpace(ret))
                {
                    return await Task.FromResult(true);
                }
                else
                {
                    return await Task.FromResult(false);
                }
            }
            catch (Exception)
            {
                return await Task.FromResult(false);
            }
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
