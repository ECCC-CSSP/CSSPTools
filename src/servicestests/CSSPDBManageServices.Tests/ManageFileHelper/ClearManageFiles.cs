using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ManageServices.Tests
{
    public partial class ManageFileServicesTests
    {
        private void ClearManageFiles()
        {
            List<ManageFile> manageFileToDeleteList = (from c in dbManage.ManageFiles
                                                       select c).ToList();

            try
            {
                dbManage.ManageFiles.RemoveRange(manageFileToDeleteList);
                dbManage.SaveChanges();
            }
            catch (Exception ex)
            {
                Assert.True(false, $"Could not delete all ManageFiles. Ex: { ex.Message }");
            }
        }
    }
}
