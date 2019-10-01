using Caliburn.Micro;
using PS4_MIS_v2._0.ViewModels.EmployeeRecords;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_MIS_v2._0.ViewModels
{
    class EmployeeRecordsViewModel : Screen
    {
        private DataTable _baseEmployeeGridItemSource;
        private string _department;
        private object _employeeGridSelectedItem;
        private DataTable _employeeGridSource;
        private string _employeeID;
        private string _firstname;
        private string _lastname;
        private List<string> _rank;
        private string _selectedEmployeeID;
        IWindowManager windowManager = new WindowManager();
        public string department
        {
            get { return _department; }
            set
            {
                _department = value;
                DataView dv = new DataView(_baseEmployeeGridItemSource);
                dv.RowFilter = query();
                _employeeGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => employeeGridSource);
            }
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

        private string _rankSelectedItem;

        public string rankSelectedItem
        {
            get { return _rankSelectedItem; }
            set
            {
                _rankSelectedItem = value;
                DataView dv = new DataView(_baseEmployeeGridItemSource);
                dv.RowFilter = query();
                _employeeGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => employeeGridSource);
            }
        }


        public string employeeID
        {
            get { return _employeeID; }
            set
            {
                _employeeID = value;
                DataView dv = new DataView(_baseEmployeeGridItemSource);
                dv.RowFilter = query();
                _employeeGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => employeeGridSource);
            }
        }

        public string firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                DataView dv = new DataView(_baseEmployeeGridItemSource);
                dv.RowFilter = query();
                _employeeGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => employeeGridSource);
            }
        }

        public string lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                DataView dv = new DataView(_baseEmployeeGridItemSource);
                dv.RowFilter = query();
                _employeeGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => employeeGridSource);
            }
        }

        public List<string> rank
        {
            get { return new List<string> { "Patrolman/Patrolwoman", "Police Corporal", "Police Staff Sergeant", "Police Master Sergeant", "Police Senior Master Sergeant", "Police Chief Master Sergeant", "Police Executive Master Sergeant", "Police Lieutenant", "Police Captain", "Police Major", "Police Lieutenant Colonel", "Police Colonel", "Police Brigadier General", "Police Major General", "Police Lieutenant General", "Police General" }; }
            set
            {
                _rank = value;
            }
        }
        public void addemployeerecordButton()
        {
            windowManager.ShowWindow(new AddEmployeeRecordViewModel(), null, null);
        }

        public string query()
        {
            StringBuilder sb = new StringBuilder();
            if (_rankSelectedItem != null && _rankSelectedItem != string.Empty)
            {
                sb.Append("Rank like '%" + _rankSelectedItem.Trim() + "%'");
            }

            if (_firstname != null && _firstname != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("First_Name like '%" + _firstname.Trim() + "%'");
            }

            if (_lastname != null && _lastname != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Last_Name like '%" + _lastname.Trim() + "%'");
            }

            try
            {
                if (_employeeID != null && _employeeID != string.Empty)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }

                    sb.Append("Employee_ID = " + Int32.Parse(_employeeID) + "");
                }
            }
            catch { }

            if (_department != null && _department != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Department like '%" + _department.Trim() + "%'");
            }
            return sb.ToString();
        }

        public void refreshButton()
        {
            _employeeGridSource = connection.dbTable("SELECT Employee_ID, Rank, First_Name, Midle_Name, Last_Name, Department, Sex, Birthdate, Age, Birthplace, Civil_Status, Address, Position, User_Level FROM `ps4`.`employeerecords`;");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => employeeGridSource);
        }

        public void resetButton()
        {
            _rankSelectedItem = string.Empty;
            _firstname = string.Empty;
            _employeeID = string.Empty;
            _lastname = string.Empty;
            _department = string.Empty;
            _employeeGridSource = connection.dbTable("SELECT Employee_ID, Rank, First_Name, Midle_Name, Last_Name, Department, Sex, Birthdate, Age, Birthplace, Civil_Status, Address, Position, User_Level FROM `ps4`.`employeerecords`;");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => rankSelectedItem);
            NotifyOfPropertyChange(() => firstname);
            NotifyOfPropertyChange(() => employeeID);
            NotifyOfPropertyChange(() => lastname);
            NotifyOfPropertyChange(() => department);
            NotifyOfPropertyChange(() => employeeGridSource);
        }

        public void showEmployeeRecord()
        {
            DataRowView dataRowView = (DataRowView)_employeeGridSelectedItem;
            _selectedEmployeeID = dataRowView.Row[0].ToString();
            windowManager.ShowWindow(new EditEmployeeRecordViewModel(_selectedEmployeeID), null, null);
        }

        protected override void OnActivate()
        {
            _employeeGridSource = connection.dbTable("SELECT Employee_ID, Rank, First_Name, Midle_Name, Last_Name, Department, Sex, Birthdate, Age, Birthplace, Civil_Status, Address, Position, User_Level FROM `ps4`.`employeerecords`;");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => employeeGridSource);
            base.OnActivate();
        }
    }
}
