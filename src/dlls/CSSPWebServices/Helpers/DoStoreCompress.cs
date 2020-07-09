﻿/*
 * Manually edited
 * 
 */
using Azure.Storage.Blobs;
using CSSPEnums;
using CSSPModels;
using CSSPWebModels;
using CultureServices.Services;
using LoggedInServices.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSSPWebServices.Services
{
    public partial class WebService : ControllerBase, IWebService
    {
        private Stream Compress(Stream decompressed, CompressionLevel compressionLevel = CompressionLevel.Fastest)
        {
            MemoryStream compressed = new MemoryStream();
            using (GZipStream gZip = new GZipStream(compressed, compressionLevel, true))
            {
                decompressed.CopyTo(gZip);
            }

            compressed.Seek(0, SeekOrigin.Begin);
            return compressed;
        }
    }
}
