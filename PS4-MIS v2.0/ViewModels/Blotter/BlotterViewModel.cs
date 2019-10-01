using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_MIS_v2._0.ViewModels.Blotter
{
    class BlotterViewModel : Screen
    {
        private DataTable _baseBlotterGridSource;
        private string _typeOfIncident;
        private string _blotterEntryNo;
        private object _blotterGridSelectedItem;
        private DataTable _blotterGridSource;
        private string _firstName;
        private string _lastName;
        private string _location;
        private int _selectedBlotterEntryNo;
        IWindowManager windowManager = new WindowManager();
        public string typeOfIncident
        {
            get { return _typeOfIncident; }
            set
            {
                _typeOfIncident = value;
                DataView dv = new DataView(_baseBlotterGridSource);
                dv.RowFilter = query();
                _blotterGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => blotterGridSource);
            }
        }

        public string blotterEntryNo
        {
            get { return _blotterEntryNo; }
            set
            {
                _blotterEntryNo = value;
                DataView dv = new DataView(_baseBlotterGridSource);
                dv.RowFilter = query();
                _blotterGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => blotterGridSource);
            }
        }

        public object blotterGridSelectedItem
        {
            get { return _blotterGridSelectedItem; }
            set { _blotterGridSelectedItem = value; }
        }

        public DataTable blotterGridSource
        {
            get { return _blotterGridSource; }
            set { _blotterGridSource = value; }
        }

        public string firstName
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                DataView dv = new DataView(_baseBlotterGridSource);
                dv.RowFilter = query();
                _blotterGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => blotterGridSource);
            }
        }

        public string lastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                DataView dv = new DataView(_baseBlotterGridSource);
                dv.RowFilter = query();
                _blotterGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => blotterGridSource);
            }
        }

        public string location
        {
            get { return _location; }
            set
            {
                _location = value;
                DataView dv = new DataView(_baseBlotterGridSource);
                dv.RowFilter = query();
                _blotterGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => blotterGridSource);
            }
        }

        public void newIRFButton()
        {
            windowManager.ShowWindow(new AddNewIRFViewModel(), null, null);
        }

        public string query()
        {
            StringBuilder sb = new StringBuilder();
            if (_firstName != null && _firstName != string.Empty)
            {
                sb.Append("First_Name like '%" + _firstName.Trim() + "%'");
            }

            if (_lastName != null && _lastName != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Last_Name like '%" + _lastName.Trim() + "%'");
            }

            if (_typeOfIncident != null && _typeOfIncident != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Crime like '%" + _typeOfIncident.Trim() + "%'");
            }

            if (_blotterEntryNo != null && _blotterEntryNo != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Criminal_ID like '%" + _blotterEntryNo.Trim() + "%'");
            }

            if (_location != null && _location != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Place_of_Arrest like '%" + _location.Trim() + "%'");
            }
            return sb.ToString();
        }

        public void refreshButton()
        {
            _blotterGridSource = connection.dbTable("SELECT Criminal_ID, First_Name, Middle_Name, Last_Name, Sex, Birthdate, Age, Birthplace, Address, Crime, Place_of_Arrest, Arresting_Officer, Date_of_Arrest, Eye_Color, Hair_Color, Remarks FROM `ps4`.`criminalrecords`;");
            _baseBlotterGridSource = _blotterGridSource;
            NotifyOfPropertyChange(() => blotterGridSource);
        }

        public void resetButton()
        {
            _firstName = string.Empty;
            _lastName = string.Empty;
            _blotterEntryNo = string.Empty;
            _typeOfIncident = string.Empty;
            _location = string.Empty;
            _blotterGridSource = connection.dbTable("SELECT Criminal_ID, First_Name, Middle_Name, Last_Name, Sex, Birthdate, Age, Birthplace, Address, Crime, Place_of_Arrest, Arresting_Officer, Date_of_Arrest, Eye_Color, Hair_Color, Remarks FROM `ps4`.`criminalrecords`;");
            _baseBlotterGridSource = _blotterGridSource;
            NotifyOfPropertyChange(() => firstName);
            NotifyOfPropertyChange(() => lastName);
            NotifyOfPropertyChange(() => blotterEntryNo);
            NotifyOfPropertyChange(() => typeOfIncident);
            NotifyOfPropertyChange(() => location);
            NotifyOfPropertyChange(() => blotterGridSource);
        }

        public void showIRF()
        {
            DataRowView dataRowView = (DataRowView)_blotterGridSelectedItem;
            _selectedBlotterEntryNo = Convert.ToInt32(dataRowView.Row[0]);
            windowManager.ShowWindow(new EditIRFViewModel(_selectedBlotterEntryNo), null, null);
        }

        protected override void OnActivate()
        {
            _blotterGridSource = connection.dbTable("SELECT Criminal_ID, First_Name, Middle_Name, Last_Name, Sex, Birthdate, Age, Birthplace, Address, Crime, Place_of_Arrest, Arresting_Officer, Date_of_Arrest, Eye_Color, Hair_Color, Remarks FROM `ps4`.`criminalrecords`;");
            _baseBlotterGridSource = _blotterGridSource;
            NotifyOfPropertyChange(() => blotterGridSource);
            base.OnActivate();
        }
    }
}