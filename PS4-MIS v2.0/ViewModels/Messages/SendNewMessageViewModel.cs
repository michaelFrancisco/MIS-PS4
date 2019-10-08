using Caliburn.Micro;
using PS4_MIS_v2._0.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace PS4_MIS_v2._0.ViewModels.Messages
{
    internal class SendNewMessageViewModel : Screen
    {
        private DataTable _baseEmployeeGridItemSource;
        private DataTable _baseRecipientsGridSource;
        private string _body;
        private string _department;
        private object _employeeGridSelectedItem;
        private DataTable _employeeGridSource;
        private string _employeeID;
        private string _firstname;
        private string _lastname;
        private List<string> _rank;
        private string _rankSelectedItem;
        private object _recipientsGridSelectedItem;
        private DataTable _recipientsGridSource;
        private string _selectedEmployeeID;
        private string _subject;
        private IWindowManager windowManager = new WindowManager();

        public string body
        {
            get { return _body; }
            set { _body = value; }
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

        public object recipientsGridSelectedItem
        {
            get { return _recipientsGridSelectedItem; }
            set { _recipientsGridSelectedItem = value; }
        }

        public DataTable recipientsGridSource
        {
            get { return _recipientsGridSource; }
            set { _recipientsGridSource = value; }
        }

        public string subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        public void addButton()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_employeeGridSelectedItem;
                _recipientsGridSource.Rows.Add(dataRowView.Row[0], dataRowView.Row[1], dataRowView.Row[2], dataRowView.Row[3], dataRowView.Row[4], dataRowView.Row[5], dataRowView.Row[6], dataRowView.Row[7], dataRowView.Row[8], dataRowView.Row[9], dataRowView.Row[10], dataRowView.Row[11], dataRowView.Row[12], dataRowView.Row[13]);
                _employeeGridSource.Rows.Remove(dataRowView.Row);
                NotifyOfPropertyChange(() => recipientsGridSource);
                NotifyOfPropertyChange(() => employeeGridSource);
            }
            catch { }
        }

        public void cancelButton()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
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

        public void sendmessageButton()
        {
            int j = _recipientsGridSource.Rows.Count;
            for (int i = 0; i < j; i++)
            {
                connection.dbCommand("INSERT INTO `ps4`.`messages` (`Sender`, `Receiver`, `Subject`, `Body`, `isAcknowledged`) VALUES ('" + currentUser.EmployeeID + "', '" + _recipientsGridSource.Rows[i][0].ToString() + "', '" + _subject + "', '" + _body + "', '0');");
            }
            TryClose();
        }

        public void subtractButton()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_recipientsGridSelectedItem;
                _employeeGridSource.Rows.Add(dataRowView.Row[0], dataRowView.Row[1], dataRowView.Row[2], dataRowView.Row[3], dataRowView.Row[4], dataRowView.Row[5], dataRowView.Row[6], dataRowView.Row[7], dataRowView.Row[8], dataRowView.Row[9], dataRowView.Row[10], dataRowView.Row[11], dataRowView.Row[12], dataRowView.Row[13]);
                _recipientsGridSource.Rows.Remove(dataRowView.Row);
                NotifyOfPropertyChange(() => recipientsGridSource);
                NotifyOfPropertyChange(() => employeeGridSource);
            }
            catch { }
        }

        protected override void OnActivate()
        {
            _employeeGridSource = connection.dbTable("SELECT Employee_ID, Rank, First_Name, Midle_Name, Last_Name, Department, Sex, Birthdate, Age, Birthplace, Civil_Status, Address, Position, User_Level FROM `ps4`.`employeerecords`;");
            _recipientsGridSource = connection.dbTable("SELECT Employee_ID, Rank, First_Name, Midle_Name, Last_Name, Department, Sex, Birthdate, Age, Birthplace, Civil_Status, Address, Position, User_Level FROM `ps4`.`employeerecords` where null;");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => employeeGridSource);
            NotifyOfPropertyChange(() => recipientsGridSource);
            base.OnActivate();
        }
    }
}