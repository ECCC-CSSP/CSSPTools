using Microsoft.Extensions.Primitives;
using ActionCommandDBServices.Models;
using ActionCommandDBServices.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ActionCommandDBServices.Services
{
    public class ActionCommandDBService : IActionCommandDBService
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
        public async Task<ActionCommand> Create()
        {
            if (Action == "") return null;
            if (Command == "") return null;
            if (FullFileName == "") return null;

            long? LastID = (from c in db.ActionCommands
                            orderby c.ActionCommandID descending
                            select c.ActionCommandID).FirstOrDefault();

            if (LastID == null)
            {
                LastID = 0;
            }

            ActionCommand actionCommand = await Get();
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
                catch (Exception)
                {
                    return null;
                }
            }

            return actionCommand;
        }
        public async Task<ActionCommand> Delete()
        {
            if (ActionCommandID == 0) return null;

            ActionCommand actionCommand = await Get();

            if (actionCommand == null)
            {
                return null;
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

            return await Task.FromResult(actionCommand);
        }
        public async Task<ActionCommand> Get()
        {
            if (ActionCommandID == 0) return null;

            ActionCommand actionCommand = (from c in db.ActionCommands
                             where c.ActionCommandID == ActionCommandID
                             select c).FirstOrDefault();

            if (actionCommand == null)
            {
                return null;
            }

            return await Task.FromResult(actionCommand);
        }
        public async Task<ActionCommand> GetOrCreate()
        {
            return ActionCommandID == 0 ? await Create() : await Get();
        }
        public async Task<ActionCommand> Update()
        {
            ActionCommand actionCommand = await Get();
            
            if (actionCommand == null)
            {
                return null;
            }

            actionCommand.Action = Action;
            actionCommand.Command = Command;
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
            catch (Exception)
            {
                return null;
            }

            return actionCommand;
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
        #endregion Functions private
    }
}
