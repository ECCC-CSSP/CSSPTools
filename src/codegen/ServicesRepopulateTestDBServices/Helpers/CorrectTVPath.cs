using CSSPModels;
using System;
using System.Threading.Tasks;

namespace ServicesRepopulateTestDBServices.Services
{
    public partial class ServicesRepopulateTestDBService : IServicesRepopulateTestDBService
    {
        private async Task<bool> CorrectTVPath(TVItem tvItem, TVItem tvItemParent)
        {
            tvItem.TVPath = $"{ tvItemParent.TVPath }p{ tvItem.TVItemID.ToString() }";

            try
            {
                dbTestDB.SaveChanges();
            }
            catch (Exception ex)
            {
                string InnerException = (ex.InnerException != null ? $" Inner: [{ ex.InnerException.Message }]" : "");
                ActionCommandDBService.ErrorText.AppendLine($"{ ex.Message }{ InnerException }");
                return await Task.FromResult(false);
            }

            return await Task.FromResult(true);
        }
    }
}
