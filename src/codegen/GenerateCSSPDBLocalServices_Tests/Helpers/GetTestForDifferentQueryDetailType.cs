using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCSSPDBLocalServices_Tests
{
    public partial class Startup
    {
        private async Task<bool> GetTestForDifferentQueryDetailType(List<Type> types, string CountText, string TypeName, string TypeNameLower, StringBuilder sb, bool AssertDirectQuery)
        {
            sb.AppendLine(@"                        if (string.IsNullOrWhiteSpace(extra))");
            sb.AppendLine(@"                        {");
            sb.AppendLine($@"                            List<{ TypeName }> { TypeNameLower }List = new List<{ TypeName }>();");
            sb.AppendLine($@"                            { TypeNameLower }List = { TypeNameLower }Service.Get{ TypeName }List().ToList();");
            sb.AppendLine($@"                            Check{ TypeName }Fields({ TypeNameLower }List);");
            if (AssertDirectQuery)
            {
                sb.AppendLine($@"                            Assert.AreEqual({ TypeNameLower }DirectQueryList[0].{ TypeName }ID, { TypeNameLower }List[0].{ TypeName }ID);");
            }
            sb.AppendLine(@"                        }");
            List<string> ClassNameList = new List<string>() { "ExtraA", "ExtraB", "ExtraC", "ExtraD", "ExtraE" };
            foreach (string ClassName in ClassNameList)
            {
                Type currentType = null;

                foreach (Type TempType in types)
                {
                    if (TempType.Name == $"{ TypeName }{ ClassName }")
                    {
                        currentType = TempType;
                        break;
                    }
                }

                if (currentType == null)
                {
                    continue;
                }

                sb.AppendLine($@"                        else if (extra == ""{ ClassName.Substring(ClassName.Length - 1) }"")");
                sb.AppendLine(@"                        {");
                sb.AppendLine($@"                            List<{ TypeName }{ ClassName }> { TypeNameLower }{ ClassName }List = new List<{ TypeName }{ ClassName }>();");
                sb.AppendLine($@"                            { TypeNameLower }{ ClassName }List = { TypeNameLower }Service.Get{ TypeName }{ ClassName }List().ToList();");
                sb.AppendLine($@"                            Check{ TypeName }{ ClassName }Fields({ TypeNameLower }{ ClassName }List);");
                if (AssertDirectQuery)
                {
                    sb.AppendLine($@"                            Assert.AreEqual({ TypeNameLower }DirectQueryList[0].{ TypeName }ID, { TypeNameLower }{ ClassName }List[0].{ TypeName }ID);");
                }
                sb.AppendLine($@"                            Assert.AreEqual({ CountText }, { TypeNameLower }{ ClassName }List.Count);");
                sb.AppendLine(@"                        }");



            }

            sb.AppendLine(@"                        else");
            sb.AppendLine(@"                        {");
            sb.AppendLine(@"                            //Assert.AreEqual(true, false);");
            sb.AppendLine(@"                        }");

            return await Task.FromResult(true);
        }
    }
}
