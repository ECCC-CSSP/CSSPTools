//using CSSPEnums;
//using CSSPDBModels;
//using Microsoft.AspNetCore.Mvc;
//using System;
//using System.IO;
//using System.Net.Http;
//using System.Threading.Tasks;
//using Xunit;
//using System.Diagnostics;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.Extensions.DependencyInjection;
//using Microsoft.EntityFrameworkCore;

//namespace CSSPDesktopInstallPostBuildServices.Tests
//{
//    public partial class CSSPDesktopInstallPostBuildServiceTests
//    {
//        private void CopyOtherFileToTestOtherFile()
//        {

//            foreach(string fileName in CSSPOtherFileList)
//            {
//                try
//                {
//                    File.Copy(fileName.Replace("test", ""), fileName);
//                }
//                catch (Exception ex)
//                {
//                    Assert.True(false, ex.Message);
//                }
//            }

//            foreach (string fileName in CSSPOtherFileList)
//            {
//                FileInfo fi = new FileInfo(fileName);

//                Assert.True(fi.Exists);
//            }
//        }
//    }
//}
