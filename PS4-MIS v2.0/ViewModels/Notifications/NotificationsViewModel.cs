using Caliburn.Micro;
using PS4_MIS_v2._0.Model;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PS4_MIS_v2._0.ViewModels.Notifications
{
    internal class NotificationsViewModel : Screen
    {
        private DataTable _baseReadGridItemSource;
        private DataTable _baseUnreadGridItemSource;
        private string _body;
        private string _firstname;
        private string _lastname;
        private List<string> _rank;
        private string _rankSelectedItem;
        private object _readGridSelectedItem;
        private DataTable _readGridSource;
        private string _selectedMessageID;
        private string _subject;
        private object _unreadGridSelectedItem;
        private DataTable _unreadGridSource;
        private IWindowManager windowManager = new WindowManager();
        public string body
        {
            get { return _body; }
            set
            {
                _subject = value;
                DataView dv = new DataView(_baseUnreadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => unreadGridSource);
                dv = new DataView(_baseReadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => readGridSource);
            }
        }

        public string firstname
        {
            get { return _firstname; }
            set
            {
                _subject = value;
                DataView dv = new DataView(_baseUnreadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => unreadGridSource);
                dv = new DataView(_baseReadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => readGridSource);
            }
        }

        public string lastname
        {
            get { return _lastname; }
            set
            {
                _subject = value;
                DataView dv = new DataView(_baseUnreadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => unreadGridSource);
                dv = new DataView(_baseReadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => readGridSource);
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
                _subject = value;
                DataView dv = new DataView(_baseUnreadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => unreadGridSource);
                dv = new DataView(_baseReadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => readGridSource);
            }
        }

        public object readGridSelectedItem
        {
            get { return _readGridSelectedItem; }
            set { _readGridSelectedItem = value; }
        }

        public DataTable readGridSource
        {
            get { return _readGridSource; }
            set { _readGridSource = value; }
        }

        public string subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                DataView dv = new DataView(_baseUnreadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => unreadGridSource);
                dv = new DataView(_baseReadGridItemSource);
                dv.RowFilter = query();
                _unreadGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => readGridSource);
            }
        }

        public object unreadGridSelectedItem
        {
            get { return _unreadGridSelectedItem; }
            set { _unreadGridSelectedItem = value; }
        }

        public DataTable unreadGridSource
        {
            get { return _unreadGridSource; }
            set { _unreadGridSource = value; }
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
                if (_subject != null && _subject != string.Empty)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }

                    sb.Append("Subject Like '%" + _subject.Trim() + "%'");
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

            if (_body != null && _body != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Body like '%" + _body.Trim() + "%'");
            }
            return sb.ToString();
        }

        public void refreshButton()
        {
            _unreadGridSource = connection.dbTable("select `messages`.`Message_ID`,`messages`.`Subject`,`messages`.`Body`,`employeerecords`.`Rank`, `employeerecords`.`First_Name`, `employeerecords`.`Last_Name`, `employeerecords`.`Department` from messages INNER JOIN employeerecords on `messages`.`Sender` = `employeerecords`.`Employee_ID` where `messages`.`Receiver` = " + currentUser.EmployeeID + " AND isAcknowledged = 0;");
            _baseUnreadGridItemSource = _unreadGridSource;
            NotifyOfPropertyChange(() => unreadGridSource);
            _readGridSource = connection.dbTable("select `messages`.`Message_ID`,`messages`.`Subject`,`messages`.`Body`,`employeerecords`.`Rank`, `employeerecords`.`First_Name`, `employeerecords`.`Last_Name`, `employeerecords`.`Department` from messages INNER JOIN employeerecords on `messages`.`Sender` = `employeerecords`.`Employee_ID` where `messages`.`Receiver` = " + currentUser.EmployeeID + " AND isAcknowledged = 1;");
            _baseReadGridItemSource = _readGridSource;
            NotifyOfPropertyChange(() => readGridSource);
        }

        public void resetButton()
        {
            _rankSelectedItem = string.Empty;
            _firstname = string.Empty;
            _subject = string.Empty;
            _lastname = string.Empty;
            _body = string.Empty;
            _unreadGridSource = connection.dbTable("select `messages`.`Message_ID`,`messages`.`Subject`,`messages`.`Body`,`employeerecords`.`Rank`, `employeerecords`.`First_Name`, `employeerecords`.`Last_Name`, `employeerecords`.`Department` from messages INNER JOIN employeerecords on `messages`.`Sender` = `employeerecords`.`Employee_ID` where `messages`.`Receiver` = " + currentUser.EmployeeID + " AND isAcknowledged = 0;");
            _baseUnreadGridItemSource = _unreadGridSource;
            _readGridSource = connection.dbTable("select `messages`.`Message_ID`,`messages`.`Subject`,`messages`.`Body`,`employeerecords`.`Rank`, `employeerecords`.`First_Name`, `employeerecords`.`Last_Name`, `employeerecords`.`Department` from messages INNER JOIN employeerecords on `messages`.`Sender` = `employeerecords`.`Employee_ID` where `messages`.`Receiver` = " + currentUser.EmployeeID + " AND isAcknowledged = 1;");
            _baseReadGridItemSource = _readGridSource;
            NotifyOfPropertyChange(null);
        }

        public void showReadMessage()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_readGridSelectedItem;
                _selectedMessageID = dataRowView.Row[0].ToString();
                windowManager.ShowWindow(new ShowNotificationViewModel(_selectedMessageID), null, null);
            }
            catch { }
        }

        public void showUnreadMessage()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_unreadGridSelectedItem;
                _selectedMessageID = dataRowView.Row[0].ToString();
                windowManager.ShowWindow(new ShowNotificationViewModel(_selectedMessageID), null, null);
            }
            catch { }
        }

        protected override void OnActivate()
        {
            _unreadGridSource = connection.dbTable("select `messages`.`Message_ID`,`messages`.`Subject`,`messages`.`Body`,`employeerecords`.`Rank`, `employeerecords`.`First_Name`, `employeerecords`.`Last_Name`, `employeerecords`.`Department` from messages INNER JOIN employeerecords on `messages`.`Sender` = `employeerecords`.`Employee_ID` where `messages`.`Receiver` = " + currentUser.EmployeeID + " AND isAcknowledged = 0;");
            _baseUnreadGridItemSource = _unreadGridSource;
            NotifyOfPropertyChange(() => unreadGridSource);
            _readGridSource = connection.dbTable("select `messages`.`Message_ID`,`messages`.`Subject`,`messages`.`Body`,`employeerecords`.`Rank`, `employeerecords`.`First_Name`, `employeerecords`.`Last_Name`, `employeerecords`.`Department` from messages INNER JOIN employeerecords on `messages`.`Sender` = `employeerecords`.`Employee_ID` where `messages`.`Receiver` = " + currentUser.EmployeeID + " AND isAcknowledged = 1;");
            _baseReadGridItemSource = _readGridSource;
            NotifyOfPropertyChange(() => readGridSource);
            base.OnActivate();
        }
    }
}