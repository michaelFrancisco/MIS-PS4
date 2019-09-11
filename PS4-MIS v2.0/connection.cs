using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Odbc;
using System.Data;

namespace PS4_MIS_v2._0
{
    class connection
    {

        public static DataTable dbCommand(string command)
        {
            OdbcConnection dbConnection = new OdbcConnection("DSN=BEAR");
            dbConnection.Open();
            OdbcCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = command;
            OdbcDataReader DbReader = dbCommand.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(DbReader);
            dbConnection.Close();
            return dt;
        }
        public static bool verifyLogin(string username, string password)
        {
            DataTable dt = dbCommand("select * from users where username='" + username + "' and password = '" + password + "';");
            if (dt.Rows.Count > 0)
                return true;
            else
                return false;
        }
        
        //public static string getUserlevel()
        //{
        //    DataTable dt = dbCommand("select * from users where username='" + username + "' and password = '" + password + "';");
        //    return null;
        //}
    }
}
