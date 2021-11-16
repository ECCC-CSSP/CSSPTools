using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
//using System.Windows.Forms;
using CSSPModels;
using CSSPEnums;
using System.Data.SqlClient;
using System.Data;
using CSSPGenerateCodeBase;
using CSSPModelsGenerateCodeHelper;
using Microsoft.Extensions.Configuration;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesCodeWriter : GenerateCodeBase
    {
        #region Variables
        private string fullPath = @"C:\CSSPTools\src\appsettings.json";
        #endregion Variables

        #region Properties
        public IConfigurationRoot Configuration { get; }
        protected CSSPDBContext dbCSSPDB { get; set; }
        protected CSSPDBContext dbTestDB { get; set; }
        private ModelsCodeWriter modelsGenerateCodeHelper { get; set; }
        #endregion Properties

        #region Constructors
        /// <summary>
        ///     Constructor
        /// </summary>
        public ServicesCodeWriter()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile(fullPath, optional: true, reloadOnChange: true)
                .Build();

            dbCSSPDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerCSSPDB);
            dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB);

            modelsGenerateCodeHelper = new ModelsCodeWriter();
        }
        #endregion Constructors

        #region Events
        #endregion Events

        #region Functions public
        #endregion Functions public

        #region Functions private
        #endregion Functions private
    }
}
