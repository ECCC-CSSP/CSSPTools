using CSSPCultureServices.Services;
using CSSPDBModels;
using CSSPEnums;
using CSSPLocalLoggedInServices;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using System.Security.Cryptography;
using Azure.Storage.Files.Shares;
using Azure;
using Azure.Storage.Files.Shares.Models;
using Microsoft.AspNetCore.Http;

namespace UploadAllFilesToAzure
{
    public class ParentAndFileName
    {
        public int TVFileID { get; set; }
        public int TVItemID { get; set; }
        public int ParentID { get; set; }
        public string ServerFileName { get; set; }
    }
}
