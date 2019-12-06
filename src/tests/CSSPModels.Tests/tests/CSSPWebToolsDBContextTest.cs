using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections.Generic;
using CSSPModels;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Reflection;
using CSSPEnums;
using CSSPModels.Resources;

namespace CSSPModels.Tests
{
    [TestClass]
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
        [TestMethod]
        public void CSSPDBContext_DataType_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext())
            {
                Assert.AreEqual(null, db.DatabaseType);
                Assert.AreEqual(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
                db.Error = "";

                try
                {
                    var values = db.TVItems.FirstOrDefault();
                }
                catch (Exception)
                {
                    // nothing
                }

                Assert.AreEqual(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
            }
        }
        [TestMethod]
        public void CSSPDBContext_DataType_Error_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(null))
            {
                Assert.AreEqual(null, db.DatabaseType);
                Assert.AreEqual(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
            }
        }
        [TestMethod]
        public void CSSPDBContext_DataType_MemoryTestDB_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.MemoryTestDB))
            {
                Assert.AreEqual(DatabaseTypeEnum.MemoryTestDB, db.DatabaseType);
                Assert.AreEqual("", db.Error);
            }
        }
        [TestMethod]
        public void CSSPDBContext_DataType_MemoryCSSPDB_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.MemoryCSSPDB))
            {
                Assert.AreEqual(DatabaseTypeEnum.MemoryCSSPDB, db.DatabaseType);
                Assert.AreEqual("", db.Error);
            }
        }
        [TestMethod]
        public void CSSPDBContext_DataType_SqlServerTestDB_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerTestDB))
            {
                Assert.AreEqual(DatabaseTypeEnum.SqlServerTestDB, db.DatabaseType);
                Assert.AreEqual("", db.Error);
            }
        }
        [TestMethod]
        public void CSSPDBContext_DataType_SqlServerCSSPDB_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext(DatabaseTypeEnum.SqlServerCSSPDB))
            {
                Assert.AreEqual(DatabaseTypeEnum.SqlServerCSSPDB, db.DatabaseType);
                Assert.AreEqual("", db.Error);
            }
        }
        [TestMethod]
        public void CSSPDBContext_DataType_1000000_Test()
        {
            using (CSSPDBContext db = new CSSPDBContext((DatabaseTypeEnum)1000000))
            {
                Assert.AreEqual(null, db.DatabaseType);
                Assert.AreEqual(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
                db.Error = "";

                try
                {
                    var values = db.TVItems.FirstOrDefault();
                }
                catch (Exception)
                {
                    // nothing
                }

                Assert.AreEqual(string.Format(CSSPModelsRes._IsRequired, "DataType"), db.Error);
            }
        }
        #endregion Tests
    }
}
