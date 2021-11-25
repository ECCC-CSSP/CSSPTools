namespace CSSPLogServices;

public partial class CSSPLogService : ControllerBase, ICSSPLogService
{
    public string Descramble(string Text)
    {
        string retStr = "";
        if (string.IsNullOrWhiteSpace(Text)) return "";

        string retStr2 = "";
        int length = Text.Length - 1;
        for (int j = length; j > -1; j--)
        {
            retStr2 += Text[j].ToString();
        }

        Text = retStr2;

        int Start = int.Parse(Text.Substring(0, 1));

        Text = Text.Substring(1);
        int i = 0;
        foreach (char c in Text)
        {
            retStr += (char)((int)c - skip[i + Start]);
            i += 1;
        }

        return retStr;
    }
}

