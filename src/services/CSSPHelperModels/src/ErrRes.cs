namespace CSSPHelperModels;

[NotMapped]
public class ErrRes
{
    public List<string> ErrList { get; set; }

    public ErrRes()
    {
        ErrList = new List<string>();
    }
}

