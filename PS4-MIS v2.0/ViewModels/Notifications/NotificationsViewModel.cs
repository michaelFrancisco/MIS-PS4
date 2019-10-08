using Caliburn.Micro;
using PS4_MIS_v2._0.Model;
using PS4_MIS_v2._0.ViewModels.EmployeeRecords;
using PS4_MIS_v2._0.ViewModels.Messages;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PS4_MIS_v2._0.ViewModels.Notifications
{
    class NotificationsViewModel : Screen
    {
        private DataTable _baseMessagesGridItemSource;
        private string _body;
        private object _messagesGridSelectedItem;
        private DataTable _messagesGridSource;
        private string _subject;
        private string _firstname;
        private string _lastname;
        private List<string> _rank;
        private string _rankSelectedItem;
        private string _selectedMessageID;
        private IWindowManager windowManager = new WindowManager();

        public string body
        {
            get { return _body; }
            set
            {
                _body = value;
                DataView dv = new DataView(_baseMessagesGridItemSource);
                dv.RowFilter = query();
                _messagesGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => messagesGridSource);
            }
        }

        public object messagesGridSelectedItem
        {
            get { return _messagesGridSelectedItem; }
            set { _messagesGridSelectedItem = value; }
        }

        public DataTable messagesGridSource
        {
            get { return _messagesGridSource; }
            set { _messagesGridSource = value; }
        }

        public string subject
        {
            get { return _subject; }
            set
            {
                _subject = value;
                DataView dv = new DataView(_baseMessagesGridItemSource);
                dv.RowFilter = query();
                _messagesGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => messagesGridSource);
            }
        }

        public string firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                DataView dv = new DataView(_baseMessagesGridItemSource);
                dv.RowFilter = query();
                _messagesGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => messagesGridSource);
            }
        }

        public string lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                DataView dv = new DataView(_baseMessagesGridItemSource);
                dv.RowFilter = query();
                _messagesGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => messagesGridSource);
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
                DataView dv = new DataView(_baseMessagesGridItemSource);
                dv.RowFilter = query();
                _messagesGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => messagesGridSource);
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
            _messagesGridSource = connection.dbTable("select `messages`.`Message_ID`,`messages`.`Subject`,`messages`.`Body`,`employeerecords`.`Rank`, `employeerecords`.`First_Name`, `employeerecords`.`Last_Name`, `employeerecords`.`Department` from messages INNER JOIN employeerecords on `messages`.`Sender` = `employeerecords`.`Employee_ID` where `messages`.`Receiver` = " + currentUser.EmployeeID + " AND isAcknowledged = 0;");
            _baseMessagesGridItemSource = _messagesGridSource;
            NotifyOfPropertyChange(() => messagesGridSource);
        }

        public void resetButton()
        {
            _rankSelectedItem = string.Empty;
            _firstname = string.Empty;
            _subject = string.Empty;
            _lastname = string.Empty;
            _body = string.Empty;
            _messagesGridSource = connection.dbTable("select `messages`.`Message_ID`,`messages`.`Subject`,`messages`.`Body`,`employeerecords`.`Rank`, `employeerecords`.`First_Name`, `employeerecords`.`Last_Name`, `employeerecords`.`Department` from messages INNER JOIN employeerecords on `messages`.`Sender` = `employeerecords`.`Employee_ID` where `messages`.`Receiver` = " + currentUser.EmployeeID + " AND isAcknowledged = 0;");
            _baseMessagesGridItemSource = _messagesGridSource;
            NotifyOfPropertyChange(() => rankSelectedItem);
            NotifyOfPropertyChange(() => firstname);
            NotifyOfPropertyChange(() => subject);
            NotifyOfPropertyChange(() => lastname);
            NotifyOfPropertyChange(() => body);
            NotifyOfPropertyChange(() => messagesGridSource);
        }

        public void showMessage()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_messagesGridSelectedItem;
                _selectedMessageID = dataRowView.Row[0].ToString();
                windowManager.ShowWindow(new ShowNotificationViewModel(_selectedMessageID), null, null);
            }
            catch { }
        }

        protected override void OnActivate()
        {
            _messagesGridSource = connection.dbTable("select `messages`.`Message_ID`,`messages`.`Subject`,`messages`.`Body`,`employeerecords`.`Rank`, `employeerecords`.`First_Name`, `employeerecords`.`Last_Name`, `employeerecords`.`Department` from messages INNER JOIN employeerecords on `messages`.`Sender` = `employeerecords`.`Employee_ID` where `messages`.`Receiver` = "+currentUser.EmployeeID+" AND isAcknowledged = 0;");
            _baseMessagesGridItemSource = _messagesGridSource;
            NotifyOfPropertyChange(() => messagesGridSource);
            base.OnActivate();
        }
    }
}
