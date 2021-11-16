/*
 * Manually edited
 *
 */

using System;
using System.Collections.Generic;

namespace CSSPScrambleServices
{
    public partial interface ICSSPScrambleService
    {
        string Descramble(string Text);
        string Scramble(string Text);
    }
    public partial class CSSPScrambleService : ICSSPScrambleService
    {
        #region Variables
        #endregion Variables

        #region Properties
        private List<int> skip { get; set; } = new List<int>()
        {
            3, 1, -3, 2, 2, 0, 4, 1, -2, 2, -1, 3, -2, 0, 1, 3, 1, 2, -4, -1, 1, 2, 0, 2, 1,
            -1, 4, -4, 2, 3, 1, 2, 3, 1, 2, 3, 1, 3, 1, -2, -1, -1, 4, -2, 2, -3, 2, 2, 0, 4,
            3, 1, 1, -2, -1, 3, -2, 0, 3, 2, 0, 1, 4, 1, 1, -4, -1, 2, 0, 2, 1, -3, 2, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, 2, 1,
            -2, 3, 1, -3, 2, 3, -2, -1, 4, 1, -2, 2, 2, -1, 0, 4, 1, -2, -1, 3, -2, 0, 3, -1, 1, -4, -1, 2, 0, 2, 1,
            -1, 2, 3, 2, 1, -3, 2, 3, 2, 0, 4, 1, 2, -2, -1, 0, 3, -2, 0, 3, 1, -4, -1, 3, 2, 0, 2, 1,
            -4, 3, 1, -3, 1, 2, 2, 0, 1, 2, 4, 1, -1, 3, -1, -2, -1, 3, -2, 0, 3, 1, -4, -1, 2, 0, -1, 2, 1,
            1, 3, 4, 1, -3, -2, 2, 2, 0, -1, 4, 1, -2, -1, 3, 2, -2, 0, 1, 3, 1, -2, -4, -1, -1, 2, 0, 2, 1,
            4, 3, -2, -1, 2, 0, 2, -1, 4, 2, 0, 1, -1, -1, -3, -2, 2, -4, 3, 2, 1, -3, 2, -1, 2, 4, 0, 0, 1,
            2, 1, -2, -4, 1, 3, -3, 1, -1, 2, 1, 0, 4, -1, 1, -1, -3, 1, 1, -3, -4, 1, -3, 1, -3, 1, -1, 0,
            4, 2, 1, -3, 1, -2, 1, -4, 1, -2, 0, 3, -1, 4, 1, -2, 1, 0, -4, -1, -3, 2, 1, 4, -1, 1, 2, 4, 2
        };

        #endregion Properties

        #region Constructors
        public CSSPScrambleService()
        {
        }
        #endregion Constructors

        #region Functions public 
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
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
