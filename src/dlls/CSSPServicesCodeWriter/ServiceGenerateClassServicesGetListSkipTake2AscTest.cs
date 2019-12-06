﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using CSSPModels;
using CSSPEnums;
using CSSPServices;
using CSSPGenerateCodeBase;

namespace CSSPServicesGenerateCodeHelper
{
    public partial class ServicesCodeWriter
    {
        private void GenerateGetListSkipTake2AscTestCode(string TypeName, string TypeNameLower, Type type, List<Type> types, StringBuilder sb)
        {
            sb.AppendLine($@"        #region Tests Generated for Get{ TypeName }List() Skip Take 2 Asc");
            sb.AppendLine(@"        [TestMethod]");
            sb.AppendLine($@"        public void Get{ TypeName }List_Skip_Take_2Asc_Test()");
            sb.AppendLine(@"        {");
            sb.AppendLine(@"            foreach (CultureInfo culture in AllowableCulture)");
            sb.AppendLine(@"            {");
            sb.AppendLine(@"                ChangeCulture(culture);");
            sb.AppendLine(@"");
            sb.AppendLine(@"                using (CSSPDBContext dbTestDB = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))");
            sb.AppendLine(@"                {");
            sb.AppendLine($@"                    { TypeName }Service { TypeNameLower }Service = new { TypeName }Service(new Query() {{ Lang = culture.TwoLetterISOLanguageName }}, dbTestDB, ContactID);");
            sb.AppendLine(@"");
            string PropName2 = type.GetProperties().Skip(1).Take(1).FirstOrDefault().Name;
            sb.AppendLine($@"                    { TypeNameLower }Service.Query = { TypeNameLower }Service.FillQuery(typeof({ TypeName }), culture.TwoLetterISOLanguageName, 1, 1, ""{ TypeName }ID,{ PropName2 }"", """", """");");
            sb.AppendLine(@"");
            sb.AppendLine($@"                    List<{ TypeName }> { TypeNameLower }DirectQueryList = new List<{ TypeName }>();");
            if (TypeName == "Address")
            {
                sb.AppendLine($@"                    { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }es select c).OrderBy(c => c.{ TypeName }ID).ThenBy(c => c.{ PropName2 }).Skip(1).Take(1).ToList();");
            }
            else
            {
                sb.AppendLine($@"                    { TypeNameLower }DirectQueryList = (from c in dbTestDB.{ TypeName }s select c).OrderBy(c => c.{ TypeName }ID).ThenBy(c => c.{ PropName2 }).Skip(1).Take(1).ToList();");
            }
            sb.AppendLine(@"");
            string countText = $"{ TypeNameLower }DirectQueryList.Count";
            GetTestForDifferentQueryDetailType(types, countText, TypeName, TypeNameLower, sb, true);
            sb.AppendLine(@"                }");
            sb.AppendLine(@"            }");
            sb.AppendLine(@"        }");
            sb.AppendLine($@"        #endregion Tests Generated for Get{ TypeName }List() Skip Take 2 Asc");
            sb.AppendLine(@"");
        }
    }
}
