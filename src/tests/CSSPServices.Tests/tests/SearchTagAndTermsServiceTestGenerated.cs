 /* Auto generated from the CSSPCodeWriter.proj by clicking on the [\src\[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using CSSPServices;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.Security.Principal;
using System.Globalization;
using CSSPServices.Resources;
using CSSPModels.Resources;
using CSSPEnums.Resources;

namespace CSSPServices.Tests
{
    public partial class SearchTagAndTermsServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        //private SearchTagAndTermsService searchTagAndTermsService { get; set; }
        #endregion Properties

        #region Constructors
        public SearchTagAndTermsServiceTest() : base()
        {
            //searchTagAndTermsService = new SearchTagAndTermsService(LanguageRequest, dbTestDB, ContactID);
        }
        #endregion Constructors

        #region Functions private
        private SearchTagAndTerms GetFilledRandomSearchTagAndTerms(string OmitPropName)
        {
            SearchTagAndTerms searchTagAndTerms = new SearchTagAndTerms();

            if (OmitPropName != "SearchTag") searchTagAndTerms.SearchTag = (SearchTagEnum)GetRandomEnumType(typeof(SearchTagEnum));
            if (OmitPropName != "SearchTagText") searchTagAndTerms.SearchTagText = GetRandomString("", 5);
            if (OmitPropName != "SearchTermList") searchTagAndTerms.SearchTermList = new List<string>() { GetRandomString("", 20), GetRandomString("", 20) };

            return searchTagAndTerms;
        }
        #endregion Functions private
    }
}
