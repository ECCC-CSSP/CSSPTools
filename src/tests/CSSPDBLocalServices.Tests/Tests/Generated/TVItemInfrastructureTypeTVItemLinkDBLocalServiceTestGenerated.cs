/* Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceTestGenerated.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPModels;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Xunit;
using System.ComponentModel.DataAnnotations;
using CSSPCultureServices.Resources;
using LocalServices;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemInfrastructureTypeTVItemLinkDBLocalServiceTest : TestHelper
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public TVItemInfrastructureTypeTVItemLinkDBLocalServiceTest() : base()
        {

        }
        #endregion Constructors

        #region Functions private
        private void CheckTVItemInfrastructureTypeTVItemLinkFields(List<TVItemInfrastructureTypeTVItemLink> tvItemInfrastructureTypeTVItemLinkList)
        {
            if (tvItemInfrastructureTypeTVItemLinkList[0].SeeOtherMunicipalityTVItemID != null)
            {
                Assert.NotNull(tvItemInfrastructureTypeTVItemLinkList[0].SeeOtherMunicipalityTVItemID);
            }
            if (!string.IsNullOrWhiteSpace(tvItemInfrastructureTypeTVItemLinkList[0].InfrastructureTypeText))
            {
                Assert.False(string.IsNullOrWhiteSpace(tvItemInfrastructureTypeTVItemLinkList[0].InfrastructureTypeText));
            }
        }

        #endregion Functions private
    }
}
