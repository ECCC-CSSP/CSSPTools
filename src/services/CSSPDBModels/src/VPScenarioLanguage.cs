namespace CSSPDBModels;

public partial class VPScenarioLanguage : LastUpdate
{
    public int VPScenarioLanguageID { get; set; }
    [CSSPEnumType]
    public DBCommandEnum DBCommand { get; set; }
    [CSSPExist(ExistTypeName = "VPScenario", ExistPlurial = "s", ExistFieldID = "VPScenarioID")]
    [CSSPForeignKey(TableName = "VPScenarios", FieldName = "VPScenarioID")]
    public int VPScenarioID { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPMaxLength(100)]
    public string VPScenarioName { get; set; }
    [CSSPEnumType]
    public TranslationStatusEnum TranslationStatus { get; set; }

    public VPScenarioLanguage() : base()
    {
    }
}

