/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [[ClassName]ServiceGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 

using CSSPEnums;
using CSSPModels;
using CSSPModels.Resources;
using CSSPServices.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class NodeService : BaseService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public NodeService(Query query, CSSPDBContext db, int ContactID)
            : base(query, db, ContactID)
        {
        }
        #endregion Constructors

        #region Validation
        private IEnumerable<ValidationResult> Validate(ValidationContext validationContext, ActionDBTypeEnum actionDBType)
        {
            string retStr = "";
            Enums enums = new Enums(LanguageRequest);
            Node node = validationContext.ObjectInstance as Node;
            node.HasErrors = false;

            if (node.ID < 1 || node.ID > 1000000)
            {
                node.HasErrors = true;
                yield return new ValidationResult(string.Format(CSSPServicesRes._ValueShouldBeBetween_And_, "ID", "1", "1000000"), new[] { "ID" });
            }

            //X has no Range Attribute

            //Y has no Range Attribute

            //Z has no Range Attribute

            //Code has no Range Attribute

            //Value has no Range Attribute

                //CSSPError: Type not implemented [ElementList] of type [List`1]

                //CSSPError: Type not implemented [ElementList] of type [Element]
                //CSSPError: Type not implemented [ConnectNodeList] of type [List`1]

                //CSSPError: Type not implemented [ConnectNodeList] of type [Node]
            retStr = ""; // added to stop compiling CSSPError
            if (retStr != "") // will never be true
            {
                node.HasErrors = true;
                yield return new ValidationResult("AAA", new[] { "AAA" });
            }

        }
        #endregion Validation

    }
}
