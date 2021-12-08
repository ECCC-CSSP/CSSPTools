namespace CSSPModels;

[NotMapped]
public partial class FileItemList
{
    [CSSPMaxLength(255)]
    [CSSPMinLength(1)]
    public string Text { get; set; }
    [CSSPMaxLength(255)]
    [CSSPMinLength(1)]
    public string FileName { get; set; }

    public FileItemList() : base()
    {
    }
}

