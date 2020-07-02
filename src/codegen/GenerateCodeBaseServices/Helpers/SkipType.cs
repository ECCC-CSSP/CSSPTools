using System;

namespace GenerateCodeBaseServices.Services
{
    public partial class GenerateCodeBaseService : IGenerateCodeBaseService
    {
        public bool SkipType(Type type)
        {
            if (type.Name.StartsWith("<")
                || type.Name.StartsWith("CSSPModelsRes")
                || type.Name.StartsWith("Application")
                || type.Name.StartsWith("CSSPDBContext")
                || type.Name.StartsWith("TestDBContext")
                || type.Name.StartsWith("InMemoryDBContext")
                || type.Name.StartsWith("CSSPAfter")
                || type.Name.StartsWith("CSSPAllowNull")
                || type.Name.StartsWith("CSSPBigger")
                || type.Name.StartsWith("CSSPCompare")
                || type.Name.StartsWith("CSSPEnumType")
                || type.Name.StartsWith("CSSPEnumTypeText")
                || type.Name.StartsWith("CSSPExist")
                || type.Name.StartsWith("CSSPFill")
                || type.Name.StartsWith("CSSPForeignKey")
                || type.Name.StartsWith("CSSPMaxLengthAttribute")
                || type.Name.StartsWith("CSSPMinLengthAttribute")
                || type.Name.StartsWith("CSSPRangeAttribute")
                || type.Name.StartsWith("CSSPRequiredAttribute")
                || type.Name.StartsWith("CSSPRegularExpressionAttribute")
                || type.Name == "LastUpdate"
                || type.Name.StartsWith("AspNet")
                || type.Name.StartsWith("Persisted")
                || type.Name.StartsWith("Device")
                )
            {
                return true;
            }

            return false;
        }
    }
}
