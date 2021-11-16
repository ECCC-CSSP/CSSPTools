using CSSPCultureServices.Resources;
using CSSPHelperModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xunit;

namespace ManageServices.Tests
{

    public partial class ManageFileServicesTests
    {
        private async Task<ManageFile> AddTestAsync(ManageFile manageFile)
        {
            var actionAdd = await ManageFileService.AddAsync(manageFile);
            Assert.Equal(200, ((ObjectResult)actionAdd.Result).StatusCode);
            Assert.NotNull(((OkObjectResult)actionAdd.Result).Value);
            ManageFile manageFileAdd = (ManageFile)((OkObjectResult)actionAdd.Result).Value;
            Assert.NotNull(manageFileAdd);
            //Assert.Equal(1, manageFileAdd.ManageFileID);

            ManageFile manageFileAddDB = (from c in dbManage.ManageFiles
                                          where c.ManageFileID == manageFileAdd.ManageFileID
                                          select c).FirstOrDefault();

            Assert.Equal(JsonSerializer.Serialize(manageFileAdd), JsonSerializer.Serialize(manageFileAddDB));

            return manageFileAdd;
        }
    }
}
