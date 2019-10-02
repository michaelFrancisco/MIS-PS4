using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PS4_MIS_v2._0.ViewModels.Inventory
{
    internal class AddItemViewModel : Screen
    {
        private DateTime _acquired;
        private DateTime _acquiredSelectedDate;
        private List<string> _category;
        private string _categorySelectedItem;
        private bool _hasPicture = false;
        private string _inventoryid;
        private string _itemPictureFilePath;
        private ImageSource _itemPictureSource;
        private string _make;
        private string _model;
        private string _name;
        private int _quantity;
        private bool _quantityEnabled;
        private string _remarks;
        private string _savedItemPictureFilePath;
        private string _serial;

        public DateTime acquired
        {
            get { return _acquired; }
            set { _acquired = value; }
        }

        public DateTime acquiredSelectedDate
        {
            get { return _acquiredSelectedDate; }
            set { _acquiredSelectedDate = value; }
        }

        public List<string> category
        {
            get { return new List<string> { "Lethal Weapon", "Ammunition", "Protective Gear", "Radio", "Non-Lethal Weapon", "Office Supplies", "IT Hardware", "Apparel", "Misc" }; }
            set { _category = value; }
        }

        public string categorySelectedItem
        {
            get { return _categorySelectedItem; }
            set
            {
                _categorySelectedItem = value;
                if (_categorySelectedItem == "Ammunition")
                {
                    _quantityEnabled = true;
                    NotifyOfPropertyChange(() => quantityEnabled);
                }
                else
                {
                    _quantityEnabled = false;
                    NotifyOfPropertyChange(() => quantityEnabled);
                    _quantity = 1;
                    NotifyOfPropertyChange(() => quantity);
                }
            }
        }

        public string inventoryid
        {
            get { return _inventoryid; }
            set { _inventoryid = value; }
        }

        public ImageSource itemPictureSource
        {
            get { return _itemPictureSource; }
            set { _itemPictureSource = value; }
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

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        public bool quantityEnabled
        {
            get { return _quantityEnabled; }
            set { _quantityEnabled = value; }
        }

        public string remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public string serial
        {
            get { return _serial; }
            set { _serial = value; }
        }

        public void cancelButton()
        {
            TryClose();
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
                _itemPictureFilePath = op.FileName;
                ImageSource imgsource = new BitmapImage(new Uri(_itemPictureFilePath));
                _itemPictureSource = imgsource;
                this.NotifyOfPropertyChange(() => this.itemPictureSource);
                _hasPicture = true;
            }
        }

        public void saveButton()
        {
            if (areRequiredFieldsComplete() && _hasPicture)
            {
                savePicture();
                connection.dbCommand("INSERT INTO `ps4`.`inventory` (`Category`,`Name`, `Make`, `Model`, `Serial`, `Quantity`, `Acquired`, `Remarks`, `Picture`) VALUES ('" + _categorySelectedItem + "'," + _name + ", '" + _make + "', '" + _model + "', '" + _serial + "', " + _quantity + ", '" + _acquiredSelectedDate.ToString("yyyy-MM-dd") + "', '" + _remarks + "', '" + _savedItemPictureFilePath + "');");
                TryClose();
            }
            else if (areRequiredFieldsComplete())
            {
                connection.dbCommand("INSERT INTO `ps4`.`inventory` (`Category`,`Name`, `Make`, `Model`, `Serial`, `Quantity`, `Acquired`, `Remarks`, `Picture`) VALUES ('" + _categorySelectedItem + "'," + _name + ", '" + _make + "', '" + _model + "', '" + _serial + "', " + _quantity + ", '" + _acquiredSelectedDate.ToString("yyyy-MM-dd") + "', '" + _remarks + "', null);");
                TryClose();
            }
        }

        protected override void OnActivate()
        {
            _quantity = 1;
            NotifyOfPropertyChange(() => quantity);
            _acquiredSelectedDate = DateTime.Now;
            NotifyOfPropertyChange(() => acquiredSelectedDate);
            base.OnActivate();
        }

        private bool areRequiredFieldsComplete()
        {
            if (
                _categorySelectedItem == string.Empty ||
                _name == string.Empty ||
                _make == string.Empty ||
                _model == string.Empty
                )
                return false;
            else
                return true;
        }

        private String getAppStartPath(string filename, string foldername)
        {
            String appStartPath = System.AppDomain.CurrentDomain.BaseDirectory;
            appStartPath = String.Format(appStartPath + @"\{0}\" + filename, foldername);
            return appStartPath;
        }

        private void savePicture()
        {
            string name = System.IO.Path.GetFileName(_itemPictureFilePath);
            string destinationPath = getAppStartPath(name, "itemPictures");
            destinationPath = destinationPath.Replace(@"\", @"\\");
            destinationPath = destinationPath.Replace(@"\\\\", @"\\");
            _savedItemPictureFilePath = destinationPath;
            File.Copy(_itemPictureFilePath, destinationPath, true);
        }
    }
}