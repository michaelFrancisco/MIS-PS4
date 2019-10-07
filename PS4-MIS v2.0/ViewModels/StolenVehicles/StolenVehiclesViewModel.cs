using Caliburn.Micro;
using PS4_MIS_v2._0.ViewModels.StolenVehicles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace PS4_MIS_v2._0.ViewModels
{
    internal class StolenVehiclesViewModel : Screen
    {
        private DataTable _baseVehicleGridItemSource;
        private string _plateno;
        private object _vehicleGridSelectedItem;
        private DataTable _vehicleGridSource;
        private string _chassisno;
        private string _make;
        private string _model;
        private List<string> _type;
        private string _typeSelectedItem;
        private string _selectedVehicleID;
        private IWindowManager windowManager = new WindowManager();

        public string plateno
        {
            get { return _plateno; }
            set
            {
                _plateno = value;
                DataView dv = new DataView(_baseVehicleGridItemSource);
                dv.RowFilter = query();
                _vehicleGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => vehicleGridSource);
            }
        }

        public object vehicleGridSelectedItem
        {
            get { return _vehicleGridSelectedItem; }
            set { _vehicleGridSelectedItem = value; }
        }

        public DataTable vehicleGridSource
        {
            get { return _vehicleGridSource; }
            set { _vehicleGridSource = value; }
        }

        public string chassisno
        {
            get { return _chassisno; }
            set
            {
                _chassisno = value;
                DataView dv = new DataView(_baseVehicleGridItemSource);
                dv.RowFilter = query();
                _vehicleGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => vehicleGridSource);
            }
        }

        public string make
        {
            get { return _make; }
            set
            {
                _make = value;
                DataView dv = new DataView(_baseVehicleGridItemSource);
                dv.RowFilter = query();
                _vehicleGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => vehicleGridSource);
            }
        }

        public string model
        {
            get { return _model; }
            set
            {
                _model = value;
                DataView dv = new DataView(_baseVehicleGridItemSource);
                dv.RowFilter = query();
                _vehicleGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => vehicleGridSource);
            }
        }

        public List<string> type
        {
            get { return new List<string> { "Car", "Motorcycle", "Bicycle", "Truck", "Other" }; }
            set
            {
                _type = value;
                DataView dv = new DataView(_baseVehicleGridItemSource);
                dv.RowFilter = query();
                _vehicleGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => vehicleGridSource);
            }
        }

        public string typeSelectedItem
        {
            get { return _typeSelectedItem; }
            set
            {
                _typeSelectedItem = value;
                DataView dv = new DataView(_baseVehicleGridItemSource);
                dv.RowFilter = query();
                _vehicleGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => vehicleGridSource);
            }
        }

        public void addstolenvehicleButton()
        {
            windowManager.ShowWindow(new AddVehicleViewModel(), null, null);
        }

        public string query()
        {
            StringBuilder sb = new StringBuilder();
            if (_typeSelectedItem != null && _typeSelectedItem != string.Empty)
            {
                sb.Append("Type like '%" + _typeSelectedItem.Trim() + "%'");
            }

            if (_make != null && _make != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Make like '%" + _make.Trim() + "%'");
            }

            if (_model != null && _model != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Model like '%" + _model.Trim() + "%'");
            }

            try
            {
                if (_chassisno != null && _chassisno != string.Empty)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }

                    sb.Append("Chassis_No like '%" + _chassisno.Trim() + "%' ");
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

            if (_plateno != null && _plateno != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Plate_No like '%" + _plateno.Trim() + "%'");
            }
            return sb.ToString();
        }

        public void refreshButton()
        {
            _vehicleGridSource = connection.dbTable("SELECT Vehicle_ID, Type, Plate_No, Chassis_No, Make, Model, Color, Date_Stolen, Location_Stolen, Suspect, Owner FROM `ps4`.`stolenvehicles`;");
            _baseVehicleGridItemSource = _vehicleGridSource;
            NotifyOfPropertyChange(() => vehicleGridSource);
        }

        public void resetButton()
        {
            _typeSelectedItem = string.Empty;
            _make = string.Empty;
            _chassisno = string.Empty;
            _model = string.Empty;
            _plateno = string.Empty;
            _vehicleGridSource = connection.dbTable("SELECT Vehicle_ID, Type, Plate_No, Chassis_No, Make, Model, Color, Date_Stolen, Location_Stolen, Suspect, Owner FROM `ps4`.`stolenvehicles`;");
            _baseVehicleGridItemSource = _vehicleGridSource;
            NotifyOfPropertyChange(() => typeSelectedItem);
            NotifyOfPropertyChange(() => make);
            NotifyOfPropertyChange(() => chassisno);
            NotifyOfPropertyChange(() => model);
            NotifyOfPropertyChange(() => plateno);
            NotifyOfPropertyChange(() => vehicleGridSource);
        }

        public void showStolenVehicle()
        {

                DataRowView dataRowView = (DataRowView)_vehicleGridSelectedItem;
                _selectedVehicleID = dataRowView.Row[0].ToString();
                windowManager.ShowWindow(new EditVehicleViewModel(_selectedVehicleID), null, null);

        }

        protected override void OnActivate()
        {
            _vehicleGridSource = connection.dbTable("SELECT Vehicle_ID, Type, Plate_No, Chassis_No, Make, Model, Color, Date_Stolen, Location_Stolen, Suspect, Owner FROM `ps4`.`stolenvehicles`;");
            _baseVehicleGridItemSource = _vehicleGridSource;
            NotifyOfPropertyChange(() => vehicleGridSource);
            base.OnActivate();
        }
    }
}