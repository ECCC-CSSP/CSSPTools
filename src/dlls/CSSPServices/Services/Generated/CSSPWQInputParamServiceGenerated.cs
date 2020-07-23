///*
// * Auto generated from C:\CSSPTools\src\codegen\_package\netcoreapp3.1\ServicesClassNameServiceGenerated.exe
// *
// * Do not edit this file.
// *
// */ 

//using CSSPEnums;
//using CSSPModels;
//using CSSPCultureServices.Resources;
//using CSSPCultureServices.Services;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace CSSPServices
//{
//    public interface ICSSPWQInputParamService
//    {
//        IEnumerable<ValidationResult> Validate(ValidationContext validationContext);
//    }
//    public partial class CSSPWQInputParamService : ICSSPWQInputParamService
//    {
//        #region Variables
//        #endregion Variables

//        #region Properties
//        private ICSSPCultureService CSSPCultureService { get; }
//        private IEnums enums { get; }
//        #endregion Properties

//        #region Constructors
//        public CSSPWQInputParamService(ICSSPCultureService CSSPCultureService, IEnums enums)
//        {
//            this.CSSPCultureService = CSSPCultureService;
//            this.enums = enums;
//        }
//        #endregion Constructors

//        #region Functions public
//        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
//        {
//            string retStr = "";
//            CSSPWQInputParam cSSPWQInputParam = validationContext.ObjectInstance as CSSPWQInputParam;

//            retStr = enums.EnumTypeOK(typeof(CSSPWQInputTypeEnum), (int?)cSSPWQInputParam.CSSPWQInputType);
//            if (!string.IsNullOrWhiteSpace(retStr))
//            {
//                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "CSSPWQInputType"), new[] { "CSSPWQInputType" });
//            }

//            if (string.IsNullOrWhiteSpace(cSSPWQInputParam.Name))
//            {
//                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._IsRequired, "Name"), new[] { "Name" });
//            }

//            if (!string.IsNullOrWhiteSpace(cSSPWQInputParam.Name) && (cSSPWQInputParam.Name.Length < 1 || cSSPWQInputParam.Name.Length > 200))
//            {
//                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._LengthShouldBeBetween_And_, "Name", "1", "200"), new[] { "Name" });
//            }

//            if (cSSPWQInputParam.TVItemID < 1)
//            {
//                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MinValueIs_, "TVItemID", "1"), new[] { "TVItemID" });
//            }

//            if (!string.IsNullOrWhiteSpace(cSSPWQInputParam.CSSPWQInputTypeText) && cSSPWQInputParam.CSSPWQInputTypeText.Length > 100)
//            {
//                yield return new ValidationResult(string.Format(CSSPCultureServicesRes._MaxLengthIs_, "CSSPWQInputTypeText", "100"), new[] { "CSSPWQInputTypeText" });
//            }

//                //CSSPError: Type not implemented [sidList] of type [List`1]

//            //sidList has no StringLength Attribute

//                //CSSPError: Type not implemented [MWQMSiteList] of type [List`1]

//            //MWQMSiteList has no StringLength Attribute

//                //CSSPError: Type not implemented [MWQMSiteTVItemIDList] of type [List`1]

//            //MWQMSiteTVItemIDList has no Range Attribute

//                //CSSPError: Type not implemented [DailyDuplicateMWQMSiteList] of type [List`1]

//            //DailyDuplicateMWQMSiteList has no StringLength Attribute

//                //CSSPError: Type not implemented [DailyDuplicateMWQMSiteTVItemIDList] of type [List`1]

//            //DailyDuplicateMWQMSiteTVItemIDList has no Range Attribute

//                //CSSPError: Type not implemented [InfrastructureList] of type [List`1]

//            //InfrastructureList has no StringLength Attribute

//                //CSSPError: Type not implemented [InfrastructureTVItemIDList] of type [List`1]

//            //InfrastructureTVItemIDList has no Range Attribute

//            retStr = ""; // added to stop compiling CSSPError
//            if (retStr != "") // will never be true
//            {
//                yield return new ValidationResult("AAA", new[] { "AAA" });
//            }

//        }
//        #endregion Functions public

//    }
//}