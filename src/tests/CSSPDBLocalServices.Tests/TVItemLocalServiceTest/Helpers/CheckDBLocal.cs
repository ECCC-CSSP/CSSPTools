/* 
 *  Manually Edited
 *  
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPHelperModels;
using CSSPReadGzFileServices;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System.Text.Json;
using ManageServices;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemLocalServiceTest : CSSPDBLocalServiceTest
    {
        private void CheckDBLocal(List<TVItemModel> tvItemModelParentList)
        {
            Assert.Equal(tvItemModelParentList.Count, (from c in dbLocal.TVItems select c).Count());
            Assert.Equal(tvItemModelParentList.Count * 2, (from c in dbLocal.TVItemLanguages select c).Count());

            foreach (TVItemModel tvItemModel in tvItemModelParentList)
            {
                TVItem tvItem = (from c in dbLocal.TVItems
                                 where c.TVItemID == tvItemModel.TVItem.TVItemID
                                 select c).FirstOrDefault();

                Assert.NotNull(tvItem);

                List<TVItemLanguage> tvItemLanguageList = (from c in dbLocal.TVItemLanguages
                                                           where c.TVItemID == tvItemModel.TVItem.TVItemID
                                                           orderby c.Language
                                                           select c).ToList();

                Assert.NotNull(tvItem);

                TVItemModel tvItemModelDB = new TVItemModel()
                {
                    TVItem = tvItem,
                    TVItemLanguageList = tvItemLanguageList,
                    TVItemStatList = tvItemModel.TVItemStatList,
                    MapInfoModelList = tvItemModel.MapInfoModelList,
                };

                Assert.Equal(JsonSerializer.Serialize(tvItemModel), JsonSerializer.Serialize(tvItemModelDB));
            }
        }
    }
}
