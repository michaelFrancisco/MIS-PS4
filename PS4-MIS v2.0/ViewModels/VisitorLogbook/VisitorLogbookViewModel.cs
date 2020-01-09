using Caliburn.Micro;
using PS4_MIS_v2._0.Model;
using PS4_MIS_v2._0.ViewModels.VisitorLogbook;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace PS4_MIS_v2._0.ViewModels
{
    internal class VisitorLogbookViewModel : Screen
    {
        private DataTable _baseEmployeeGridItemSource;
        private DataTable _baseLogGridSource;
        private string _department;
        private object _employeeGridSelectedItem;
        private DataTable _employeeGridSource;
        private string _employeeID;
        private string _firstname;
        private string _lastname;
        private DataTable _logGridSource;
        private List<string> _rank;
        private string _rankSelectedItem;
        private string _selectedEmployeeID;
        private IWindowManager windowManager = new WindowManager();

        public DataTable baseLogGridSource
        {
            get { return _baseLogGridSource; }
            set { _baseLogGridSource = value; }
        }

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

        public DataTable logGridSource
        {
            get { return _logGridSource; }
            set { _logGridSource = value; }
        }

        public List<string> rank
        {
            get { return new List<string> { "Patrolman/Patrolwoman", "Police Corporal", "Police Staff Sergeant", "Police Master Sergeant", "Police Senior Master Sergeant", "Police Chief Master Sergeant", "Police Executive Master Sergeant", "Police Lieutenant", "Police Captain", "Police Major", "Police Lieutenant Colonel", "Police Colonel", "Police Brigadier General", "Police Major General", "Police Lieutenant General", "Police General" }; }
            set
            {
                _rank = value;
            }
        }

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

        public void addemployeerecordButton()
        {
            windowManager.ShowWindow(new AddVisitorViewModel(), null, null);
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
            catch
            {
                try
                {
                    sb.Remove(sb.Length - 5, 5);
                }
                catch { }
            }

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
            _employeeGridSource = connection.dbTable("SELECT * FROM ps4.visit_log where Status = 'IN';");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => employeeGridSource);
            _logGridSource = connection.dbTable("SELECT * FROM ps4.visit_log where Status = 'OUT';");
            NotifyOfPropertyChange(() => logGridSource);
        }

        public void resetButton()
        {
            _rankSelectedItem = string.Empty;
            _firstname = string.Empty;
            _employeeID = string.Empty;
            _lastname = string.Empty;
            _department = string.Empty;
            _employeeGridSource = connection.dbTable("SELECT * FROM ps4.visit_log where Status = 'IN';");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => rankSelectedItem);
            NotifyOfPropertyChange(() => firstname);
            NotifyOfPropertyChange(() => employeeID);
            NotifyOfPropertyChange(() => lastname);
            NotifyOfPropertyChange(() => department);
            NotifyOfPropertyChange(() => employeeGridSource);
            _logGridSource = connection.dbTable("SELECT * FROM ps4.visit_log where Status = 'OUT';");
            NotifyOfPropertyChange(() => logGridSource);
        }

        public void showEmployeeRecord()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_employeeGridSelectedItem;
                _selectedEmployeeID = dataRowView.Row[0].ToString();
                MessageBoxResult dialogResult = MessageBox.Show("Do you want to log out this person?", "!", MessageBoxButton.YesNo);
                if (dialogResult == MessageBoxResult.Yes)
                {
                    connection.dbCommand("UPDATE `ps4`.`visit_log` SET `Out_Time` = CURRENT_TIMESTAMP, `Status` = 'OUT' WHERE (`Visit_ID` = '" + _selectedEmployeeID + "');");
                    connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Visit Log','" + _selectedEmployeeID + "', '" + currentUser.EmployeeID + "', 'Visitor Logged Out')");
                }
            }
            catch { }
        }

        protected override void OnActivate()
        {
            _employeeGridSource = connection.dbTable("SELECT * FROM ps4.visit_log where Status = 'IN';");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => employeeGridSource);
            _logGridSource = connection.dbTable("SELECT * FROM ps4.visit_log where Status = 'OUT';");
            _baseLogGridSource = _logGridSource;
            NotifyOfPropertyChange(() => logGridSource);
            base.OnActivate();
        }
    }
}