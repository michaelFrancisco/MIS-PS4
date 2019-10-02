using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PS4_MIS_v2._0.ViewModels.Inventory
{
    class ShowItemViewModel : Screen
    {
        private bool _hasPicture = false;
        private bool _quantityEnabled;
        private DateTime _acquired;
        private DateTime _acquiredSelectedDate;
        private ImageSource _itemPictureSource;
        private int _quantity;
        private List<string> _category;
        private string _categorySelectedItem;
        private string _inventoryid;
        private string _itemPictureFilePath;
        private string _make;
        private string _model;
        private string _name;
        private string _remarks;
        private string _savedItemPictureFilePath;
        private string _serial;
        private string _selectedInventoryID;

        public ShowItemViewModel(string selectedInventoryID)
        {
            _selectedInventoryID = selectedInventoryID;
        }
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
                connection.dbCommand("UPDATE `ps4`.`inventory` SET `Category` = '"+_categorySelectedItem+"', `Name` = '"+_name+"', `Make` = '"+_make+"', `Model` = '"+_model+"', `Serial` = '"+_serial+"', `Quantity` = "+_quantity+", `Acquired` = '"+_acquiredSelectedDate.ToString("yyyy-MM-dd")+"', `Remarks` = '"+_remarks+"', `Picture` = '"+_savedItemPictureFilePath+"' WHERE (`Inventory_ID` = "+_selectedInventoryID+");");
                TryClose();
            }
            else if (areRequiredFieldsComplete())
            {
                connection.dbCommand("UPDATE `ps4`.`inventory` SET `Category` = '" + _categorySelectedItem + "', `Name` = '" + _name + "', `Make` = '" + _make + "', `Model` = '" + _model + "', `Serial` = '" + _serial + "', `Quantity` = " + _quantity + ", `Acquired` = '" + _acquiredSelectedDate.ToString("yyyy-MM-dd") + "', `Remarks` = '" + _remarks + "' WHERE (`Inventory_ID` = " + _selectedInventoryID + ");");
                TryClose();
            }
        }

        protected override void OnActivate()
        {
            initializeValues();
            base.OnActivate();
        }

        public void initializeValues()
        {
            DataTable dt = connection.dbTable("select * from inventory where Inventory_ID =" + _selectedInventoryID + ";");
            _inventoryid = dt.Rows[0][0].ToString();
            NotifyOfPropertyChange(() => inventoryid);
            _categorySelectedItem = dt.Rows[0][1].ToString();
            NotifyOfPropertyChange(() => categorySelectedItem);
            _name = dt.Rows[0][2].ToString();
            NotifyOfPropertyChange(() => name);
            _make = dt.Rows[0][3].ToString();
            NotifyOfPropertyChange(() => make);
            _model = dt.Rows[0][4].ToString();
            NotifyOfPropertyChange(() => model);
            _serial = dt.Rows[0][5].ToString();
            NotifyOfPropertyChange(() => serial);
            _quantity = Convert.ToInt32(dt.Rows[0][6]);
            NotifyOfPropertyChange(() => quantity);
            _acquiredSelectedDate = (DateTime)dt.Rows[0][7];
            NotifyOfPropertyChange(() => acquired);
            _remarks = dt.Rows[0][8].ToString();
            NotifyOfPropertyChange(() => remarks);
            if (dt.Rows[0][9].ToString() != string.Empty)
            {
                ImageSource imgsource = new BitmapImage(new Uri(dt.Rows[0][9].ToString()));
                _itemPictureSource = imgsource;
                NotifyOfPropertyChange(() => itemPictureSource);
            }
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
