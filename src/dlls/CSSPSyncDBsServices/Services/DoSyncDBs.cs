/*
 * Manually edited
 *
 */

using CSSPCultureServices.Resources;
using CSSPDBModels;
using CSSPEnums;
using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace CSSPSyncDBsServices
{
    public partial class SyncDBsService : ControllerBase, ISyncDBsService
    {
        private bool DoSyncDBs()
        {
            ValidationResults = new List<ValidationResult>();

            FileInfo fi = new FileInfo(@"C:\TheFile.db");
            if (!fi.Exists)
            {
                ValidationResults.Add(new ValidationResult(string.Format(CSSPCultureServicesRes.FileNotFound_, fi.FullName), new[] { "" }));
            }

            // will need to have internet connection
            // local db should not have AppTask item or Task not completed
            // will need to add an AppTask to local db while all the files are copied to Azure
            // will keep percent and status in Azure AppTask updated as things get done
            // will need to read local db for any files that need to be sent to Azure
            // created new file should be unique so if file already exist in Azure then it should be renamed before sending to Azure
            // changed files should be copied over the Azure files
            // send all files to Azure in a special Azure directory
            // remove the AppTask item (SyncDBs) from the local db
            // then send the local db to a special Azure directory with a special name
            // should probably copy the local db to a local backup directory just in case
            // should reset the local db as empty
            // add an AppTask item (SyncDBs) to Azure db
            // let the server task runner do its thing while updating AppTask on Azure db
            // the server task runner should keep all the TVItemID to recreated TVItemStats and GZ file need to be recreated
            // the server task runner once all done should delete the AppTask item on Azure

            // will need to create the ServerTaskRunnerServices and the LocalTaskRunnerServices

            return ValidationResults.Count == 0 ? true : false;
        }
    }
}