/*
 * Manually edited
 * 
 */
using CSSPDBModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace CSSPWebModels
{
    [NotMapped]
    public partial class MWQMRunDataTableModel
    {
        #region Properties
        public string MWQMSiteName { get; set; }
        public DateTime SampleDate { get; set; }
        public int FC { get; set; }
        public double Sal { get; set; }
        public double Temp { get; set; }
        public string ProcessedBy { get; set; }
        public string SampleTypes { get; set; }
        public string SampleNote { get; set; }
        #endregion Properties

        #region Constructors
        public MWQMRunDataTableModel()
        {
        }
        #endregion Constructors
    }
}
