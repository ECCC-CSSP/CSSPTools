///*
// * Manually edited
// * 
// */
//using CSSPEnums;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;
//using System.Linq;

//namespace CSSPDBModels
//{
//    public partial class DeviceCode
//    {
//        #region Properties in DB
//        [Key]
//        [CSSPMaxLength(200)]
//        public string UserCode { get; set; }
//        [CSSPMaxLength(200)]
//        public string DeviceCode_ { get; set; }
//        [CSSPMaxLength(200)]
//        [CSSPAllowNull]
//        public string SubjectId { get; set; }
//        [CSSPMaxLength(200)]
//        public string ClientId { get; set; }
//        [CSSPAfter(Year = 1980)]
//        public DateTime CreationTime { get; set; }
//        [CSSPAfter(Year = 1980)]
//        public DateTime Expiration { get; set; }
//        [CSSPMaxLength(2000)]
//        public string Data { get; set; }
//        #endregion Properties in DB

//        #region Constructors
//        public DeviceCode()
//        {
//        }
//        #endregion Constructors
//    }
//}
