using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS4_MIS_v2._0.ViewModels.CriminalRecords;
using System.Data;
using System.Windows;

namespace PS4_MIS_v2._0.ViewModels
{
    class CriminalRecordsViewModel : Screen
    {
        private DataTable _basecriminalRecordsGridItemSource;
        private string _crime;
        private string _criminalID;
        private object _criminalRecordDatagridSelectedItem;
        private DataTable _criminalRecordsGridItemSource;
        private string _firstname;
        private string _lastname;
        private string _location;
        private int _selectedCriminalID;
        IWindowManager windowManager = new WindowManager();
        public string crime
        {
            get { return _crime; }
            set
            {
                _crime = value;
                DataView dv = new DataView(_basecriminalRecordsGridItemSource);
                dv.RowFilter = query();
                _criminalRecordsGridItemSource = dv.ToTable();
                NotifyOfPropertyChange(() => criminalRecordsGridItemSource);
            }
        }

        public string criminalID
        {
            get { return _criminalID; }
            set
            {
                _criminalID = value;
                DataView dv = new DataView(_basecriminalRecordsGridItemSource);
                dv.RowFilter = query();
                _criminalRecordsGridItemSource = dv.ToTable();
                NotifyOfPropertyChange(() => criminalRecordsGridItemSource);
            }
        }

        public object criminalRecordDatagridSelectedItem
        {
            get { return _criminalRecordDatagridSelectedItem; }
            set { _criminalRecordDatagridSelectedItem = value; }
        }

        public DataTable criminalRecordsGridItemSource
        {
            get { return _criminalRecordsGridItemSource; }
            set { _criminalRecordsGridItemSource = value; }
        }

        public string firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                DataView dv = new DataView(_basecriminalRecordsGridItemSource);
                dv.RowFilter = query();
                _criminalRecordsGridItemSource = dv.ToTable();
                NotifyOfPropertyChange(() => criminalRecordsGridItemSource);
            }
        }

        public string lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                DataView dv = new DataView(_basecriminalRecordsGridItemSource);
                dv.RowFilter = query();
                _criminalRecordsGridItemSource = dv.ToTable();
                NotifyOfPropertyChange(() => criminalRecordsGridItemSource);
            }
        }

        public string location
        {
            get { return _location; }
            set
            {
                _location = value;
                DataView dv = new DataView(_basecriminalRecordsGridItemSource);
                dv.RowFilter = query();
                _criminalRecordsGridItemSource = dv.ToTable();
                NotifyOfPropertyChange(() => criminalRecordsGridItemSource);
            }
        }

        public void addCriminalRecordButton()
        {
            windowManager.ShowWindow(new AddCriminalRecordViewModel(), null, null);
        }

        public string query()
        {
            StringBuilder sb = new StringBuilder();
            if (_firstname != null && _firstname != string.Empty)
            {
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

            if (_crime != null && _crime != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Crime like '%" + _crime.Trim() + "%'");
            }

            if (_criminalID != null && _criminalID != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Criminal_ID like '%" + _criminalID.Trim() + "%'");
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
            _criminalRecordsGridItemSource = connection.dbTable("SELECT Criminal_ID, First_Name, Middle_Name, Last_Name, Sex, Birthdate, Age, Birthplace, Address, Crime, Place_of_Arrest, Arresting_Officer, Date_of_Arrest, Eye_Color, Hair_Color, Remarks FROM `ps4`.`criminalrecords`;");
            _basecriminalRecordsGridItemSource = _criminalRecordsGridItemSource;
            NotifyOfPropertyChange(() => criminalRecordsGridItemSource);
        }

        public void resetButton()
        {
            _firstname = string.Empty;
            _lastname = string.Empty;
            _criminalID = string.Empty;
            _crime = string.Empty;
            _location = string.Empty;
            _criminalRecordsGridItemSource = connection.dbTable("SELECT Criminal_ID, First_Name, Middle_Name, Last_Name, Sex, Birthdate, Age, Birthplace, Address, Crime, Place_of_Arrest, Arresting_Officer, Date_of_Arrest, Eye_Color, Hair_Color, Remarks FROM `ps4`.`criminalrecords`;");
            _basecriminalRecordsGridItemSource = _criminalRecordsGridItemSource;
            NotifyOfPropertyChange(() => firstname);
            NotifyOfPropertyChange(() => lastname);
            NotifyOfPropertyChange(() => criminalID);
            NotifyOfPropertyChange(() => crime);
            NotifyOfPropertyChange(() => location);
            NotifyOfPropertyChange(() => criminalRecordsGridItemSource);
        }

        public void showCriminalRecord()
        {
            DataRowView dataRowView = (DataRowView)_criminalRecordDatagridSelectedItem;
            _selectedCriminalID = Convert.ToInt32(dataRowView.Row[0]);
            windowManager.ShowWindow(new EditCriminalRecordViewModel(_selectedCriminalID), null, null);
        }

        protected override void OnActivate()
        {
            _criminalRecordsGridItemSource = connection.dbTable("SELECT Criminal_ID, First_Name, Middle_Name, Last_Name, Sex, Birthdate, Age, Birthplace, Address, Crime, Place_of_Arrest, Arresting_Officer, Date_of_Arrest, Eye_Color, Hair_Color, Remarks FROM `ps4`.`criminalrecords`;");
            _basecriminalRecordsGridItemSource = _criminalRecordsGridItemSource;
            NotifyOfPropertyChange(() => criminalRecordsGridItemSource);
            base.OnActivate();
        }
    }
}