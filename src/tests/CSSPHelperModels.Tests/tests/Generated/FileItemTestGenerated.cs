/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperModels_TestsGenerated.exe
 *
 * Do not edit this file.
 *
 */ 
using System;
using System.Text;
using Xunit;
using System.Linq;
using System.Globalization;
using System.Transactions;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using System.ComponentModel.DataAnnotations;
using CSSPDBModels;

namespace CSSPHelperModels.Tests
{
    public partial class FileItemTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private FileItem fileItem { get; set; }
        #endregion Properties

        #region Constructors
        public FileItemTest()
        {
            fileItem = new FileItem();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void FileItem_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "Name", "TVItemID",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(FileItem).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void FileItem_Every_Property_Has_Get_Set_Test()
        {
               string val1 = "Some text";
               fileItem.Name = val1;
               Assert.Equal(val1, fileItem.Name);
               int val2 = 45;
               fileItem.TVItemID = val2;
               Assert.Equal(val2, fileItem.TVItemID);
        }
        #endregion Tests Functions public
    }
}
