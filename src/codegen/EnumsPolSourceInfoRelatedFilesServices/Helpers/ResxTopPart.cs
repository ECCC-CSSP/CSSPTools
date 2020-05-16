﻿using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EnumsPolSourceInfoRelatedFilesServices.Services
{
    public partial class EnumsPolSourceInfoRelatedFilesService : IEnumsPolSourceInfoRelatedFilesService
    {
        #region Variables
        #endregion Variables

        #region Constructors
        #endregion Constructors

        #region Functions public
        #endregion Functions public

        #region Functions private
        private async Task<bool> ResxTopPart(StringBuilder sb)
        {
            sb.AppendLine(@"<?xml version=""1.0"" encoding=""utf-8""?>");
            sb.AppendLine(@"<root>");
            sb.AppendLine(@"  <!-- ");
            sb.AppendLine(@"    Auto generated from the PolSourceGroupingGenerateCode.proj ");
            sb.AppendLine(@"     ");
            sb.AppendLine(@"    Do not edit this file. ");
            sb.AppendLine(@"     ");
            sb.AppendLine(@"    Last generated");
            sb.AppendLine(@"     ");
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

            return await Task.FromResult(true);
        }
        #endregion Functions private
    }
}