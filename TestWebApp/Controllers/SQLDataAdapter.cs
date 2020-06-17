using System.Data.SqlClient;

namespace TestWebApp.Controllers
{
    internal class SQLDataAdapter
    {
        private string commandText;
        private SqlConnection con;

        public SQLDataAdapter(string commandText, SqlConnection con)
        {
            this.commandText = commandText;
            this.con = con;
        }
    }
}