/*
 * Auto generated from the CSSPCodeWriter.proj by clicking on the [Generated\IEnumsGenerated.cs] button
 *
 * Do not edit this file.
 *
 */ 
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace CSSPEnums
{
    partial interface IEnums
    {
        void SetResourcesCulture(CultureInfo culture);
        string EnumTypeListOK(Type type, List<int?> intList);
        string EnumTypeOK(Type type, int? ID);
        List<EnumIDAndText> GetEnumTextOrderedList(Type type);
        string GetResValueForTypeAndID(Type type, int? ID, PolSourceObsInfoTypeEnum? polSourceObsInfoTypeEnum = null);
    }

}
