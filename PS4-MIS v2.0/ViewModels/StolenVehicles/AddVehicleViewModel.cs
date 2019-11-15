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
    internal class AddVehicleViewModel : Screen
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
        private string _suspect;
        private List<string> _type;
        private string _typeSelectedItem;
        private string _vehiclepictureImage = null;
        private ImageSource _vehiclePictureSource;
        private IWindowManager windowManager = new WindowManager();

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

        public void saveButton()
        {
            if (areRequiredFieldsComplete() && _hasPicture)
            {
                savePicture();
                connection.dbCommand("INSERT INTO `ps4`.`stolenvehicles` (`Type`, `Plate_No`, `Chassis_No`, `Make`, `Model`, `Color`, `Date_Stolen`, `Location_Stolen`, `Suspect`, `Owner`, `Remarks`, `Picture`) VALUES ('" + _typeSelectedItem + "', '" + _plateno + "', '" + _chassisno + "', '" + _make + "', '" + _model + "', '" + _color + "', '" + _datestolenSelectedDate + "', '" + _locationstolen + "', '" + _suspect + "', '" + _owner + "', '" + _remarks + "', '" + _savedVehiclePictureFilePath + "');");
                DataTable dt = connection.dbTable("select MAX(Vehicle_ID) from stolenvehicles");
                connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Vehicle','" + dt.Rows[0][0].ToString() + "', '" + currentUser.EmployeeID + "', 'Created Stolen Vehicle Record " + dt.Rows[0][0].ToString() + "')");
                TryClose();
            }
            else if (areRequiredFieldsComplete())
            {
                connection.dbCommand("INSERT INTO `ps4`.`stolenvehicles` (`Type`, `Plate_No`, `Chassis_No`, `Make`, `Model`, `Color`, `Date_Stolen`, `Location_Stolen`, `Suspect`, `Owner`, `Remarks`, `Picture`) VALUES ('" + _typeSelectedItem + "', '" + _plateno + "', '" + _chassisno + "', '" + _make + "', '" + _model + "', '" + _color + "', '" + _datestolenSelectedDate + "', '" + _locationstolen + "', '" + _suspect + "', '" + _owner + "', '" + _remarks + "', null);");
                DataTable dt = connection.dbTable("select MAX(Vehicle_ID) from stolenvehicles");
                connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Vehicle','" + dt.Rows[0][0].ToString() + "', '" + currentUser.EmployeeID + "', 'Created Stolen Vehicle Record " + dt.Rows[0][0].ToString() + "')");
                TryClose();
            }
            else
            {
                MessageBox.Show("Please fill out all required fields");
            }
        }

        protected override void OnActivate()
        {
            _datestolenSelectedDate = DateTime.Now.Date;
            NotifyOfPropertyChange(() => datestolenSelectedDate);
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