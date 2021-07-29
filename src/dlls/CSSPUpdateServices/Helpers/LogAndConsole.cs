using CSSPCultureServices.Resources;
using ManageServices;
using System;
using System.Text;
using System.Threading.Tasks;

namespace CSSPUpdateServices
{
    public partial class CSSPUpdateService : ICSSPUpdateService
    {
        private void ErrorAppend(StringBuilder sbError, string ErrorText)
        {
            Console.WriteLine($"\r{ErrorText}");
            sbError.AppendLine(ErrorText);
        }
        private void LogAppend(StringBuilder sbLog, string LogText)
        {
            Console.WriteLine($"\r{LogText}");
            sbLog.AppendLine(LogText);
        }
        private async Task<bool> StoreInCommandLog(StringBuilder sbLog, StringBuilder sbError, string commandName)
        {
            CommandLog commandLog = new CommandLog()
            {
                CommandLogID = 0,
                AppName = "CSSPUpdateServices",
                CommandName = commandName,
                Successful = false,
                DetailLog = sbLog.ToString(),
                ErrorMessage = sbError.ToString(),
                DateTimeUTC = DateTime.UtcNow,
            };

            try
            {
                commandLog.DetailLog = sbLog.ToString();
                commandLog.ErrorMessage = sbError.ToString();
                dbManage.CommandLogs.Add(commandLog);
                dbManage.SaveChanges();
            }
            catch (Exception ex2)
            {
                string AppAndCommandName = $"AppName: {commandLog.AppName } - CommandName: {commandLog.CommandName}";
                Console.WriteLine($"{String.Format(CSSPCultureUpdateRes.CouldNotAddCommandLog_Error_, AppAndCommandName, ex2.Message)}");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
