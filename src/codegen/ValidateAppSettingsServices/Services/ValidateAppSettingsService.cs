using ValidateAppSettingsServices.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using ActionCommandDBServices.Services;
using CultureServices.Resources;
using CultureServices.Services;

namespace ValidateAppSettingsServices.Services
{
    public interface IValidateAppSettingsService
    {
        List<AppSettingParameter> AppSettingParameterList { get; set; }
        Task<bool> VerifyAppSettings();
    }
    public partial class ValidateAppSettingsService : IValidateAppSettingsService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; }
        public List<AppSettingParameter> AppSettingParameterList { get; set; }
        private ICultureService CultureService { get; }
        private IActionCommandDBService actionCommandDBService { get; }
        #endregion Properties

        #region Constructors
        public ValidateAppSettingsService(IConfiguration configuration, IActionCommandDBService actionCommandDBService)
        {
            this.configuration = configuration;
            this.actionCommandDBService = actionCommandDBService;
            AppSettingParameterList = new List<AppSettingParameter>();
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        public async Task<bool> VerifyAppSettings()
        {
            bool retBool = true;

            if (!await CheckParameterExist())
            {
                retBool = false;
            }

            foreach (AppSettingParameter appSettingParameter in AppSettingParameterList)
            {
                if (appSettingParameter.IsFile)
                {
                    if (!await CheckFileParameterValue(appSettingParameter.Parameter, appSettingParameter.ExpectedValue, appSettingParameter.CheckExist))
                    {
                        retBool = false;
                    }
                }
                else if (appSettingParameter.IsCulture)
                {
                    if (!await CheckCultureParameterValue(appSettingParameter.Parameter))
                    {
                        retBool = false;
                    }
                }
                else
                {
                    if (!await CheckParameterValue(appSettingParameter.Parameter, appSettingParameter.ExpectedValue))
                    {
                        retBool = false;
                    }
                }
            }
            return retBool;
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
