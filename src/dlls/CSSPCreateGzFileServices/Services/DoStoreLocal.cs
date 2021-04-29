/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CreateGzFileServices
{
    public partial class CreateGzFileService : ControllerBase, ICreateGzFileService
    {
        private async Task DoStoreLocal<T>(T webJson, string fileName)
        {
            FileInfo fi = new FileInfo($"{ CSSPJSONPathLocal }{ fileName }");

            if (fi.Exists)
            {
                try
                {
                    fi.Delete();
                }
                catch (Exception)
                {
                    // Nothing for now
                }
            }

            using (FileStream compressedFileStream = fi.Create())
            {
                Compress(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)))).CopyTo(compressedFileStream);
                //new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))).CopyTo(compressedFileStream);
            }
        }
    }
}
