namespace CSSPDesktop;

public partial class CSSPDesktopForm : Form
{
    private void butCancelUpdate_Click(object sender, EventArgs e)
    {
        StartTheAppWithLanguageAsync().GetAwaiter().GetResult();
        ShowPanels(ShowPanelEnum.Commands);
    }
    private void butClose_Click(object sender, EventArgs e)
    {
        Close();
    }
    private void butContactLoggedIn_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Login);
    }
    private void butLogoff_Click(object sender, EventArgs e)
    {
        Logoff();
    }
    private void butHideHelpPanel_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Commands);
    }
    private void butShowHelpPanel_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Help);
    }
    private void butShowLanguagePanel_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Language);
    }
    private void butSetLanguageToEnglish_Click(object sender, EventArgs e)
    {
        IsEnglish = true;
        StartTheAppWithLanguageAsync().GetAwaiter().GetResult();
    }
    private void butSetLanguageToFrancais_Click(object sender, EventArgs e)
    {
        IsEnglish = false;
        StartTheAppWithLanguageAsync().GetAwaiter().GetResult();
    }
    private void butStart_Click(object sender, EventArgs e)
    {
        Start();
    }
    private void butStop_Click(object sender, EventArgs e)
    {
        Stop();
    }
    private void butShowUpdatePanel_Click(object sender, EventArgs e)
    {
        ShowPanels(ShowPanelEnum.Updates);
        butUpdateCompleted.Visible = false;
    }
    private void butUpdate_Click(object sender, EventArgs e)
    {
        butCancelUpdate.Enabled = false;
        if (CSSPDesktopService.InstallUpdatesAsync().GetAwaiter().GetResult())
        {
            butShowUpdatePanel.Enabled = false;
        }
        butCancelUpdate.Visible = false;
        butUpdate.Visible = false;
        butUpdateCompleted.Visible = true;
    }
    private void butUpdateCompleted_Click(object sender, EventArgs e)
    {
        StartTheAppWithLanguageAsync().GetAwaiter().GetResult();

        ShowPanels(ShowPanelEnum.Commands);
        butCancelUpdate.Enabled = true;
        butCancelUpdate.Visible = true;
        butUpdate.Visible = true;
        butUpdateCompleted.Visible = false;
    }
}
