using Microsoft.Extensions.Primitives;
using StatusAndResultsDBService.Models;
using StatusAndResultsDBService.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusAndResultsDBService.Services
{
    public class StatusAndResultsService : IStatusAndResultsService
    {
        #region Variables
        private readonly GenerateCodeStatusContext db;
        #endregion Variables

        #region Properties
        public string DBFileFullName { get; set; }
        public string Command { get; set; }
        public StringBuilder Error { get; set; }
        public StringBuilder Status { get; set; }
        #endregion Properties

        #region Constructors
        public StatusAndResultsService(GenerateCodeStatusContext db)
        {
            this.db = db;
            Command = "";
            Error = new StringBuilder();
            Status = new StringBuilder();
        }
        #endregion Constructors

        public async Task<StatusAndResults> Create()
        {
            if (Command == "") return null;

            long? LastID = (from c in db.StatusAndResults
                          orderby c.StatusAndResultID descending
                          select c.StatusAndResultID).FirstOrDefault();

            if (LastID == null)
            {
                LastID = 0;
            }


            StatusAndResults statusAndResults = new StatusAndResults()
            {
                StatusAndResultID = (long)LastID + 1,
                Command = Command,
                ErrorText = "",
                StatusText = "",
                PercentCompleted = 0,
                LastUpdateDate = DateTime.UtcNow.ToString(),
            };

            try
            {
                db.StatusAndResults.Add(statusAndResults);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return statusAndResults;
        }
        public async Task<StatusAndResults> Delete()
        {
            if (Command == "") return null;

            StatusAndResults statusAndResults = await Get();

            if (statusAndResults == null)
            {
                return null;
            }

            db.StatusAndResults.Remove(statusAndResults);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return statusAndResults;
        }
        public async Task<StatusAndResults> Get()
        {
            if (Command == "") return null;

            StatusAndResults statusAndResults = (from c in db.StatusAndResults
                                                 where c.Command == Command
                                                 select c).FirstOrDefault();

            if (statusAndResults == null)
            {
                return null;
            }

            return statusAndResults;
        }
        public async Task<StatusAndResults> GetOrCreate()
        {
            if (Command == "") return null;

            StatusAndResults statusAndResults = await Get();

            if (statusAndResults == null)
            {
                statusAndResults = await Create();
                if (statusAndResults == null)
                {
                    return null;
                }

                statusAndResults = await Get();

                if (statusAndResults == null)
                {
                    return null;
                }
            }

            return statusAndResults;
        }
        public async Task<StatusAndResults> Update(int percentCompleted)
        {
            StatusAndResults statusAndResults = await Get();

            if (statusAndResults == null)
            {
                return null;
            }

            statusAndResults.ErrorText = Error.ToString();
            statusAndResults.StatusText = Status.ToString();
            statusAndResults.PercentCompleted = percentCompleted;
            statusAndResults.LastUpdateDate = DateTime.UtcNow.ToString();

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return statusAndResults;
        }
        public async Task SetCommand(string command)
        {
            Command = command;
        }
        public async Task SetCulture(CultureInfo culture)
        {
            AppRes.Culture = culture;
        }

    }
}
