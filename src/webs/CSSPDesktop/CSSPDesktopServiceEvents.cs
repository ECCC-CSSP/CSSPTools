//namespace CSSPDesktop;

//public partial class CSSPDesktopForm : Form 
//{
//    #region CSSPDesktopServiceEvents
//    private void CSSPDesktopService_StatusClear(object sender, ClearEventArgs e)
//    {
//        richTextBoxStatus.Text = "";
//        richTextBoxStatus.Refresh();
//        Application.DoEvents();
//    }
//    private void CSSPDesktopService_StatusAppend(object sender, AppendEventArgs e)
//    {
//        lblStatus.Text = e.Message;
//        lblStatus.Refresh();

//        richTextBoxStatus.AppendText(e.Message + "\r\n");
//        richTextBoxStatus.Refresh();
//        Application.DoEvents();
//    }
//    private void CSSPDesktopService_StatusInstalling(object sender, InstallingEventArgs e)
//    {
//        progressBarInstalling.Value = e.Percent;
//        progressBarInstalling.Refresh();
//        Application.DoEvents();
//    }
//    #endregion CSSPDesktopServiceEvents
//}