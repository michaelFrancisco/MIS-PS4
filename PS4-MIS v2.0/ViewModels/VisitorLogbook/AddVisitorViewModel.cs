using Caliburn.Micro;
using PS4_MIS_v2._0.Model;
using System.Data;

namespace PS4_MIS_v2._0.ViewModels.VisitorLogbook
{
    internal class AddVisitorViewModel : Screen
    {
        private DataTable _baseEmployeeGridItemSource;

        private object _employeeGridSelectedItem;
        private DataTable _employeeGridSource;

        private string _firstname;

        private string _lastname;

        public DataTable baseEmployeeGridItemSource
        {
            get { return _baseEmployeeGridItemSource; }
            set { _baseEmployeeGridItemSource = value; }
        }

        public object employeeGridSelectedItem
        {
            get { return _employeeGridSelectedItem; }
            set { _employeeGridSelectedItem = value; }
        }

        public DataTable employeeGridSource
        {
            get { return _employeeGridSource; }
            set { _employeeGridSource = value; }
        }
        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        private string _selectedEmployeeID;



        public void saveButton()
        {
            DataRowView dataRowView = (DataRowView)_employeeGridSelectedItem;
            _selectedEmployeeID = dataRowView.Row[0].ToString();
            connection.dbCommand("INSERT INTO `ps4`.`visit_log` (`First_Name`, `Last_Name`, `Person_To_Visit`, `In_Time`, `Status`) VALUES ('"+_firstname+"', '"+_lastname+"', '"+_selectedEmployeeID+"', CURRENT_TIMESTAMP, 'IN');");
            DataTable dt2 = connection.dbTable("select MAX(Visit_ID) from visit_log");
            connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Visit Log','" + dt2.Rows[0][0].ToString() + "', '" + currentUser.EmployeeID + "', 'Visitor Logged In')");
            TryClose();
        }
        protected override void OnActivate()
        {
            _employeeGridSource = connection.dbTable("SELECT Criminal_ID, First_Name, Middle_Name, Last_Name FROM `ps4`.`criminalrecords`;");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => employeeGridSource);
        }
    }
}