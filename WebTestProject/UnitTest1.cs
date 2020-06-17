using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestWebApp.Controllers;
using TestWebApp.Models;

namespace WebTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var webAppController = new TestController();
            string result = webAppController.TestSample(0);

            Assert.AreEqual(result, "引数に0が指定されました。");
        }

        // InvalidOperationExceptionが発生すればテストOK
        [TestMethod()]
        public void TestSample1()
        {
            // この中で、InvalidOperationException 例外が発生することを確認
            var webAppController = new TestController();
            string result = webAppController.Sample1("山田", "太郎");

            Assert.AreEqual("山田 太郎", result);
        }

        // InvalidOperationExceptionが発生すればテストOK
        [TestMethod()]
        public void TestSample2()
        {
            // この中で、InvalidOperationException 例外が発生することを確認
            var webAppController = new TestController();

            try
            {
                int result = webAppController.Sample2(5, 5);
                Assert.IsTrue(false);
            }
            catch (ArithmeticException)
            {
                Assert.IsTrue(true);
            }

            //var ex = Assert.ThrowsException<ArithmeticException>(() => webAppController.Sample1(5, 0));
        }

        [TestMethod()]
        public void TestSample3()
        {
            var webAppController = new TestController();
            DataTable dummy = dummyData();
            DataTable result = webAppController.Sample3(1);

            Assert.AreEqual(dummy.Rows[0]["company_name"], result.Rows[0]["company_name"]);
        }

        private static DataTable dummyData()
        {
            var dataTable = new DataTable();
            DataRow dataRow = dataTable.NewRow();

            dataTable.Columns.Add("company_name");

            dataRow["company_name"] = "テスト会社2";
            dataTable.Rows.Add(dataRow);

            return dataTable;
        }

        [TestMethod()]
        public void TestSample4()
        {
            var webAppController = new TestController();
            var dummy = new List<int>();
            dummy.AddRange(new[] { 100, 400, 200, 900, 2300, 1900 });
            List<int> result = webAppController.Sample4();

            Assert.AreSame(dummy, result);
        }

        [TestInitialize]
        public void InsertTestData()
        {
            string aaa = "aaaa";
        }

        [TestCleanup]
        public void DeleteTestData()
        {
            string aaa = "aaaa";
        }
    }
}
