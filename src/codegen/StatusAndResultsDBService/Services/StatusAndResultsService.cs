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
        private readonly GenerateCodeStatusContext _generateCodeStatusContext;
        #endregion Variables

        #region Constructors
        public StatusAndResultsService(GenerateCodeStatusContext generateCodeStatusContext)
        {
            _generateCodeStatusContext = generateCodeStatusContext;
        }
        #endregion Constructors

        public async Task<StatusAndResults> Create(string command)
        {
            long? LastID = (from c in _generateCodeStatusContext.StatusAndResults
                          orderby c.StatusAndResultID descending
                          select c.StatusAndResultID).FirstOrDefault();

            if (LastID == null)
            {
                LastID = 0;
            }


            StatusAndResults statusAndResults = new StatusAndResults()
            {
                StatusAndResultID = (long)LastID + 1,
                Command = command,
                ErrorText = "",
                StatusText = "",
                PercentCompleted = 0,
                LastUpdateDate = DateTime.UtcNow.ToString(),
            };

            try
            {
                _generateCodeStatusContext.StatusAndResults.Add(statusAndResults);
                _generateCodeStatusContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return statusAndResults;
        }
        public async Task<StatusAndResults> Delete(string command)
        {
            StatusAndResults statusAndResults = await Get(command);

            if (statusAndResults == null)
            {
                return null;
            }

            _generateCodeStatusContext.StatusAndResults.Remove(statusAndResults);

            try
            {
                _generateCodeStatusContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return statusAndResults;
        }
        public async Task<StatusAndResults> Get(string command)
        {
            StatusAndResults statusAndResults = (from c in _generateCodeStatusContext.StatusAndResults
                                                 where c.Command == command
                                                 select c).FirstOrDefault();

            if (statusAndResults == null)
            {
                return null;
            }

            return statusAndResults;
        }
        public async Task<StatusAndResults> Update(string command, string errorText, string statusText, int percentCompleted)
        {
            StatusAndResults statusAndResults = await Get(command);

            if (statusAndResults == null)
            {
                return null;
            }

            statusAndResults.ErrorText = errorText;
            statusAndResults.StatusText = statusText;
            statusAndResults.PercentCompleted = percentCompleted;
            statusAndResults.LastUpdateDate = DateTime.UtcNow.ToString();

            try
            {
                _generateCodeStatusContext.SaveChanges();
            }
            catch (Exception ex)
            {
                return null;
            }

            return statusAndResults;
        }
        public async Task SetCulture(CultureInfo Culture)
        {
            StatusAndResultsServiceRes.Culture = Culture;
        }

    }
}
