using System;

namespace GenerateCodeBaseHelper
{
    public static partial class GenerateCodeBase
    {
        public static bool SkipType(Type type)
        {
            if (type.Name.StartsWith("<")
                || type.Name.StartsWith("Application")
                || type.Name.StartsWith("BaseModel")
                || type.Name.StartsWith("ApplicationDBContext")
                || type.Name.StartsWith("ApplicationUser")
                || type.Name.StartsWith("CSSPDBBaseContext")
                || type.Name.StartsWith("CSSPDBCommandLogContext")
                || type.Name.StartsWith("CSSPDBSearchContext")
                || type.Name.StartsWith("CSSPDBContext")
                || type.Name.StartsWith("CSSPDBLocalContext")
                || type.Name.StartsWith("CSSPDBFilesManagementContext")
                || type.Name.StartsWith("CSSPDBLocalContext")
                || type.Name.StartsWith("CSSPDBLoginContext")
                || type.Name.StartsWith("TestDBContext")
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
                || type.Name.StartsWith("CSSPFile")
                || type.Name.StartsWith("ErrRes")
                //|| type.Name.StartsWith("Web")
                )
            {
                return true;
            }

            return false;
        }
    }
}
