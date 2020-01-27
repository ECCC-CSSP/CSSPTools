using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CSSPModelsGenerateCodeHelper
{
    public partial class ModelsCodeWriter
    {
        #region Functions public
        /// <summary>
        /// Generates:
        ///     C:\CSSPTools\src\dlls\CSSPModels\Resources\CSSPModelsRes.resx file
        ///     C:\CSSPTools\src\dlls\CSSPModels\Resources\CSSPModelsRes.fr.resx file
        /// 
        /// Requires:
        ///     C:\CSSPTools\src\dlls\CSSPModels\bin\Debug\netcoreapp3.1\CSSPModels.dll
        /// </summary>
        public void CSSPModelsRes()
        {
            ClearPermanentEvent(new StatusEventArgs(""));

            foreach (string lang in new List<string>() { "", "fr" })
            {
                StringBuilder sb = new StringBuilder();

                ResxTopPart(sb);
                ResxManual(sb, lang);
                //ResxDLL(sb);

                sb.AppendLine(@"</root>");

                if (lang == "fr")
                {
                    FileInfo fiOutput = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\Resources\CSSPModelsRes.fr.resx");

                    using (StreamWriter sw = fiOutput.CreateText())
                    {
                        sw.Write(sb.ToString());
                    }
                }
                else
                {
                    FileInfo fiOutput = new FileInfo(@"C:\CSSPTools\src\dlls\CSSPModels\Resources\CSSPModelsRes.resx");

                    using (StreamWriter sw = fiOutput.CreateText())
                    {
                        sw.Write(sb.ToString());
                    }

                }
            }

            StatusPermanentEvent(new StatusEventArgs("Files: "));
            StatusPermanentEvent(new StatusEventArgs(@"C:\CSSPTools\src\dlls\CSSPModels\Resources\Generated\CSSPModelsRes.resx"));
            StatusPermanentEvent(new StatusEventArgs(@"C:\CSSPTools\src\dlls\CSSPModels\Resources\Generated\CSSPModelsRes.fr.resx"));
            StatusPermanentEvent(new StatusEventArgs("were created"));

            StatusTempEvent(new StatusEventArgs("Done ..."));
        }
        #endregion Functions public
    }
}
