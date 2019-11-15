using Caliburn.Micro;
using Microsoft.Win32;
using PS4_MIS_v2._0.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PS4_MIS_v2._0.ViewModels.StolenVehicles
{
    internal class EditVehicleViewModel : Screen
    {
        private static string _savedVehiclePictureFilePath;
        private static string _vehiclePictureFilePath;
        private string _chassisno;
        private string _color;
        private DateTime _datestolen;
        private DateTime _datestolenSelectedDate;
        private bool _hasPicture = false;
        private string _locationstolen;
        private string _make;
        private string _model;
        private string _owner;
        private string _plateno;
        private string _remarks;
        private string _selectedVehicleID;
        private string _suspect;
        private List<string> _type;
        private string _typeSelectedItem;
        private string _vehicleid;
        private string _vehiclepictureImage = null;
        private ImageSource _vehiclePictureSource;
        private IWindowManager windowManager = new WindowManager();

        public EditVehicleViewModel(string selectedVehicleID)
        {
            _selectedVehicleID = selectedVehicleID;
        }

        public string chassisno
        {
            get { return _chassisno; }
            set
            {
                _chassisno = value;
                NotifyOfPropertyChange(() => chassisno);
            }
        }

        public string color
        {
            get { return _color; }
            set { _color = value; }
        }

        public DateTime datestolen
        {
            get { return _datestolen; }
            set
            {
                _datestolen = value;
                NotifyOfPropertyChange(() => chassisno);
            }
        }

        public DateTime datestolenSelectedDate
        {
            get { return _datestolenSelectedDate; }
            set { _datestolenSelectedDate = value; }
        }

        public string locationstolen
        {
            get { return _locationstolen; }
            set { _locationstolen = value; }
        }

        public string make
        {
            get { return _make; }
            set { _make = value; }
        }

        public string model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        public string plateno
        {
            get { return _plateno; }
            set { _plateno = value; }
        }

        public string remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public string suspect
        {
            get { return _suspect; }
            set { _suspect = value; }
        }

        public List<string> type
        {
            get { return new List<string> { "Car", "Motorcycle", "Bicycle", "Truck", "Other" }; }
            set { _type = value; }
        }

        public string typeSelectedItem
        {
            get { return this._typeSelectedItem; }

            set
            {
                this._typeSelectedItem = value;
                this.NotifyOfPropertyChange(() => this.typeSelectedItem);
            }
        }

        public string vehicleid
        {
            get { return _vehicleid; }
            set { _vehicleid = value; }
        }

        public string vehiclePicture
        {
            get { return _vehiclepictureImage; }
            set { _vehiclepictureImage = value; }
        }

        public ImageSource vehiclePictureSource
        {
            get { return this._vehiclePictureSource; }
            set { this._vehiclePictureSource = value; }
        }

        public void cancelButton()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }

        public void changePictureButton()
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Multiselect = false;
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                _vehiclePictureFilePath = op.FileName;
                ImageSource imgsource = new BitmapImage(new Uri(_vehiclePictureFilePath));
                _vehiclePictureSource = imgsource;
                this.NotifyOfPropertyChange(() => this.vehiclePictureSource);
                _hasPicture = true;
            }
        }

        public void initializeValues()
        {
            DataTable dt = connection.dbTable("select * from stolenvehicles where Vehicle_ID = " + _selectedVehicleID + ";");
            _vehicleid = dt.Rows[0][0].ToString();
            NotifyOfPropertyChange(() => vehicleid);
            _typeSelectedItem = dt.Rows[0][1].ToString();
            NotifyOfPropertyChange(() => typeSelectedItem);
            _plateno = dt.Rows[0][2].ToString();
            NotifyOfPropertyChange(() => plateno);
            _chassisno = dt.Rows[0][3].ToString();
            NotifyOfPropertyChange(() => chassisno);
            _make = dt.Rows[0][4].ToString();
            NotifyOfPropertyChange(() => make);
            _model = dt.Rows[0][5].ToString();
            NotifyOfPropertyChange(() => model);
            _color = dt.Rows[0][6].ToString();
            NotifyOfPropertyChange(() => color);
            _owner = dt.Rows[0][7].ToString();
            NotifyOfPropertyChange(() => owner);
            _suspect = dt.Rows[0][8].ToString();
            NotifyOfPropertyChange(() => suspect);
            _datestolenSelectedDate = Convert.ToDateTime(dt.Rows[0][9].ToString());
            NotifyOfPropertyChange(() => datestolenSelectedDate);
            _locationstolen = dt.Rows[0][10].ToString();
            NotifyOfPropertyChange(() => locationstolen);
            _remarks = dt.Rows[0][11].ToString();
            NotifyOfPropertyChange(() => remarks);
            if (dt.Rows[0][12].ToString() != string.Empty)
            {
                ImageSource imgsource = new BitmapImage(new Uri(dt.Rows[0][12].ToString()));
                _vehiclePictureSource = imgsource;
                NotifyOfPropertyChange(() => vehiclePictureSource);
            }
        }

        public void saveButton()
        {
            if (areRequiredFieldsComplete() && _hasPicture)
            {
                savePicture();
                connection.dbCommand("UPDATE `ps4`.`stolenvehicles` SET `Type` = '" + _typeSelectedItem + "', `Plate_No` = '" + _plateno + "', `Chassis_No` = '" + _chassisno + "', `Make` = '" + _make + "', `Model` = '" + _model + "', `Color` = '" + _color + "', `Owner` = '" + _owner + "', `Suspect` = '" + _suspect + "', `Date_Stolen` = '" + _datestolenSelectedDate + "', `Location_Stolen` = '" + _locationstolen + "', `Remarks` = '" + _remarks + "', `Picture` = '" + _savedVehiclePictureFilePath + "' WHERE (`Vehicle_ID` = '" + _selectedVehicleID + "');");
                connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Vehicle','" + _vehicleid + "', '" + currentUser.EmployeeID + "', 'Edited Stolen Vehicle Record " + _vehicleid + "')");
                TryClose();
            }
            else if (areRequiredFieldsComplete())
            {
                connection.dbCommand("UPDATE `ps4`.`stolenvehicles` SET `Type` = '" + _typeSelectedItem + "', `Plate_No` = '" + _plateno + "', `Chassis_No` = '" + _chassisno + "', `Make` = '" + _make + "', `Model` = '" + _model + "', `Color` = '" + _color + "', `Owner` = '" + _owner + "', `Suspect` = '" + _suspect + "', `Date_Stolen` = '" + _datestolenSelectedDate + "', `Location_Stolen` = '" + _locationstolen + "', `Remarks` = '" + _remarks + "' WHERE (`Vehicle_ID` = '" + _selectedVehicleID + "');");
                connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Vehicle','" + _vehicleid + "', '" + currentUser.EmployeeID + "', 'Edited Stolen Vehicle Record " + _vehicleid + "')");
                TryClose();
            }
            else
            {
                MessageBox.Show("Please fill out all required fields");
            }
        }

        protected override void OnActivate()
        {
            initializeValues();
            base.OnActivate();
        }

        private static String getAppStartPath(string filename, string foldername)
        {
            String appStartPath = System.AppDomain.CurrentDomain.BaseDirectory;
            appStartPath = String.Format(appStartPath + @"\{0}\" + filename, foldername);
            return appStartPath;
        }

        private static void savePicture()
        {
            string name = System.IO.Path.GetFileName(_vehiclePictureFilePath);
            string destinationPath = getAppStartPath(name, "vehiclePictures");
            destinationPath = destinationPath.Replace(@"\", @"\\");
            destinationPath = destinationPath.Replace(@"\\\\", @"\\");
            _savedVehiclePictureFilePath = destinationPath;
            File.Copy(_vehiclePictureFilePath, destinationPath, true);
        }

        private bool areRequiredFieldsComplete()
        {
            if (
                _owner == string.Empty ||
                _typeSelectedItem == string.Empty ||
                _color == string.Empty ||
                _make == string.Empty
                )
                return false;
            else
                return true;
        }
    }
}