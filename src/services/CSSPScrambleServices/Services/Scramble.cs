namespace CSSPScrambleServices;

public partial class CSSPScrambleService : ICSSPScrambleService
{
    public string Scramble(string Text)
    {

        if (string.IsNullOrWhiteSpace(Text)) return "";

        Random r = new Random();
        int Start = r.Next(1, 9);

        string retStr = Start.ToString();
        int i = 0;
        foreach (char c in Text)
        {
            retStr += (char)((int)c + skip[i + Start]);
            i += 1;
        }

        string retStr2 = "";
        int length = retStr.Length - 1;
        for (int j = length; j > -1; j--)
        {
            retStr2 += retStr[j].ToString();
        }

        return retStr2;
    }
}

