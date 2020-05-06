using GenerateCodeBase.Models;
using GenerateCodeBase.Services;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Services;
using Microsoft.Extensions.Configuration;
using ModelsCSSPModelsResServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ModelsCSSPModelsResServices.Services
{
    public class ModelsCSSPModelsResService : IModelsCSSPModelsResService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private IConfiguration configuration { get; set; }
        private IGenerateCodeStatusDBService generateCodeStatusDBService { get; set; }
        private IValidateAppSettingsService validateAppSettingsService { get; set; }
        private IGenerateCodeBaseService generateCodeBaseService { get; set; }
        private List<string> AllowableCultures { get; set; } = new List<string>() { "en-CA", "fr-CA" };
        #endregion Properties

        #region Constructors
        public ModelsCSSPModelsResService(IConfiguration configuration,
            IGenerateCodeStatusDBService generateCodeStatusDBService,
            IValidateAppSettingsService validateAppSettingsService,
            IGenerateCodeBaseService generateCodeBaseService)
        {
            this.configuration = configuration;
            this.generateCodeStatusDBService = generateCodeStatusDBService;
            this.validateAppSettingsService = validateAppSettingsService;
            this.generateCodeBaseService = generateCodeBaseService;
        }
        #endregion Constructors

        #region Functions public
        public async Task<bool> Run(string[] args)
        {
            SetCulture(args);

            ConsoleWriteStart();

            if (!await Setup()) return false;

            if (!await Generate()) return false;

            await ConsoleWriteEnd();

            return true;
        }
        #endregion Functions public

        #region Functions private
        private async Task<bool> Generate()
        {
            GenerateCodeStatus generateCodeStatus = await generateCodeStatusDBService.GetOrCreate();

            if (generateCodeStatus == null)
            {
                await ConsoleWriteError("generateCodeStatus == null");
                return false;
            }

            generateCodeStatusDBService.Status.AppendLine("Generate Starting ...");
            await generateCodeStatusDBService.Update(10);

            foreach (string lang in new List<string>() { "", "fr" })
            {
                StringBuilder sb = new StringBuilder();

                ResxTopPart(sb);
                ResxManual(sb, lang);
                //ResxDLL(sb);

                sb.AppendLine(@"</root>");

                if (lang == "fr")
                {
                    FileInfo fiOutput = new FileInfo(configuration.GetValue<string>("CSSPModelsResFR"));

                    using (StreamWriter sw = fiOutput.CreateText())
                    {
                        sw.Write(sb.ToString());
                    }

                    generateCodeStatusDBService.Status.AppendLine($"{ string.Format(AppRes.Created_, fiOutput.FullName) }");
                }
                else
                {
                    FileInfo fiOutput = new FileInfo(configuration.GetValue<string>("CSSPModelsRes"));

                    using (StreamWriter sw = fiOutput.CreateText())
                    {
                        sw.Write(sb.ToString());
                    }

                    generateCodeStatusDBService.Status.AppendLine($"{ string.Format(AppRes.Created_, fiOutput.FullName) }");
                }
            }

            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine("Generate Finished ...");
            await generateCodeStatusDBService.Update(100);

            return true;
        }
        private async Task ConsoleWriteEnd()
        {
            generateCodeStatusDBService.Status.AppendLine("");
            generateCodeStatusDBService.Status.AppendLine($"{ AppRes.Done } ...");
            generateCodeStatusDBService.Status.AppendLine("");
            await generateCodeStatusDBService.Update(100);

            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            }

            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }
        private async Task ConsoleWriteError(string errMessage)
        {
            generateCodeStatusDBService.Error.AppendLine(errMessage);
            await generateCodeStatusDBService.Update(0);
            Console.WriteLine(generateCodeStatusDBService.Error.ToString());
            Console.WriteLine(generateCodeStatusDBService.Status.ToString());
        }
        private void ResxManual(StringBuilder sb, string lang)
        {
            sb.AppendLine(@"<data name=""___DoNotWriteInThisDocument"" xml:space=""preserve"">");
            if (lang == "fr")
            {
                sb.AppendLine(@"  <value>Do not write in this document. Use the ResxManual in the ModelsResManual.cs files</value>");
            }
            else
            {
                sb.AppendLine(@"  <value>SVP ne pas écrire dans ce document. SVP utiliser ResxManual dans le document ModelResManual.cs</value>");
            }
            sb.AppendLine(@"</data>");

            sb.AppendLine(@"<data name=""_IsRequired"" xml:space=""preserve"">");
            if (lang == "fr")
            {
                sb.AppendLine(@"  <value>{0} est requis</value>");
            }
            else
            {
                sb.AppendLine(@"  <value>{0} is required</value>");
            }
            sb.AppendLine(@"</data>");

            sb.AppendLine(@"<data name=""AspNetUser"" xml:space=""preserve"">");
            if (lang == "fr")
            {
                sb.AppendLine(@"  <value>AspNetUser</value>");
            }
            else
            {
                sb.AppendLine(@"  <value>AspNetUser</value>");
            }
            sb.AppendLine(@"</data>");
        }
        private void ResxTopPart(StringBuilder sb)
        {
            sb.AppendLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            sb.AppendLine(@"<root>");
            sb.AppendLine(@"  <!-- ");
            sb.AppendLine(@"    Microsoft ResX Schema ");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"    Version 2.0");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"    The primary goals of this format is to allow a simple XML format ");
            sb.AppendLine(@"    that is mostly human readable. The generation and parsing of the ");
            sb.AppendLine(@"    various data types are done through the TypeConverter classes ");
            sb.AppendLine(@"    associated with the data types.");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"    Example:");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"    ... ado.net/XML headers & schema ...");
            sb.AppendLine(@"    <resheader name=""resmimetype"">text/microsoft-resx</resheader>");
            sb.AppendLine(@"    <resheader name=""version"">2.0</resheader>");
            sb.AppendLine(@"    <resheader name=""reader"">System.Resources.ResXResourceReader, System.Windows.Forms, ...</resheader>");
            sb.AppendLine(@"    <resheader name=""writer"">System.Resources.ResXResourceWriter, System.Windows.Forms, ...</resheader>");
            sb.AppendLine(@"    <data name=""Name1""><value>this is my long string</value><comment>this is a comment</comment></data>");
            sb.AppendLine(@"    <data name=""Color1"" type=""System.Drawing.Color, System.Drawing"">Blue</data>");
            sb.AppendLine(@"    <data name=""Bitmap1"" mimetype=""application/x-microsoft.net.object.binary.base64"">");
            sb.AppendLine(@"        <value>[base64 mime encoded serialized .NET Framework object]</value>");
            sb.AppendLine(@"    </data>");
            sb.AppendLine(@"    <data name=""Icon1"" type=""System.Drawing.Icon, System.Drawing"" mimetype=""application/x-microsoft.net.object.bytearray.base64"">");
            sb.AppendLine(@"        <value>[base64 mime encoded string representing a byte array form of the .NET Framework object]</value>");
            sb.AppendLine(@"        <comment>This is a comment</comment>");
            sb.AppendLine(@"    </data>");
            sb.AppendLine(@"              ");
            sb.AppendLine(@"    There are any number of ""resheader"" rows that contain simple ");
            sb.AppendLine(@"    name/value pairs.");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"    Each data row contains a name, and value. The row also contains a ");
            sb.AppendLine(@"    type or mimetype. Type corresponds to a .NET class that support ");
            sb.AppendLine(@"    text/value conversion through the TypeConverter architecture. ");
            sb.AppendLine(@"    Classes that don't support this are serialized and stored with the ");
            sb.AppendLine(@"    mimetype set.");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"    The mimetype is used for serialized objects, and tells the ");
            sb.AppendLine(@"    ResXResourceReader how to depersist the object. This is currently not ");
            sb.AppendLine(@"    extensible. For a given mimetype the value must be set accordingly:");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"    Note - application/x-microsoft.net.object.binary.base64 is the format ");
            sb.AppendLine(@"    that the ResXResourceWriter will generate, however the reader can ");
            sb.AppendLine(@"    read any of the formats listed below.");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"    mimetype: application/x-microsoft.net.object.binary.base64");
            sb.AppendLine(@"    value   : The object must be serialized with ");
            sb.AppendLine(@"            : System.Runtime.Serialization.Formatters.Binary.BinaryFormatter");
            sb.AppendLine(@"            : and then encoded with base64 encoding.");
            sb.AppendLine(@"    ");
            sb.AppendLine(@"    mimetype: application/x-microsoft.net.object.soap.base64");
            sb.AppendLine(@"    value   : The object must be serialized with ");
            sb.AppendLine(@"            : System.Runtime.Serialization.Formatters.Soap.SoapFormatter");
            sb.AppendLine(@"            : and then encoded with base64 encoding.");
            sb.AppendLine(@"");
            sb.AppendLine(@"    mimetype: application/x-microsoft.net.object.bytearray.base64");
            sb.AppendLine(@"    value   : The object must be serialized into a byte array ");
            sb.AppendLine(@"            : using a System.ComponentModel.TypeConverter");
            sb.AppendLine(@"            : and then encoded with base64 encoding.");
            sb.AppendLine(@"    -->");
            sb.AppendLine(@"  <xsd:schema id=""root"" xmlns="""" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:msdata=""urn:schemas-microsoft-com:xml-msdata"">");
            sb.AppendLine(@"    <xsd:import namespace=""http://www.w3.org/XML/1998/namespace"" />");
            sb.AppendLine(@"    <xsd:element name=""root"" msdata:IsDataSet=""true"">");
            sb.AppendLine(@"      <xsd:complexType>");
            sb.AppendLine(@"        <xsd:choice maxOccurs=""unbounded"">");
            sb.AppendLine(@"          <xsd:element name=""metadata"">");
            sb.AppendLine(@"            <xsd:complexType>");
            sb.AppendLine(@"              <xsd:sequence>");
            sb.AppendLine(@"                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" />");
            sb.AppendLine(@"              </xsd:sequence>");
            sb.AppendLine(@"              <xsd:attribute name=""name"" use=""required"" type=""xsd:string"" />");
            sb.AppendLine(@"              <xsd:attribute name=""type"" type=""xsd:string"" />");
            sb.AppendLine(@"              <xsd:attribute name=""mimetype"" type=""xsd:string"" />");
            sb.AppendLine(@"              <xsd:attribute ref=""xml:space"" />");
            sb.AppendLine(@"            </xsd:complexType>");
            sb.AppendLine(@"          </xsd:element>");
            sb.AppendLine(@"          <xsd:element name=""assembly"">");
            sb.AppendLine(@"            <xsd:complexType>");
            sb.AppendLine(@"              <xsd:attribute name=""alias"" type=""xsd:string"" />");
            sb.AppendLine(@"              <xsd:attribute name=""name"" type=""xsd:string"" />");
            sb.AppendLine(@"            </xsd:complexType>");
            sb.AppendLine(@"          </xsd:element>");
            sb.AppendLine(@"          <xsd:element name=""data"">");
            sb.AppendLine(@"            <xsd:complexType>");
            sb.AppendLine(@"              <xsd:sequence>");
            sb.AppendLine(@"                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />");
            sb.AppendLine(@"                <xsd:element name=""comment"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""2"" />");
            sb.AppendLine(@"              </xsd:sequence>");
            sb.AppendLine(@"              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" msdata:Ordinal=""1"" />");
            sb.AppendLine(@"              <xsd:attribute name=""type"" type=""xsd:string"" msdata:Ordinal=""3"" />");
            sb.AppendLine(@"              <xsd:attribute name=""mimetype"" type=""xsd:string"" msdata:Ordinal=""4"" />");
            sb.AppendLine(@"              <xsd:attribute ref=""xml:space"" />");
            sb.AppendLine(@"            </xsd:complexType>");
            sb.AppendLine(@"          </xsd:element>");
            sb.AppendLine(@"          <xsd:element name=""resheader"">");
            sb.AppendLine(@"            <xsd:complexType>");
            sb.AppendLine(@"              <xsd:sequence>");
            sb.AppendLine(@"                <xsd:element name=""value"" type=""xsd:string"" minOccurs=""0"" msdata:Ordinal=""1"" />");
            sb.AppendLine(@"              </xsd:sequence>");
            sb.AppendLine(@"              <xsd:attribute name=""name"" type=""xsd:string"" use=""required"" />");
            sb.AppendLine(@"            </xsd:complexType>");
            sb.AppendLine(@"          </xsd:element>");
            sb.AppendLine(@"        </xsd:choice>");
            sb.AppendLine(@"      </xsd:complexType>");
            sb.AppendLine(@"    </xsd:element>");
            sb.AppendLine(@"  </xsd:schema>");
            sb.AppendLine(@"  <resheader name=""resmimetype"">");
            sb.AppendLine(@"    <value>text/microsoft-resx</value>");
            sb.AppendLine(@"  </resheader>");
            sb.AppendLine(@"  <resheader name=""version"">");
            sb.AppendLine(@"    <value>2.0</value>");
            sb.AppendLine(@"  </resheader>");
            sb.AppendLine(@"  <resheader name=""reader"">");
            sb.AppendLine(@"    <value>System.Resources.ResXResourceReader, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
            sb.AppendLine(@"  </resheader>");
            sb.AppendLine(@"  <resheader name=""writer"">");
            sb.AppendLine(@"    <value>System.Resources.ResXResourceWriter, System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089</value>");
            sb.AppendLine(@"  </resheader>");
        }
        private void ConsoleWriteStart()
        {
            Console.WriteLine($"{ AppRes.Running } { AppRes.Application } { AppDomain.CurrentDomain.FriendlyName }");
            Console.WriteLine("");
            Console.WriteLine($"{ AppRes.Starting } ...");
            Console.WriteLine("");
        }
        private void SetCulture(string[] args)
        {
            string culture = AllowableCultures[0];

            if (args.Count() > 0)
            {
                if (AllowableCultures.Contains(args[0]))
                {
                    culture = args[0];
                }
            }

            AppRes.Culture = new CultureInfo(culture);
        }
        private async Task<bool> Setup()
        {
            generateCodeStatusDBService.Command = configuration.GetValue<string>("Command");
            generateCodeStatusDBService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));
            validateAppSettingsService.Culture = new CultureInfo(configuration.GetValue<string>("Culture"));

            try
            {
                await generateCodeStatusDBService.GetOrCreate();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            validateAppSettingsService.AppSettingParameterList = new List<AppSettingParameter>()
            {
                new AppSettingParameter() { Parameter = "Command", ExpectedValue = "ModelsCSSPModelsRes" },
                new AppSettingParameter() { Parameter = "Culture", ExpectedValue = "", IsCulture = true },
                new AppSettingParameter() { Parameter = "DBFileName", ExpectedValue = "{AppDataPath}\\CSSP\\GenerateCodeStatus.db", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModelsRes", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\Resources\\CSSPModelsRes.resx", IsFile = true, CheckExist = true },
                new AppSettingParameter() { Parameter = "CSSPModelsResFR", ExpectedValue = "C:\\CSSPTools\\src\\dlls\\CSSPModels\\Resources\\CSSPModelsRes.fr.resx", IsFile = true, CheckExist = true },
            };

            validateAppSettingsService.VerifyAppSettings();
            if (!string.IsNullOrWhiteSpace(generateCodeStatusDBService.Error.ToString()))
            {
                await ConsoleWriteError("");
                return false;
            }

            return true;
        }
        #endregion Functions private
    }
}