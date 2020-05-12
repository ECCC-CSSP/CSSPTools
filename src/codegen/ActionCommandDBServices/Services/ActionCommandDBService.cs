using Microsoft.Extensions.Primitives;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ActionCommandDBServices.Services
{
    public class ActionCommandDBService : ControllerBase, IActionCommandDBService
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
            if (Action == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Action") }");
            if (Command == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Command") }");

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
                    return BadRequest(ex.Message);
                }
            }

            return Ok(actionCommand);
        }
        public async Task<ActionResult<ActionCommand>> Delete()
        {
            if (Action == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Action") }");
            if (Command == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Command") }");

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

            return Ok(actionCommand);
        }
        public async Task<ActionResult<ActionCommand>> Get()
        {
            if (Action == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Action") }");
            if (Command == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Command") }");

            ActionCommand actionCommand = GetActionCommand();

            if (actionCommand == null)
            {
                return BadRequest($"{ string.Format(AppRes.CouldNotFindActionCommandToDeleteWithAction_AndCommand_, Action, Command) }");
            }

            return Ok(actionCommand);
        }
        public async Task<ActionResult<ActionCommand>> GetOrCreate()
        {
            if (Action == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Action") }");
            if (Command == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Command") }");

            ActionCommand actionCommand = GetActionCommand();
            if (actionCommand == null)
            {
                return await Create();
            }

            return Ok(actionCommand);
        }
        public async Task<ActionResult<ActionCommand>> Update()
        {
            if (Action == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Action") }");
            if (Command == "") return BadRequest($"{ string.Format(AppRes._IsRequied, "Command") }");

            ActionCommand actionCommand = GetActionCommand();
            if (actionCommand == null)
            {
                return BadRequest(actionCommand);
            }


            //actionCommand.ActionCommandID = ActionCommandID;
            //actionCommand.Action = Action;
            //actionCommand.Command = Command;
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
                return BadRequest(ex.Message);
            }

            return Ok(actionCommand);
        }
        public async Task SetCulture(CultureInfo culture)
        {
            AppRes.Culture = culture;
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
