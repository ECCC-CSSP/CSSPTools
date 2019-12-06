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
using CSSPModelsGenerateCodeHelper;
using System.Data.SqlClient;
using System.Data;
using CSSPGenerateCodeBase;

namespace CSSPWebAPIGenerateCodeHelper
{
    public partial class WebAPICodeWriter : GenerateCodeBase
    {
        #region Variables
        #endregion Variables

        #region Properties
        protected CSSPDBContext dbCSSPDB { get; set; }
        protected CSSPDBContext dbCSSPDBRead { get; set; }
        protected CSSPDBContext dbTestDB { get; set; }
        protected CSSPDBContext dbTestDBWrite { get; set; }
        private ModelsCodeWriter modelsGenerateCodeHelper { get; set; }
        #endregion Properties

        #region Constructors
        public WebAPICodeWriter()
        {
            dbCSSPDB = new CSSPDBContext(DatabaseTypeEnum.MemoryCSSPDB);
            dbCSSPDBRead = new CSSPDBContext(DatabaseTypeEnum.SqlServerCSSPDB);
            dbTestDB = new CSSPDBContext(DatabaseTypeEnum.MemoryTestDB);
            dbTestDBWrite = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB);

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
