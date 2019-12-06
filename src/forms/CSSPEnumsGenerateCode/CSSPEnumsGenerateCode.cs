using CSSPEnumsDLL.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSSPEnumsGenerateCode
{
    public partial class CSSPEnumsGenerateCode : Form
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPEnumsGenerateCode()
        {
            InitializeComponent();
        }
        #endregion Constructors

        #region Events
        private void butGenerateCode_Click(object sender, EventArgs e)
        {
            GenerateCode();
        }
        #endregion Events

        #region Functions public
        public void GenerateCode()
        {
            Generate_GeneratedClassEnumTextOrder_cs();
            Generate_GeneratedBaseEnumsService_cs();
            Generate_GeneratedBaseEnumServiceTest_cs();
            richTextBoxStatus.AppendText("\r\n\r\nDone ... \r\n");
            richTextBoxStatus.AppendText("\r\n\r\nYou have to recompile ... \r\n");
        }
        public void Generate_GeneratedClassEnumTextOrder_cs()
        {
            StringBuilder sb = new StringBuilder();
            FileInfo fiDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnumsDLL\bin\Debug\netcoreapp3.1\CSSPEnumsDLL.dll");
            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnumsDLL\Enums\GeneratedClassEnumTextOrder.cs");

            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"using System.Threading.Tasks;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnumsDLL.Enums");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    #region Class Enum Ordered");
            var importAssembly = System.Reflection.Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsEnum)
                {
                    string enumName = type.Name;
                    sb.AppendLine(@"    public class " + enumName + "TextOrdered");
                    sb.AppendLine(@"    {");
                    sb.AppendLine(@"        public " + enumName + "TextOrdered()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"        }");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"        public " + enumName + " " + enumName.Substring(0, enumName.Length - 4) + " { get; set; }");
                    sb.AppendLine(@"        public string " + enumName.Substring(0, enumName.Length - 4) + "Text { get; set; }");
                    sb.AppendLine(@"    }");
                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"    #endregion Class Enum Ordered");
            sb.AppendLine(@"}");


            //var importAssembly = System.Reflection.Assembly.LoadFile(fiDLL.FullName);
            //Type[] types = importAssembly.GetTypes();
            //foreach (Type type in types)
            //{
            //    if (type.IsEnum)
            //    {
            //        string enumName = type.Name;
            //        richTextBoxStatus.AppendText(enumName + "\r\n");
            //        foreach (FieldInfo fieldInfo in type.GetFields())
            //        {
            //            if (fieldInfo.FieldType.IsEnum)
            //            {
            //                string fName = fieldInfo.Name;
            //                object fValue = fieldInfo.GetRawConstantValue();
            //                richTextBoxStatus.AppendText(fName + " " + fValue + "\r\n");
            //            }
            //        }
            //    }
            //}

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

        }
        public void Generate_GeneratedBaseEnumsService_cs()
        {
            StringBuilder sb = new StringBuilder();
            FileInfo fiDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnumsDLL\bin\Debug\netcoreapp3.1\CSSPEnumsDLL.dll");
            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnumsDLL\Services\GeneratedBaseEnumsService.cs");

            sb.AppendLine(@"using CSSPEnumsDLL.Enums;");
            sb.AppendLine(@"using CSSPEnumsDLL.Services.Resources;");
            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using System.Globalization;");
            sb.AppendLine(@"using System.Linq;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"using System.Threading;");
            sb.AppendLine(@"using System.Threading.Tasks;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnumsDLL.Services");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public partial class BaseEnumService");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"");

            // Doing Functions Get Enum Text
            sb.AppendLine(@"        #region Functions Get Enum Text");
            var importAssembly = System.Reflection.Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsEnum)
                {
                    string enumName = type.Name;
                    if (enumName == "PolSourceObsInfoEnum")
                        continue;

                    sb.AppendLine(@"        public string GetEnumText_" + enumName + "(" + enumName + "? " + enumName.Substring(0, 1).ToLower() + enumName.Substring(1, enumName.Length - 4) + ")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            if (" + enumName.Substring(0, 1).ToLower() + enumName.Substring(1, enumName.Length - 4) + " == null)");
                    sb.AppendLine(@"                return BaseEnumServiceRes.Empty;");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            switch (" + enumName.Substring(0, 1).ToLower() + enumName.Substring(1, enumName.Length - 4) + ")");
                    sb.AppendLine(@"            {");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        if (fieldInfo.FieldType.IsEnum)
                        {
                            string fName = fieldInfo.Name;
                            //object fValue = fieldInfo.GetRawConstantValue();
                            //richTextBoxStatus.AppendText(fName + " " + fValue + "\r\n");
                            sb.AppendLine(@"                case " + enumName + "." + fName + ":");
                            if (fName == "Error")
                            {
                                sb.AppendLine(@"                    return BaseEnumServiceRes.Empty;");
                            }
                            else
                            {
                                sb.AppendLine(@"                    return BaseEnumServiceRes." + enumName + fName + ";");
                            }
                        }
                    }
                    sb.AppendLine(@"                default:");
                    sb.AppendLine(@"                    return BaseEnumServiceRes.Empty;");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");
                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Functions Get Enum Text");

            // doing Function Get Enum Text Ordered
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Function Get Enum Text Ordered");
            importAssembly = System.Reflection.Assembly.LoadFile(fiDLL.FullName);
            types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsEnum)
                {
                    string enumName = type.Name;
                    if (enumName == "PolSourceObsInfoEnum")
                        continue;

                    sb.AppendLine(@"        public List<" + enumName + "TextOrdered> Get" + enumName + "TextOrderedList()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            List<" + enumName + "TextOrdered> " + enumName + "TextOrderedList = new List<" + enumName + "TextOrdered>();");
                    sb.AppendLine(@"");
                    if (enumName == "SampleTypeEnum")
                    {
                        sb.AppendLine(@"            for (int i = 101, count = Enum.GetNames(typeof(" + enumName + ")).Count() + 100; i < count; i++)");
                    }
                    else
                    {
                        sb.AppendLine(@"            for (int i = 1, count = Enum.GetNames(typeof(" + enumName + ")).Count(); i < count; i++)");
                    }
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                " + enumName + "TextOrderedList.Add(new " + enumName + "TextOrdered() { " + enumName.Substring(0, enumName.Length - 4) + " = (" + enumName + ")i, " + enumName.Substring(0, enumName.Length - 4) + "Text = GetEnumText_" + enumName + "((" + enumName + ")i) });");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            " + enumName + "TextOrderedList = (from c in " + enumName + "TextOrderedList");
                    sb.AppendLine(@"                                              orderby c." + enumName.Substring(0, enumName.Length - 4) + "Text");
                    sb.AppendLine(@"                                              select c).ToList();");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            return " + enumName + "TextOrderedList;");
                    sb.AppendLine(@"        }");
                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Function Get Enum Text Ordered");


            // doing Enum CheckOK
            sb.AppendLine(@"");
            sb.AppendLine(@"        #region Enum CheckOK");
            importAssembly = System.Reflection.Assembly.LoadFile(fiDLL.FullName);
            types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsEnum)
                {
                    string enumName = type.Name;
                    if (enumName == "PolSourceObsInfoEnum")
                        continue;

                    sb.AppendLine(@"        public string " + enumName.Substring(0, enumName.Length - 4) + "OK(" + enumName + "? " + enumName.Substring(0, 1).ToLower() + enumName.Substring(1, enumName.Length - 5) + ")");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            if (" + enumName.Substring(0, 1).ToLower() + enumName.Substring(1, enumName.Length - 5) + " == null)");
                    sb.AppendLine(@"                return """";");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"            switch ((" + enumName + ")" + enumName.Substring(0, 1).ToLower() + enumName.Substring(1, enumName.Length - 5) + ")");
                    sb.AppendLine(@"            {");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        if (fieldInfo.FieldType.IsEnum)
                        {
                            string fName = fieldInfo.Name;
                            //object fValue = fieldInfo.GetRawConstantValue();
                            //richTextBoxStatus.AppendText(fName + " " + fValue + "\r\n");
                            sb.AppendLine(@"                case " + enumName + "." + fName + ":");
                        }
                    }
                    sb.AppendLine(@"                    return """";");
                    sb.AppendLine(@"                default:");
                    sb.AppendLine(@"                    return string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes." + enumName.Substring(0, enumName.Length - 4) + ");");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");
                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Enum CheckOK");
            sb.AppendLine(@"");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");


            //var importAssembly = System.Reflection.Assembly.LoadFile(fiDLL.FullName);
            //Type[] types = importAssembly.GetTypes();
            //foreach (Type type in types)
            //{
            //    if (type.IsEnum)
            //    {
            //        string enumName = type.Name;
            //        richTextBoxStatus.AppendText(enumName + "\r\n");
            //        foreach (FieldInfo fieldInfo in type.GetFields())
            //        {
            //            if (fieldInfo.FieldType.IsEnum)
            //            {
            //                string fName = fieldInfo.Name;
            //                object fValue = fieldInfo.GetRawConstantValue();
            //                richTextBoxStatus.AppendText(fName + " " + fValue + "\r\n");
            //            }
            //        }
            //    }
            //}

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

        }
        public void Generate_GeneratedBaseEnumServiceTest_cs()
        {
            StringBuilder sb = new StringBuilder();
            FileInfo fiDLL = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPEnumsDLL\bin\Debug\netcoreapp3.1\CSSPEnumsDLL.dll");
            FileInfo fi = new FileInfo(@"C:\CSSPTools\src\tests\CSSPEnumsDLL.Tests\Services\GeneratedBaseEnumServiceTest.cs");

            sb.AppendLine(@"using System;");
            sb.AppendLine(@"using System.Text;");
            sb.AppendLine(@"using System.Collections.Generic;");
            sb.AppendLine(@"using Microsoft.VisualStudio.TestTools.UnitTesting;");
            sb.AppendLine(@"using CSSPEnumsDLL.Tests.SetupInfo;");
            sb.AppendLine(@"using System.Globalization;");
            sb.AppendLine(@"using System.Threading;");
            sb.AppendLine(@"using CSSPEnumsDLL.Services;");
            sb.AppendLine(@"using CSSPEnumsDLL.Services.Resources;");
            sb.AppendLine(@"using CSSPEnumsDLL.Enums;");
            sb.AppendLine(@"");
            sb.AppendLine(@"namespace CSSPEnumsDLL.Tests.Services");
            sb.AppendLine(@"{");
            sb.AppendLine(@"    public partial class BaseEnumServiceTest : SetupData");
            sb.AppendLine(@"    {");
            sb.AppendLine(@"");

            // Doing Testing Methods GetEnumText public
            sb.AppendLine(@"        #region Testing Methods GetEnumText public");
            var importAssembly = System.Reflection.Assembly.LoadFile(fiDLL.FullName);
            Type[] types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsEnum)
                {
                    string enumName = type.Name;
                    if (enumName == "PolSourceObsInfoEnum")
                        continue;

                    sb.AppendLine(@"        [TestMethod]");
                    sb.AppendLine(@"        public void BaseEnumService_GetEnumText_" + enumName + "_Test()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            foreach (CultureInfo culture in setupData.cultureListGood)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                SetupTest(culture);");
                    sb.AppendLine(@"        ");
                    sb.AppendLine(@"                string retStr = baseEnumService.GetEnumText_" + enumName + "(null);");
                    sb.AppendLine(@"                Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);");
                    sb.AppendLine(@"        ");
                    sb.AppendLine(@"                for (int i = 0, count = Enum.GetNames(typeof(" + enumName + ")).Length; i < count; i++)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    retStr = baseEnumService.GetEnumText_" + enumName + "((" + enumName + ")i);");
                    sb.AppendLine(@"        ");
                    sb.AppendLine(@"                    switch ((" + enumName + ")i)");
                    sb.AppendLine(@"                    {");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        if (fieldInfo.FieldType.IsEnum)
                        {
                            string fName = fieldInfo.Name;
                            //object fValue = fieldInfo.GetRawConstantValue();
                            //richTextBoxStatus.AppendText(fName + " " + fValue + "\r\n");
                            sb.AppendLine(@"                        case " + enumName + "." + fName + ":");
                            if (fName == "Error")
                            {
                                sb.AppendLine(@"                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);");
                                sb.AppendLine(@"                            break;");
                            }
                            else
                            {
                                sb.AppendLine(@"                            Assert.AreEqual(BaseEnumServiceRes." + enumName + fName + ", retStr);");
                                sb.AppendLine(@"                            break;");
                            }
                        }
                    }
                    sb.AppendLine(@"                        default:");
                    sb.AppendLine(@"                            Assert.AreEqual(BaseEnumServiceRes.Empty, retStr);");
                    sb.AppendLine(@"                            break;");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Testing Methods GetEnumText public");
            sb.AppendLine(@"");


            // Doing Testing Methods Check OK public
            sb.AppendLine(@"        #region Testing Methods Check OK public");
            importAssembly = System.Reflection.Assembly.LoadFile(fiDLL.FullName);
            types = importAssembly.GetTypes();
            foreach (Type type in types)
            {
                if (type.IsEnum)
                {
                    string enumName = type.Name;
                    if (enumName == "PolSourceObsInfoEnum")
                        continue;

                    sb.AppendLine(@"        [TestMethod]");
                    sb.AppendLine(@"        public void BaseEnumService_" + enumName.Substring(0, enumName.Length - 4) + "OK_Test()");
                    sb.AppendLine(@"        {");
                    sb.AppendLine(@"            foreach (CultureInfo culture in setupData.cultureListGood)");
                    sb.AppendLine(@"            {");
                    sb.AppendLine(@"                SetupTest(culture);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                string retStr = baseEnumService." + enumName.Substring(0, enumName.Length - 4) + "OK(null);");
                    sb.AppendLine(@"                Assert.AreEqual("""", retStr);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                for (int i = 0, count = Enum.GetNames(typeof(" + enumName + ")).Length; i < count; i++)");
                    sb.AppendLine(@"                {");
                    sb.AppendLine(@"                    retStr = baseEnumService." + enumName.Substring(0, enumName.Length - 4) + "OK((" + enumName + ")i);");
                    sb.AppendLine(@"");
                    sb.AppendLine(@"                    switch ((" + enumName + ")i)");
                    sb.AppendLine(@"                    {");
                    foreach (FieldInfo fieldInfo in type.GetFields())
                    {
                        if (fieldInfo.FieldType.IsEnum)
                        {
                            string fName = fieldInfo.Name;
                            //object fValue = fieldInfo.GetRawConstantValue();
                            //richTextBoxStatus.AppendText(fName + " " + fValue + "\r\n");
                            sb.AppendLine(@"                        case " + enumName + "." + fName + ":");
                        }
                    }
                    sb.AppendLine(@"                            Assert.AreEqual("""", retStr);");
                    sb.AppendLine(@"                            break;");
                    sb.AppendLine(@"                        default:");
                    sb.AppendLine(@"                            Assert.AreEqual(string.Format(BaseEnumServiceRes._IsRequired, BaseEnumServiceRes." + enumName.Substring(0, enumName.Length - 4) + "), retStr);");
                    sb.AppendLine(@"                            break;");
                    sb.AppendLine(@"                    }");
                    sb.AppendLine(@"                }");
                    sb.AppendLine(@"            }");
                    sb.AppendLine(@"        }");

                }
            }
            sb.AppendLine(@"");
            sb.AppendLine(@"        #endregion Testing Methods Check OK public");
            sb.AppendLine(@"    }");
            sb.AppendLine(@"}");



            //var importAssembly = System.Reflection.Assembly.LoadFile(fiDLL.FullName);
            //Type[] types = importAssembly.GetTypes();
            //foreach (Type type in types)
            //{
            //    if (type.IsEnum)
            //    {
            //        string enumName = type.Name;
            //        richTextBoxStatus.AppendText(enumName + "\r\n");
            //        foreach (FieldInfo fieldInfo in type.GetFields())
            //        {
            //            if (fieldInfo.FieldType.IsEnum)
            //            {
            //                string fName = fieldInfo.Name;
            //                object fValue = fieldInfo.GetRawConstantValue();
            //                richTextBoxStatus.AppendText(fName + " " + fValue + "\r\n");
            //            }
            //        }
            //    }
            //}

            StreamWriter sw = fi.CreateText();
            sw.Write(sb.ToString());
            sw.Close();

        }
        #endregion Funtions public
    }
}
