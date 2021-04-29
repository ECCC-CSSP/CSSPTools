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
    public partial class TVItemLocalServiceTest
    {
        private void CompareTVItems(TVItem tvItem, TVItem tvItem2)
        {
            Assert.Equal(tvItem.TVItemID, tvItem2.TVItemID);
            Assert.Equal(tvItem.DBCommand, tvItem2.DBCommand);
            Assert.Equal(tvItem.TVLevel, tvItem2.TVLevel);
            Assert.Equal(tvItem.TVPath, tvItem2.TVPath);
            Assert.Equal(tvItem.TVType, tvItem2.TVType);
            Assert.Equal(tvItem.ParentID, tvItem2.ParentID);
            Assert.Equal(tvItem.IsActive, tvItem2.IsActive);
            Assert.Equal(tvItem.LastUpdateDate_UTC, tvItem2.LastUpdateDate_UTC);
            Assert.Equal(tvItem.LastUpdateContactTVItemID, tvItem2.LastUpdateContactTVItemID);

        }
    }
}
