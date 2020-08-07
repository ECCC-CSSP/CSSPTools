using CSSPCultureServices.Resources;
using CSSPDesktopServices.Models;
using CSSPModels;
using CSSPServices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.SignalR;

namespace CSSPDesktopServices.Services
{
    public partial class CSSPDesktopService : ICSSPDesktopService
    {
        #region Properties
        #endregion Properties

        #region Functions private
        public string DoDescramble(string Text)
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
        #endregion Functions private
    }
}
