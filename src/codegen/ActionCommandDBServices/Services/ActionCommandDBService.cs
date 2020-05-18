using ActionCommandDBServices.Models;
using CultureServices.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionCommandDBServices.Services
{
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
        public StringBuilder TempStatusText { get; set; }
        public StringBuilder ErrorText { get; set; }
        public StringBuilder ExecutionStatusText { get; set; }
        public StringBuilder FilesStatusText { get; set; }
        public long PercentCompleted { get; set; }

        private ActionCommandContext db { get; }
        private string ActionText = "Action";
        private string CommandText = "Command";
        #endregion Properties

        #region Constructors
        public ActionCommandDBService(ActionCommandContext db)
        {
            this.db = db;
            Init();
        }
        #endregion Constructors

        #region Functions public
        public async Task<ActionResult<ActionCommand>> Create()
        {
            if (string.IsNullOrWhiteSpace(Action)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, ActionText) }");
            if (string.IsNullOrWhiteSpace(Command)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, CommandText) }");

            long? LastID = (from c in db.ActionCommands
                            orderby c.ActionCommandID descending
                            select c.ActionCommandID).FirstOrDefault();

            if (LastID == null)
            {
                LastID = 0;
            }

            ActionCommand actionCommand = GetActionCommand();
            if (actionCommand == null)
            {
                actionCommand = new ActionCommand()
                {
                    ActionCommandID = (long)LastID + 1,
                    Action = Action,
                    Command = Command,
                    FullFileName = FullFileName,
                    Description = Description,
                    TempStatusText = TempStatusText.ToString(),
                    ErrorText = ErrorText.ToString(),
                    ExecutionStatusText = ExecutionStatusText.ToString(),
                    FilesStatusText = FilesStatusText.ToString(),
                    PercentCompleted = PercentCompleted,
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
            }

            return await Task.FromResult(Ok(actionCommand));
        }
        public async Task<ActionResult<ActionCommand>> Delete()
        {
            if (string.IsNullOrWhiteSpace(Action)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, ActionText) }");
            if (string.IsNullOrWhiteSpace(Command)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, CommandText) }");

            ActionCommand actionCommand = GetActionCommand();

            if (actionCommand == null)
            {
                return BadRequest(actionCommand);
            }

            db.ActionCommands.Remove(actionCommand);

            try
            {
                db.SaveChanges();
                Init();
            }
            catch (Exception)
            {
                return null;
            }

            return await Task.FromResult(Ok(actionCommand));
        }
        public async Task<ActionResult<ActionCommand>> Get()
        {
            if (string.IsNullOrWhiteSpace(Action)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, ActionText) }");
            if (string.IsNullOrWhiteSpace(Command)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, CommandText) }");

            ActionCommand actionCommand = GetActionCommand();

            if (actionCommand == null)
            {
                return BadRequest($"{ string.Format(CultureServicesRes.CouldNotFindActionCommandToDeleteWithAction_AndCommand_, Action, Command) }");
            }

            return await Task.FromResult(Ok(actionCommand));
        }
        public async Task<ActionResult<ActionCommand>> GetOrCreate()
        {
            if (string.IsNullOrWhiteSpace(Action)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, ActionText) }");
            if (string.IsNullOrWhiteSpace(Command)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, CommandText) }");

            ActionCommand actionCommand = GetActionCommand();
            if (actionCommand == null)
            {
                return await Create();
            }

            return await Task.FromResult(Ok(actionCommand));
        }
        public async Task<ActionResult<ActionCommand>> Update()
        {
            if (string.IsNullOrWhiteSpace(Action)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, ActionText) }");
            if (string.IsNullOrWhiteSpace(Command)) return BadRequest($"{ string.Format(CultureServicesRes._IsRequied, CommandText) }");

            ActionCommand actionCommand = GetActionCommand();
            if (actionCommand == null)
            {
                return BadRequest(actionCommand);
            }

            actionCommand.FullFileName = FullFileName;
            actionCommand.Description = Description;
            actionCommand.TempStatusText = TempStatusText.ToString();
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
        public async Task SetCulture(CultureInfo culture)
        {
            CultureServicesRes.Culture = culture;
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
            TempStatusText = new StringBuilder();
            ErrorText = new StringBuilder();
            ExecutionStatusText = new StringBuilder();
            FilesStatusText = new StringBuilder();
            PercentCompleted = 0;
        }
        private ActionCommand GetActionCommand()
        {
            return (from c in db.ActionCommands
                    where c.Action == Action
                    && c.Command == Command
                    select c).FirstOrDefault();
        }
        #endregion Functions private
    }
}
