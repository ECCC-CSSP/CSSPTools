using System;

namespace CSSPUpdateAll
{
    public partial class Startup
    {
        private void LogError(string ErrorText)
        {
            Console.WriteLine($"\r{ErrorText}");
            sbError.AppendLine(ErrorText);
        }
        private void LogAction(string ActionText)
        {
            Console.WriteLine($"\r{ActionText}");
            sbError.AppendLine(ActionText);
        }
    }
}
