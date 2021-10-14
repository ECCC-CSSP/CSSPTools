/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest
    {
        private async Task<TVItemLocalModel> FillTVItemLocalModelForDelete(TVItemModel tvItemModel, TVItemModel tvItemModelParent)
        {
            return new TVItemLocalModel()
            {
                TVItem = tvItemModel.TVItem,
                TVItemLanguageList = tvItemModel.TVItemLanguageList,
                TVItemParent = tvItemModelParent.TVItem,
            };
        }
    }
}
