using CSSPSQLiteServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CSSPSQLiteServices.Tests
{
    public class CSSPSQLiteServicesTests
    {
        [Fact]
        public async Task CreateSQLiteCSSPDBLocal_Good_Test()
        {
            SQLiteCreateCSSPDBLocal sqliteCreateCSSPDBLocal = new SQLiteCreateCSSPDBLocal();

            bool retBool = await sqliteCreateCSSPDBLocal.CreateSQLiteCSSPDBLocal();
            Assert.True(retBool);
        }

    }
}
