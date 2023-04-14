using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Wheel;
namespace UnitTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckOpenConnection_ReturnedTrue()
        {
            using(DataBase db = new DataBase())
            {
                Assert.IsTrue(db.isConnected);
            }
        }
        
        [TestMethod]
        public void CheckCloseConnection_ReturnedTrue()
        {
            using (DataBase db = new DataBase())
            {
                db.Dispose();
                Assert.IsFalse(db.isConnected);
            }
        }

        [TestMethod]
        public void CheckExecuteSql_ReturnedTrue()
        {
            using (DataBase db = new DataBase())
            {
                Assert.IsTrue(db.ExecuteNonQuery("insert into Supplier values('test', '123451245', '14.04.2023', '5', 'test')"));
            }
        }
        [TestMethod]
        public void CheckSetSource_ReturnedTrue()
        {
            Assert.IsTrue(new Form1().SetSource(Table.Supplier));
        }
        [TestMethod]
        public void CheckUpdateTables_ReturnedTrue()
        {
            Assert.IsTrue(new Form1().UpdateTables());
        }
    }
}
