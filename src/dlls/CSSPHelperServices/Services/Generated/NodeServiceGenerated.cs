/*
 * Auto generated from C:\CSSPTools\src\codegen\_package\net5.0\GenerateCSSPHelperServices.exe
 *
 * Do not edit this file.
 *
 */

using CSSPEnums;
using CSSPHelperModels;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using LoggedInServices;
using Microsoft.Extensions.Configuration;

namespace CSSPHelperServices
{
    public interface INodeService
    {
        bool Validate(ValidationContext validationContext);
        List<ValidationResult> ValidationResults { get; set; }
    }
    public partial class NodeService : INodeService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public List<ValidationResult> ValidationResults { get; set; }
        #endregion Properties

        #region Constructors
        public NodeService()
        {
        }
        #endregion Constructors

        #region Functions public
        public bool Validate(ValidationContext validationContext)
        {
            ValidationResults = new List<ValidationResult>();

            Node node = validationContext.ObjectInstance as Node;

            if (node.ID < 1 || node.ID > 1000000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "ID", "1", "1000000"), new[] { "ID" }));
            }

            if (node.X < -180 || node.X > 180)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "X", "-180", "180"), new[] { "X" }));
            }

            if (node.Y < -90 || node.Y > 90)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Y", "-90", "90"), new[] { "Y" }));
            }

            if (node.Z < -100000 || node.Z > 100000)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Z", "-100000", "100000"), new[] { "Z" }));
            }

            if (node.Code < 0 || node.Code > 20)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Code", "0", "20"), new[] { "Code" }));
            }

            if (node.Value < -1 || node.Value > -1)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes._ValueShouldBeBetween_And_, "Value", "-1", "-1"), new[] { "Value" }));
            }

                //CSSPError: Type not implemented [ElementList] of type [List`1]

                //CSSPError: Type not implemented [ElementList] of type [Element]
                //CSSPError: Type not implemented [ConnectNodeList] of type [List`1]

                //CSSPError: Type not implemented [ConnectNodeList] of type [Node]
            return ValidationResults.Count == 0 ? true : false;
        }
        #endregion Functions public
    }

}
