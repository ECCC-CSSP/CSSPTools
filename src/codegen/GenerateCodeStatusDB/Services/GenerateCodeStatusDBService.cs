using Microsoft.Extensions.Primitives;
using GenerateCodeStatusDB.Models;
using GenerateCodeStatusDB.Resources;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCodeStatusDB.Services
{
    public class GenerateCodeStatusDBService : IGenerateCodeStatusDBService
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
        public GenerateCodeStatusDBService(GenerateCodeStatusContext db)
        {
            this.db = db;
            Command = "";
            Error = new StringBuilder();
            Status = new StringBuilder();
        }
        #endregion Constructors

        public async Task<GenerateCodeStatus> Create()
        {
            if (Command == "") return null;

            long? LastID = (from c in db.Status
                          orderby c.StatusID descending
                          select c.StatusID).FirstOrDefault();

            if (LastID == null)
            {
                LastID = 0;
            }


            GenerateCodeStatus generateCodeStatus = new GenerateCodeStatus()
            {
                StatusID = (long)LastID + 1,
                Command = Command,
                ErrorText = "",
                StatusText = "",
                PercentCompleted = 0,
                LastUpdateDate = DateTime.UtcNow.ToString(),
            };

            try
            {
                db.Status.Add(generateCodeStatus);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return generateCodeStatus;
        }
        public async Task<GenerateCodeStatus> Delete()
        {
            if (Command == "") return null;

            GenerateCodeStatus generateCodeStatus = await Get();

            if (generateCodeStatus == null)
            {
                return null;
            }

            db.Status.Remove(generateCodeStatus);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return generateCodeStatus;
        }
        public async Task<GenerateCodeStatus> Get()
        {
            if (Command == "") return null;

            GenerateCodeStatus generateCodeStatus = (from c in db.Status
                                                 where c.Command == Command
                                                 select c).FirstOrDefault();

            if (generateCodeStatus == null)
            {
                return null;
            }

            return generateCodeStatus;
        }
        public async Task<GenerateCodeStatus> GetOrCreate()
        {
            if (Command == "") return null;

            GenerateCodeStatus generateCodeStatus = await Get();

            if (generateCodeStatus == null)
            {
                generateCodeStatus = await Create();
                if (generateCodeStatus == null)
                {
                    return null;
                }

                generateCodeStatus = await Get();

                if (generateCodeStatus == null)
                {
                    return null;
                }
            }

            return generateCodeStatus;
        }
        public async Task<GenerateCodeStatus> Update(int percentCompleted)
        {
            GenerateCodeStatus generateCodeStatus = await Get();

            if (generateCodeStatus == null)
            {
                return null;
            }

            generateCodeStatus.ErrorText = Error.ToString();
            generateCodeStatus.StatusText = Status.ToString();
            generateCodeStatus.PercentCompleted = percentCompleted;
            generateCodeStatus.LastUpdateDate = DateTime.UtcNow.ToString();

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return generateCodeStatus;
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
