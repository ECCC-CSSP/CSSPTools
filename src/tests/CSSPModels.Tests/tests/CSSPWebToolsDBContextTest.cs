using System;
using Xunit;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using CSSPModels.Resources.Generated;

namespace CSSPModels.Tests
{

    public partial class CSSPDBContextTest
    {
        #region Variables
        #endregion Variables

        #region Properties
        #endregion Properties

        #region Constructors
        public CSSPDBContextTest()
        {
        }
        #endregion Constructors

        #region Tests
        [Fact]
        public void CSSPDBContext_DataType_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext())
            {
                Assert.Null(db.DatabaseType);
                Assert.Equal(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
                db.Error = "";

                try
                {
                    var values = db.TVItems.FirstOrDefault();
                }
                catch (Exception)
                {
                    // nothing
                }

                Assert.Equal(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
            }
        }
        [Fact]
        public void CSSPDBContext_DataType_Error_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(null))
            {
                Assert.Null(db.DatabaseType);
                Assert.Equal(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
            }
        }
        [Fact]
        public void CSSPDBContext_DataType_MemoryTestDB_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.MemoryTestDB))
            {
                Assert.Equal(DatabaseTypeEnum.MemoryTestDB, db.DatabaseType);
                Assert.Equal("", db.Error);
            }
        }
        [Fact]
        public void CSSPDBContext_DataType_MemoryCSSPDB_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.MemoryCSSPDB))
            {
                Assert.Equal(DatabaseTypeEnum.MemoryCSSPDB, db.DatabaseType);
                Assert.Equal("", db.Error);
            }
        }
        [Fact]
        public void CSSPDBContext_DataType_SqlServerTestDB_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                Assert.Equal(DatabaseTypeEnum.SqlServerTestDB, db.DatabaseType);
                Assert.Equal("", db.Error);
            }
        }
        [Fact]
        public void CSSPDBContext_DataType_SqlServerCSSPDB_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerCSSPDB))
            {
                Assert.Equal(DatabaseTypeEnum.SqlServerCSSPDB, db.DatabaseType);
                Assert.Equal("", db.Error);
            }
        }
        [Fact]
        public void CSSPDBContext_DataType_1000000_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext((DatabaseTypeEnum)1000000))
            {
                Assert.Null(db.DatabaseType);
                Assert.Equal(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
                db.Error = "";

                try
                {
                    var values = db.TVItems.FirstOrDefault();
                }
                catch (Exception)
                {
                    // nothing
                }

                Assert.Equal(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
            }
        }
        #endregion Tests
    }
}
