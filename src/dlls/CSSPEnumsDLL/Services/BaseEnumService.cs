using CSSPEnumsDLL.Enums;
using CSSPEnumsDLL.Services.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPEnumsDLL.Services
{
    public partial class BaseEnumService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public LanguageEnum LanguageRequest { get; set; }
        #endregion Properties

        #region Constructors
        public BaseEnumService(LanguageEnum LanguageRequest)
        {
            this.LanguageRequest = LanguageRequest;
            if (this.LanguageRequest == LanguageEnum.fr)
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("fr-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-CA");
            }
            else
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-CA");
            }
        }
        #endregion Construtors

        #region Functions
        #endregion Functions

    }
}
