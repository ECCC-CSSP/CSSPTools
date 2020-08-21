using System.Collections.Generic;
using System.Threading.Tasks;

namespace CSSPServices
{
    public partial class CSSPSQLiteService : ICSSPSQLiteService
    {
        private async Task<bool> FillListTableToCreate(List<string> ListTableToCreate, List<string> ListTableToDelete)
        {
            foreach (string DeleteTable in ListTableToDelete)
            {
                ListTableToCreate.Add(DeleteTable);
            }

            ListTableToCreate.Reverse();

            return await Task.FromResult(true);
        }
    }
}
