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
    public partial class SamplingPlanAndFilesLabSheetCountTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        private SamplingPlanAndFilesLabSheetCount samplingPlanAndFilesLabSheetCount { get; set; }
        #endregion Properties

        #region Constructors
        public SamplingPlanAndFilesLabSheetCountTest()
        {
            samplingPlanAndFilesLabSheetCount = new SamplingPlanAndFilesLabSheetCount();
        }
        #endregion Constructors

        #region Tests Functions public
        [Fact]
        public void SamplingPlanAndFilesLabSheetCount_Properties_Test()
        {
            List<string> propNameList = new List<string>() { "LabSheetHistoryCount", "LabSheetTransferredCount", "SamplingPlan", "TVFileSamplingPlanFileTXT",  }.OrderBy(c => c).ToList();

            int index = 0;
            foreach (PropertyInfo propertyInfo in typeof(SamplingPlanAndFilesLabSheetCount).GetProperties().Where(c => c.Name != "ValidationResults").OrderBy(c => c.Name).ToList())
            {
                Assert.Equal(propertyInfo.Name, propNameList[index]);
                index += 1;
            }

            Assert.Equal(propNameList.Count, index);
        }
        [Fact]
        public void SamplingPlanAndFilesLabSheetCount_Every_Property_Has_Get_Set_Test()
        {
               int val1 = 45;
               samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount = val1;
               Assert.Equal(val1, samplingPlanAndFilesLabSheetCount.LabSheetHistoryCount);
               int val2 = 45;
               samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount = val2;
               Assert.Equal(val2, samplingPlanAndFilesLabSheetCount.LabSheetTransferredCount);
               SamplingPlan val3 = new SamplingPlan();
               samplingPlanAndFilesLabSheetCount.SamplingPlan = val3;
               Assert.Equal(val3, samplingPlanAndFilesLabSheetCount.SamplingPlan);
               TVFile val4 = new TVFile();
               samplingPlanAndFilesLabSheetCount.TVFileSamplingPlanFileTXT = val4;
               Assert.Equal(val4, samplingPlanAndFilesLabSheetCount.TVFileSamplingPlanFileTXT);
        }
        #endregion Tests Functions public
    }
}
