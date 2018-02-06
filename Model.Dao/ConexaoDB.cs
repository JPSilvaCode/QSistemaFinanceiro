using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dao
{
    class ConexaoDB
    {
        private static ConexaoDB conexaoDB = null;
        private SqlConnection sqlConnection;

        private ConexaoDB()
        {
            sqlConnection = new SqlConnection(@"Data Source=0.0.0.0,1433;Initial Catalog=Financeiro;User ID=sa;Password=000000");
        }

        public static ConexaoDB SaberEstado()
        {
            if (conexaoDB == null)
                conexaoDB = new ConexaoDB();

            return conexaoDB;
        }

        public SqlConnection GetSqlConnection()
        {
            return sqlConnection;
        }

        public void CloseDB()
        {
            conexaoDB = null;
        }
    }
}
