/*
 * Manually edited
 *
 */

using CSSPWebModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CSSPLocalFileInfoServices
{
    public partial interface ILocalFileInfoService
    {
        Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(string DirectoryPath);
    }
    public partial class LocalFileInfoService : ControllerBase, ILocalFileInfoService
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public LocalFileInfoService()
        {
        }
        #endregion Constructors

        #region Functions public 
        public async Task<ActionResult<List<LocalFileInfo>>> GetLocalFileInfoList(string DirectoryPath)
        {
            List<LocalFileInfo> localFileInfoList = new List<LocalFileInfo>();

            DirectoryInfo di = new DirectoryInfo(DirectoryPath);

            if (!di.Exists)
            {
                return await Task.FromResult(Ok(localFileInfoList));
            }

            List<FileInfo> FileInfoList = di.GetFiles().ToList();

            foreach(FileInfo fi in FileInfoList)
            {
                localFileInfoList.Add(new LocalFileInfo() { FileName = fi.Name, Length = fi.Length });
            }

            return await Task.FromResult(Ok(localFileInfoList));
        }
        #endregion Functions public

        #region Functions private
        #endregion Functions private

    }
}
