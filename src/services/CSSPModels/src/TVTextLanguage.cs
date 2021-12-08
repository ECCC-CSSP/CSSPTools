namespace CSSPModels;

[NotMapped]
public partial class TVTextLanguage
{
    public string TVText { get; set; }
    [CSSPEnumType]
    public LanguageEnum Language { get; set; }
    [CSSPMaxLength(100)]
    [CSSPEnumTypeText(EnumTypeName = "LanguageEnum", EnumType = "Language")]
    [CSSPAllowNull]
    public string LanguageText { get; set; }

    public TVTextLanguage() : base()
    {
    }
}

