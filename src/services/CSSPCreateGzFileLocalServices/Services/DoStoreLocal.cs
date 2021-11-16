/*
 * Manually edited
 * 
 */
using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.IO.Compression;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CreateGzFileLocalServices
{
    public partial class CreateGzFileLocalService : ControllerBase, ICreateGzFileLocalService
    {
        private void DoStoreLocal<T>(T webJson, string fileName)
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
                CompressLocal(new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson)))).CopyTo(compressedFileStream);
                //new MemoryStream(Encoding.UTF8.GetBytes(JsonSerializer.Serialize<T>(webJson))).CopyTo(compressedFileStream);
            }
        }
    }
}
