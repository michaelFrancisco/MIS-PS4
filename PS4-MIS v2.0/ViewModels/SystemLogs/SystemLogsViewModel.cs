using Caliburn.Micro;
using PS4_MIS_v2._0.ViewModels.EmployeeRecords;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_MIS_v2._0.ViewModels.SystemLogs
{
    class SystemLogsViewModel : Screen
    {
        private DataTable _baseEmployeeGridItemSource;
        private string _type;
        private DataTable _employeeGridSource;
        private string _employeeID;
        private string _firstname;
        private string _lastname;
        private List<string> _rank;
        private string _rankSelectedItem;
        IWindowManager windowManager = new WindowManager();

        public string type
        {
            get { return _type; }
            set
            {
                _type = value;
                DataView dv = new DataView(_baseEmployeeGridItemSource);
                dv.RowFilter = query();
                _employeeGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => logsGridSource);
            }
        }


        public DataTable logsGridSource
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
                NotifyOfPropertyChange(() => logsGridSource);
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
                NotifyOfPropertyChange(() => logsGridSource);
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
                NotifyOfPropertyChange(() => logsGridSource);
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
                NotifyOfPropertyChange(() => logsGridSource);
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

            if (_type != null && _type != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Type like '%" + _type.Trim() + "%'");
            }
            return sb.ToString();
        }

        public void refreshButton()
        {
            _employeeGridSource = connection.dbTable("SELECT `system_log`.`Time`,`system_log`.`Type`,`employeerecords`.`Rank`,`employeerecords`.`First_Name`,`employeerecords`.`Last_Name`, `system_log`.`Action`, `system_log`.`Item_ID`, `employeerecords`.`Employee_ID` FROM system_log LEFT JOIN employeerecords ON `system_log`.`User` = `employeerecords`.`Employee_ID` ORDER BY `system_log`.`Time` DESC;");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => logsGridSource);
        }

        public void resetButton()
        {
            _rankSelectedItem = string.Empty;
            _firstname = string.Empty;
            _employeeID = string.Empty;
            _lastname = string.Empty;
            _type = string.Empty;
            _employeeGridSource = connection.dbTable("SELECT `system_log`.`Time`,`system_log`.`Type`,`employeerecords`.`Rank`,`employeerecords`.`First_Name`,`employeerecords`.`Last_Name`, `system_log`.`Action`, `system_log`.`Item_ID`, `employeerecords`.`Employee_ID` FROM system_log LEFT JOIN employeerecords ON `system_log`.`User` = `employeerecords`.`Employee_ID` ORDER BY `system_log`.`Time` DESC;");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => rankSelectedItem);
            NotifyOfPropertyChange(() => firstname);
            NotifyOfPropertyChange(() => employeeID);
            NotifyOfPropertyChange(() => lastname);
            NotifyOfPropertyChange(() => type);
            NotifyOfPropertyChange(() => logsGridSource);
        }

        protected override void OnActivate()
        {
            _employeeGridSource = connection.dbTable("SELECT `system_log`.`Time`,`system_log`.`Type`,`employeerecords`.`Rank`,`employeerecords`.`First_Name`,`employeerecords`.`Last_Name`, `system_log`.`Action`, `system_log`.`Item_ID`, `employeerecords`.`Employee_ID` FROM system_log LEFT JOIN employeerecords ON `system_log`.`User` = `employeerecords`.`Employee_ID` ORDER BY `system_log`.`Time` DESC;");
            _baseEmployeeGridItemSource = _employeeGridSource;
            NotifyOfPropertyChange(() => logsGridSource);
            base.OnActivate();
        }
    }
}
