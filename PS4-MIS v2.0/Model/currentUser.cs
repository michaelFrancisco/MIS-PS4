using System.Data;

namespace PS4_MIS_v2._0.Model
{
    internal class currentUser
    {
        public static string EmployeeID;
        public static string Firstname;
        public static string Lastname;
        public static string Rank;
        public static string UserLevel;

        public static void getUserDetails(string _employeeID)
        {
            DataTable dt = connection.dbTable("SELECT Rank, First_Name, Last_Name, User_Level FROM ps4.employeerecords where Employee_ID = " + _employeeID + ";");
            Rank = dt.Rows[0][0].ToString();
            Firstname = dt.Rows[0][1].ToString();
            Lastname = dt.Rows[0][2].ToString();
            UserLevel = dt.Rows[0][3].ToString();
            EmployeeID = _employeeID;
        }
    }
}