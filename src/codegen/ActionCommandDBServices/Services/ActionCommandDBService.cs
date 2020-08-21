using ActionCommandDBServices.Models;
using CSSPCultureServices.Resources;
using CSSPCultureServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionCommandDBServices.Services
{
    public interface IActionCommandDBService
    {
        public long ActionCommandID { get; set; }
        public string Action { get; set; }
        public string Command { get; set; }
        public string FullFileName { get; set; }
        public string Description { get; set; }
        public StringBuilder ErrorText { get; set; }
        public StringBuilder ExecutionStatusText { get; set; }
        public StringBuilder FilesStatusText { get; set; }
        public long PercentCompleted { get; set; }

        Task<ActionResult<ActionCommand>> Get();
        Task<ActionResult<List<ActionCommand>>> GetAll();
        Task<ActionResult<List<ActionCommand>>> RefillAll();
        Task<ActionResult<ActionCommand>> Run(ActionCommand actionCommand);
        Task<ActionResult<ActionCommand>> Update();

        Task ConsoleWriteEnd();
        Task ConsoleWriteError(string errMessage);
        Task ConsoleWriteStart();
    }
    public partial class ActionCommandDBService : ControllerBase, IActionCommandDBService
    {
        #region Variables
        #endregion Variables

        #region Properties
        public long ActionCommandID { get; set; }
        public string Action { get; set; }
        public string Command { get; set; }
        public string FullFileName { get; set; }
        public string Description { get; set; }
        public StringBuilder ErrorText { get; set; }
        public StringBuilder ExecutionStatusText { get; set; }
        public StringBuilder FilesStatusText { get; set; }
        public long PercentCompleted { get; set; }
        public DateTime LastUpdateDate { get; set; }

        private IConfiguration Configuration { get; }
        private ICSSPCultureService CSSPCultureService { get; }
        private ActionCommandContext db { get; }
        private string ActionText = "Action";
        private string CommandText = "Command";
        #endregion Properties

        #region Constructors
        public ActionCommandDBService(ICSSPCultureService CSSPCultureService, IConfiguration Configuration, ActionCommandContext db)
        {
            this.CSSPCultureService = CSSPCultureService;
            this.Configuration = Configuration;
            this.db = db;
            Init();
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<ActionCommand>> Get()
        {
            if (string.IsNullOrWhiteSpace(Action)) return BadRequest($"{ string.Format(CSSPCultureServicesRes._IsRequired, ActionText) }");
            if (string.IsNullOrWhiteSpace(Command)) return BadRequest($"{ string.Format(CSSPCultureServicesRes._IsRequired, CommandText) }");

            ActionCommand actionCommand = GetActionCommand();

            if (actionCommand == null)
            {
                return BadRequest($"{ CSSPCultureServicesRes.CouldNotFindActionCommand } { string.Format(CSSPCultureServicesRes.WithAction_AndCommand_, Action, Command) }");
            }

            return await Task.FromResult(Ok(actionCommand));
        }
        public async Task<ActionResult<List<ActionCommand>>> GetAll()
        {
            // clear everything in DB
            List<ActionCommand> actionCommandList = (from c in db.ActionCommands
                                                     select c).ToList();


            return await Task.FromResult(Ok(actionCommandList));
        }
        public async Task<ActionResult<List<ActionCommand>>> RefillAll()
        {
            // clear everything in DB
            List<ActionCommand> actionCommandToDeleteList = (from c in db.ActionCommands
                                                             select c).ToList();

            if (actionCommandToDeleteList.Count > 0)
            {
                foreach (ActionCommand actionCommand in actionCommandToDeleteList)
                {
                    db.ActionCommands.Remove(actionCommand);
                }

                try
                {
                    db.SaveChanges();
                }
                catch (Exception ex)
                {
                    return BadRequest(ex.Message);
                }
            }

            string actionCommandCSVFileName = Configuration.GetValue<string>("ActionCommandCSVFileName");
            if (string.IsNullOrWhiteSpace(actionCommandCSVFileName))
            {
                return BadRequest($"{ string.Format(CSSPCultureServicesRes.CouldNotReadAppSettingsParameter_ShouldBeSomthingLike_, "ActionCommandCSVFileName", "{ExePath}\\ActionCommandList.csv")}");
            }

            // refill DB
            FileInfo fi = new FileInfo(actionCommandCSVFileName.Replace("{ExePath}", Environment.CurrentDirectory));

            if (!fi.Exists)
            {
                return BadRequest($"{ string.Format(CSSPCultureServicesRes.CouldNotFindFile_, fi.FullName) }");
            }

            StreamReader str = fi.OpenText();
            string fileText = str.ReadToEnd();
            str.Close();

            long LastID = 0;
            StringReader sr = new StringReader(fileText);
            string LineStr = sr.ReadLine();
            while (!string.IsNullOrWhiteSpace(LineStr))
            {
                List<string> strList = LineStr.Split(",".ToCharArray(), StringSplitOptions.RemoveEmptyEntries).ToList();

                if (strList.Count == 3)
                {
                    LastID += 1;
                    Init();
                    Action = strList[0];
                    Command = strList[1];
                    FullFileName = strList[2];
                    Description = $"{ Action } - { Command } Description ToDo";

                    FileInfo fiTxt = new FileInfo($"{ Environment.CurrentDirectory }\\{ Action }{ Command }.txt");

                    if (fiTxt.Exists)
                    {
                        StreamReader srTxt = fiTxt.OpenText();
                        Description = srTxt.ReadToEnd();
                        srTxt.Close();
                    }

                    ActionCommand actionCommand = new ActionCommand()
                    {
                        ActionCommandID = LastID,
                        Action = Action,
                        Command = Command,
                        FullFileName = FullFileName,
                        Description = Description,
                        ErrorText = "",
                        ExecutionStatusText = "",
                        FilesStatusText = "",
                        PercentCompleted = 0,
                        LastUpdateDate = DateTime.UtcNow.ToString(),
                    };

                    try
                    {
                        db.ActionCommands.Add(actionCommand);
                        db.SaveChanges();

                        ActionCommandID = actionCommand.ActionCommandID;
                    }
                    catch (Exception ex)
                    {
                        return await Task.FromResult(BadRequest(ex.Message));
                    }

                    LineStr = sr.ReadLine();
                }
                else
                {
                    break;
                }
            }

            return await GetAll();
        }
        public async Task<ActionResult<ActionCommand>> Run(ActionCommand actionCommand)
        {
            try
            {
                Action = actionCommand.Action;
                Command = actionCommand.Command;

                string exePath = Configuration.GetValue<string>("ExecuteDotNetCommandAppPath");
                string args = $" { CSSPCultureServicesRes.Culture.Name } { actionCommand.Action } { actionCommand.Command }";

                if (string.IsNullOrWhiteSpace(exePath))
                {
                    ErrorText.AppendLine(CSSPCultureServicesRes.ExePathIsEmpty);
                    PercentCompleted = 0;
                    await Update();
                    return BadRequest(ErrorText.ToString());
                }

                FileInfo fiApp = new FileInfo(exePath);
                if (!fiApp.Exists)
                {
                    ErrorText.AppendLine(string.Format(CSSPCultureServicesRes.CouldNotFindExePath_, exePath));
                    PercentCompleted = 0;
                    await Update();
                    return BadRequest(ErrorText.ToString());
                }

                Process process = new Process();
                process = Process.Start(exePath, args);

                while (!process.HasExited)
                {
                    // report progress is needed
                }

                return await Get();
            }
            catch (Exception ex)
            {
                return BadRequest(string.Format(CSSPCultureServicesRes.UnmanagedServerError_, ex.Message));
            }
        }
        public async Task<ActionResult<ActionCommand>> Update()
        {
            if (string.IsNullOrWhiteSpace(Action)) return BadRequest($"{ string.Format(CSSPCultureServicesRes._IsRequired, ActionText) }");
            if (string.IsNullOrWhiteSpace(Command)) return BadRequest($"{ string.Format(CSSPCultureServicesRes._IsRequired, CommandText) }");

            ActionCommand actionCommand = GetActionCommand();
            if (actionCommand == null)
            {
                return BadRequest($"{ CSSPCultureServicesRes.CouldNotFindActionCommand } { string.Format(CSSPCultureServicesRes.To_, CSSPCultureServicesRes.Update) }{ string.Format(CSSPCultureServicesRes.WithAction_AndCommand_, Action, Command) }");
            }

            actionCommand.FullFileName = FullFileName;
            actionCommand.Description = Description;
            actionCommand.ErrorText = ErrorText.ToString();
            actionCommand.ExecutionStatusText = ExecutionStatusText.ToString();
            actionCommand.FilesStatusText = FilesStatusText.ToString();
            actionCommand.PercentCompleted = PercentCompleted;
            actionCommand.LastUpdateDate = DateTime.UtcNow.ToString();

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return await Task.FromResult(BadRequest(ex.Message));
            }

            return await Task.FromResult(Ok(actionCommand));
        }
        #endregion Functions public

        #region Functions private
        private void Init()
        {
            ActionCommandID = 0;
            Action = "";
            Command = "";
            FullFileName = "";
            Description = "";
            ErrorText = new StringBuilder();
            ExecutionStatusText = new StringBuilder();
            FilesStatusText = new StringBuilder();
            PercentCompleted = 0;
        }
        private ActionCommand GetActionCommand()
        {
            ActionCommand actionCommand = (from c in db.ActionCommands
                                           where c.Action == Action
                                           && c.Command == Command
                                           select c).FirstOrDefault();

            if (actionCommand == null)
            {
                return null;
            }

            ActionCommandID = actionCommand.ActionCommandID;
            Action = actionCommand.Action;
            Command = actionCommand.Command;
            FullFileName = actionCommand.FullFileName;
            Description = actionCommand.Description;
            //ExecutionStatusText = new StringBuilder(actionCommand.ExecutionStatusText);
            //FilesStatusText = new StringBuilder(actionCommand.FilesStatusText);
            //PercentCompleted = actionCommand.PercentCompleted;
            //LastUpdateDate = DateTime.Parse(actionCommand.LastUpdateDate);

            return actionCommand;
        }
        #endregion Functions private
    }
}
