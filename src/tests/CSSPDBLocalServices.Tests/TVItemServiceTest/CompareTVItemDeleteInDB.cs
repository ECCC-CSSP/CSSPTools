/* 
 *  Manually Edited
 *  
 */

using CSSPDBModels;
using CSSPEnums;
using System.Linq;
using Xunit;

namespace CSSPDBLocalServices.Tests
{
    public partial class TVItemServiceTest
    {
        private void CompareTVItemDeleteInDB(int TVItemID, DBCommandEnum DBCommand, int TVLevel, string TVPath, TVTypeEnum TVType, int ParentID, bool IsActive)
        {
            TVItem tvItem = (from c in dbLocal.TVItems
                             where c.TVItemID == TVItemID
                             select c).FirstOrDefault();

            Assert.Equal(TVItemID, tvItem.TVItemID);
            Assert.Equal(DBCommand, tvItem.DBCommand);
            Assert.Equal(TVLevel, tvItem.TVLevel);
            Assert.Equal(TVPath, tvItem.TVPath);
            Assert.Equal(TVType, tvItem.TVType);
            Assert.Equal(ParentID, tvItem.ParentID);
            Assert.Equal(IsActive, tvItem.IsActive);
            Assert.True(tvItem.LastUpdateDate_UTC.Year > 1979);
            Assert.True(tvItem.LastUpdateContactTVItemID > 0);

        }
    }
}
