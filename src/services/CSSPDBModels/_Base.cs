namespace CSSPDBModels;

public partial class LastUpdate //: CSSPError
{
    /// <summary>
    /// > [!NOTE]
    /// > <para>**Other custom attributes**</para>
    /// > <para>[[CSSPAfter](CSSPDBModels.CSSPAfterAttribute.html)(Year = 1980)]</para>
    /// </summary>
    /// <param name="LastUpdateDate_UTC">Every table within the database contains a field called LastUpdateDate_UTC which holds the last time the row of information was changed</param>
    [CSSPAfter(Year = 1980)]
    public DateTime LastUpdateDate_UTC { get; set; }
    /// <summary>
    /// > [!NOTE]
    /// > <para>**Other custom attributes**</para>
    /// > <para>**AllowableTVTypeList is of type [CSSPEnums.TVTypeEnum](CSSPEnums.TVTypeEnum.html)**</para>
    /// > <para>5 == Contact</para>
    /// > <para>[[CSSPExist](CSSPDBModels.CSSPExistAttribute.html)(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]</para>
    /// </summary>
    /// <param name="LastUpdateContactTVItemID">Every table within the database contains a field called LastUpdateContactTVItemID which holds the TVItemID of the last person who changed the row of information</param>
    [CSSPExist(ExistTypeName = "TVItem", ExistPlurial = "s", ExistFieldID = "TVItemID", AllowableTVTypeList = "5")]
    public int LastUpdateContactTVItemID { get; set; }

    public LastUpdate()
    {

    }
}


