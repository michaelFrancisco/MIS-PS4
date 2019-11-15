using Caliburn.Micro;
using PS4_MIS_v2._0.ViewModels.EmployeeRecords;
using PS4_MIS_v2._0.ViewModels.PoliceReports;
using System;
using System.Data;
using System.Linq;
using System.Text;

namespace PS4_MIS_v2._0.ViewModels
{
    internal class PoliceReportsViewModel : Screen
    {
        private DataTable _baseIRFGridItemSource;
        private string _blotterentryno;
        private string _firstname;
        private object _irfGridSelectedItem;
        private DataTable _irfGridItemSource;
        private string _lastname;
        private string _selectedIRFID;
        private string _typeofincident;
        private IWindowManager windowManager = new WindowManager();

        public string blotterentryno
        {
            get { return _blotterentryno; }
            set
            {
                _blotterentryno = value;
                DataView dv = new DataView(_baseIRFGridItemSource);
                dv.RowFilter = query();
                _irfGridItemSource = dv.ToTable();
                NotifyOfPropertyChange(() => irfGridItemSource);
            }
        }

        public string firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                DataView dv = new DataView(_baseIRFGridItemSource);
                dv.RowFilter = query();
                _irfGridItemSource = dv.ToTable();
                NotifyOfPropertyChange(() => irfGridItemSource);
            }
        }

        public object irfGridSelectedItem
        {
            get { return _irfGridSelectedItem; }
            set { _irfGridSelectedItem = value; }
        }

        public DataTable irfGridItemSource
        {
            get { return _irfGridItemSource; }
            set { _irfGridItemSource = value; }
        }

        public string lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                DataView dv = new DataView(_baseIRFGridItemSource);
                dv.RowFilter = query();
                _irfGridItemSource = dv.ToTable();
                NotifyOfPropertyChange(() => irfGridItemSource);
            }
        }

        public string typeofincident
        {
            get { return _typeofincident; }
            set
            {
                _typeofincident = value;
                DataView dv = new DataView(_baseIRFGridItemSource);
                dv.RowFilter = query();
                _irfGridItemSource = dv.ToTable();
                NotifyOfPropertyChange(() => irfGridItemSource);
            }
        }

        public void addIRF()
        {
            windowManager.ShowWindow(new AddIRFViewModel(), null, null);
        }

        public string query()
        {
            StringBuilder sb = new StringBuilder();
            if (_typeofincident != null && _typeofincident != string.Empty)
            {
                sb.Append("Type_Of_Incident like '%" + _typeofincident.Trim() + "%'");
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

                sb.Append("Family_Name like '%" + _lastname.Trim() + "%'");
            }

            try
            {
                if (_blotterentryno != null && _blotterentryno != string.Empty)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }

                    sb.Append("Blotter_Entry_Number like '%" + _blotterentryno + "%'");
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

            return sb.ToString();
        }

        public void refreshButton()
        {
            _irfGridItemSource = connection.dbTable("SELECT IRF_ID, Blotter_Entry_Number, Type_Of_Incident, DateTime_Reported, DateTime_of_Incident, Recorded_By FROM `ps4`.`irf`;");
            _baseIRFGridItemSource = _irfGridItemSource;
            NotifyOfPropertyChange(() => irfGridItemSource);
        }

        public void resetButton()
        {
            _firstname = string.Empty;
            _blotterentryno = string.Empty;
            _lastname = string.Empty;
            _irfGridItemSource = connection.dbTable("SELECT IRF_ID, Blotter_Entry_Number, Type_Of_Incident, DateTime_Reported, DateTime_of_Incident, Recorded_By FROM `ps4`.`irf`;");
            _baseIRFGridItemSource = _irfGridItemSource;
            NotifyOfPropertyChange(null);
        }

        public void showIRF()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_irfGridSelectedItem;
                _selectedIRFID = dataRowView.Row[0].ToString();
                windowManager.ShowWindow(new EditIRFViewModel(_selectedIRFID), null, null);
            }
            catch { }
        }

        protected override void OnActivate()
        {
            _irfGridItemSource = connection.dbTable("SELECT IRF_ID, Blotter_Entry_Number, Type_Of_Incident, DateTime_Reported, DateTime_of_Incident, Recorded_By FROM `ps4`.`irf`;");
            _baseIRFGridItemSource = _irfGridItemSource;
            NotifyOfPropertyChange(() => irfGridItemSource);
            base.OnActivate();
        }
    }
}