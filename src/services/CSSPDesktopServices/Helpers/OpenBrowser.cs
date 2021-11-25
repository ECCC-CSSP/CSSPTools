namespace CSSPDesktopServices.Services;

public partial class CSSPDesktopService : ICSSPDesktopService
{
    private bool OpenBrowser()
    {
        //string culture = "fr-CA";
        //if (IsEnglish)
        //{
        //    culture = "en-CA";
        //}

        AppendStatus(new AppendEventArgs(string.Format(CSSPCultureDesktopRes.Executing_, $"{ Configuration["CSSPLocalUrl"] }/")));

        ProcessStartInfo processStartInfo = new ProcessStartInfo();
        processStartInfo.FileName = $"{ Configuration["CSSPLocalUrl"] }";
        //processStartInfo.FileName = $"{ CSSPLocalUrl }{ culture }/";
        processStartInfo.Arguments = "";
        processStartInfo.UseShellExecute = true;
        processBrowser = Process.Start(processStartInfo);

        return true;
    }
}

