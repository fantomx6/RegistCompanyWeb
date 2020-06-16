using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TestWebApp.Models;

namespace TestWebApp.Controllers
{
    public class TestController : Controller
    {
        // GET: Tesgt
        public ActionResult Index()
        {
            //Sample4(1);
            return View("Index");
        }

        [HttpPost]
        public ActionResult Regist()
        {
            if (!ModelState.IsValid)
            {
                var model = new Test()
                {
                    CompanyName = "テスト会社",
                    CompanyPhonetic = "ﾃｽﾄｶｲｼｬ",
                    DepartmentCode = "AB001",
                    DepartmentName = "テスト部署",
                    Prefectures = "東京都",
                    Municipalities = "新宿区",
                    Block = "1-2-3",
                    PostCode = "123-45678",
                    PhoneNumber = "0312345678",
                    FaxNumber = "0398765432",
                    MailAddress = "test@mail.co.jp"
                };

                return View("Confirm", model);
            }

            return View("Index");
        }

        /// ユニットテスト用サンプル
        /// </summary>
        /// <param name="type">タイプ</param>
        /// <returns>文字列</returns>
        public string TestSample(int type)
        {
            if (type == 0)
            {
                return "引数に0が指定されました。";
            }
            else
            {
                return "引数に0以外が指定されました。";
            }
        }

        /// <summary>
        /// サンプル1
        /// </summary>
        /// <param name="lastName">名字</param>
        /// <param name="firstName">名前</param>
        /// <returns>氏名</returns>
        public string Sample1(string lastName, string firstName)
        {
            // 名字と名前を文字列結合
            return string.Format("{0} {1}", lastName, firstName);
        }

        /// <summary>
        /// サンプル2
        /// </summary>
        /// <param name="value1">値1</param>
        /// <param name="value2">値2</param>
        /// <returns>計算結果</returns>
        public int Sample2(int value1, int value2)
        {
            int result = 0;

            try
            {
                // 値1と値2を計算
                result = value1 / value2;

                return result;
            }
            catch (ArithmeticException ex)
            {
                // 0除算の例外が発生
                throw ex;
            }
        }

        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>会社情報</returns>
        public DataTable Sample3(int id)
        {
            // 接続情報を設定してDBコネクションを生成
            using (var con = new SQLiteConnection("Data Source=D:/testdb.sqlite;Version=3;"))
            using (SQLiteCommand com = con.CreateCommand())
            {
                try
                {
                    // データベースに接続
                    con.Open();

                    var dataTable = new DataTable();

                    // SQL文を作成
                    var sql = new StringBuilder();
                    sql.AppendLine(" select * from copmpany_master where id = @ID");
                    com.CommandText = sql.ToString();

                    // パラメータを設定
                    com.Parameters.Add(new SQLiteParameter("@ID", id));

                    var dataAdapter = new SQLiteDataAdapter(com.CommandText, con);
                    dataAdapter.SelectCommand = com;
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        return null;
                    }

                    return dataTable;
                }
                catch (Exception ex)
                {
                    // 例外の詳細をコンソールへ出力
                    Console.WriteLine(ex.Message);

                    return null;
                }
            }
        }

        /// <summary>
        /// データを取得します。
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>会社情報</returns>
        public DataTable Sample4(int id)
        {
            string constr = @"Server=192.168.255.128\SQLEXPRESS,1433; Database=learning; User ID=sa;Password=password@1234";

            // 接続情報を設定してDBコネクションを生成
            using (var con = new SqlConnection(constr))
            using (SqlCommand com = con.CreateCommand())
            {
                try
                {
                    // データベースに接続
                    con.Open();

                    var dataTable = new DataTable();

                    // SQL文を作成
                    var sql = new StringBuilder();
                    sql.AppendLine(" select * from company_master where id = @ID");
                    com.CommandText = sql.ToString();

                    // パラメータを設定
                    com.Parameters.Add(new SqlParameter("@ID", id));

                    var dataAdapter = new SqlDataAdapter(com.CommandText, con);
                    dataAdapter.SelectCommand = com;
                    dataAdapter.Fill(dataTable);

                    if (dataTable.Rows.Count == 0)
                    {
                        return null;
                    }

                    return dataTable;
                }
                catch (Exception ex)
                {
                    // 例外の詳細をコンソールへ出力
                    Console.WriteLine(ex.Message);

                    return null;
                }
            }
        }

        public List<int> Sample4()
        {
            var list = new List<int>();
            list.AddRange(new[] { 100, 400, 200, 900, 2300, 1900 });

            return list;
        }
    }
}