//namespace CSSPDesktop;

//public partial class CSSPDesktopForm : Form 
//{
//    #region LoginAsync
//    private async Task<bool> LoginAsync()
//    {
//        LoginModel loginModel = new LoginModel()
//        {
//            LoginEmail = textBoxLoginEmailLogin.Text.Trim(),
//            Password = textBoxPasswordLogin.Text.Trim(),
//        };

//        if (!await CSSPDesktopService.LoginAsync(loginModel)) return await Task.FromResult(false);
//        if (!await StartTheAppWithLanguageAsync()) return await Task.FromResult(false);

//        return await Task.FromResult(true);
//    }
//    #endregion LoginAsync
//}