//using GenerateCodeBaseServices.Models;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Configuration;
//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;

//namespace GenerateRepopulateTestDB
//{
//    public partial class Startup
//    {
//        public async Task<bool> Generate()
//        {
//            Console.WriteLine("Generate Starting ...");
            
//            string CSSPDB = Configuration.GetValue<string>("CSSPDB");
//            string TestDB = Configuration.GetValue<string>("TestDB");

//            List<Table> tableCSSPDBList = new List<Table>();
//            List<Table> tableTestDBList = new List<Table>();

//            Console.WriteLine("Loading CSSPDB table information ...");
//            if (!await LoadDBInfo(tableCSSPDBList, CSSPDB)) return await Task.FromResult(false);

//            Console.WriteLine("Loading TestWeb table information ...");
//            if (!await LoadDBInfo(tableTestDBList, TestDB)) return await Task.FromResult(false);

//            Console.WriteLine("Comparing tables ...");
//            if (!await CompareDBs(tableCSSPDBList, tableTestDBList)) return await Task.FromResult(false);

//            Console.WriteLine("Done comparing ... everything ok");

//            Console.WriteLine("Cleaning TestDB ...");
//            if (!await CleanTestDB(tableTestDBList, TestDB)) return await Task.FromResult(false);

//            Console.WriteLine("Done Cleaning TestDB ... everything ok");

//            Console.WriteLine("Filling TestDB ...");
//            if (!await FillTestDB(tableTestDBList)) return await Task.FromResult(false);
//            Console.WriteLine("Done Filling TestDB ... everything ok");

//            Console.WriteLine("Making sure every table within TestDB has at least 10 items ...");
//            if (!await MakingSureEveryTableHasEnoughItemsInTestDB()) return await Task.FromResult(false);

//            Console.WriteLine("Done Making sure every table within TestDB has at least 10 items");

//            Console.WriteLine("");
//            Console.WriteLine($"Done ...");
//            Console.WriteLine("");
//            Console.WriteLine("Generate Finished ...");

//            return true;
//        }
//    }
//}
