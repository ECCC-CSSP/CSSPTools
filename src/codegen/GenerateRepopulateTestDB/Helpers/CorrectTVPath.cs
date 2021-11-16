//using CSSPDBModels;
//using System;
//using System.Threading.Tasks;

//namespace GenerateRepopulateTestDB
//{
//    public partial class Startup
//    {
//        private async Task<bool> CorrectTVPath(TVItem tvItem, TVItem tvItemParent)
//        {
//            tvItem.TVPath = $"{ tvItemParent.TVPath }p{ tvItem.TVItemID.ToString() }";

//            try
//            {
//                dbTestDB.SaveChanges();
//            }
//            catch (Exception ex)
//            {
//                string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
//                Console.WriteLine($"{ ex.Message }{ InnerException }");
//                return await Task.FromResult(false);
//            }

//            return await Task.FromResult(true);
//        }
//    }
//}
