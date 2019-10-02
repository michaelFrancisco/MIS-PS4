using Caliburn.Micro;
using PS4_MIS_v2._0.ViewModels.Inventory;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PS4_MIS_v2._0.ViewModels
{
    class InventoryViewModel : Screen
    {
        private DataTable _baseInuseGridSource;
        private DataTable _baseInventoryGridSource;
        private List<string> _category;
        private string _categorySelectedItem;
        private object _inuseGridSelectedItem;
        private DataTable _inuseGridSource;
        private object _inventoryGridSelectedItem;
        private DataTable _inventoryGridSource;
        private string _inventoryid;
        private string _make;
        private string _model;
        private string _selectedInventoryID;
        private string _serial;
        IWindowManager windowManager = new WindowManager();
        public List<string> category
        {
            get { return new List<string> { "Lethal Weapon", "Ammunition", "Protective Gear", "Radio", "Non-Lethal Weapon", "Office Supplies", "IT Hardware", "Apparel", "Misc" }; }
            set { _category = value; }
        }

        private string _name;

        public string name
        {
            get { return _name; }
            set
            {
                _name = value;
                DataView dv = new DataView(_baseInventoryGridSource);
                dv.RowFilter = query();
                _inventoryGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => inventoryGridSource);
                dv = new DataView(_baseInuseGridSource);
                dv.RowFilter = query();
                _inuseGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => inuseGridSource);
            }
        }



        public string categorySelectedItem
        {
            get { return _categorySelectedItem; }
            set
            {
                _categorySelectedItem = value;
                DataView dv = new DataView(_baseInventoryGridSource);
                dv.RowFilter = query();
                _inventoryGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => inventoryGridSource);
            }
        }

        public object inuseGridSelectedItem
        {
            get { return _inuseGridSelectedItem; }
            set { _inuseGridSelectedItem = value; }
        }

        public DataTable inuseGridSource
        {
            get { return _inuseGridSource; }
            set { _inuseGridSource = value; }
        }

        public object inventoryGridSelectedItem
        {
            get { return _inventoryGridSelectedItem; }
            set { _inventoryGridSelectedItem = value; }
        }

        public DataTable inventoryGridSource
        {
            get { return _inventoryGridSource; }
            set { _inventoryGridSource = value; }
        }

        public string inventoryid
        {
            get { return _inventoryid; }
            set
            {
                _inventoryid = value;
                DataView dv = new DataView(_baseInventoryGridSource);
                dv.RowFilter = query();
                _inventoryGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => inventoryGridSource);
                dv = new DataView(_baseInuseGridSource);
                dv.RowFilter = query();
                _inuseGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => inuseGridSource);
            }
        }

        public string make
        {
            get { return _make; }
            set
            {
                _make = value;
                DataView dv = new DataView(_baseInventoryGridSource);
                dv.RowFilter = query();
                _inventoryGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => inventoryGridSource);
            }
        }

        public string model
        {
            get { return _model; }
            set
            {
                _model = value;
                DataView dv = new DataView(_baseInventoryGridSource);
                dv.RowFilter = query();
                _inventoryGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => inventoryGridSource);
            }
        }

        public string serial
        {
            get { return _serial; }
            set
            {
                _serial = value;
                DataView dv = new DataView(_baseInventoryGridSource);
                dv.RowFilter = query();
                _inventoryGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => inventoryGridSource);
            }
        }

        public void addItemButton()
        {
            windowManager.ShowWindow(new AddItemViewModel(), null, null);

        }

        public void dispatchItem()
        {

        }

        public string query()
        {
            StringBuilder sb = new StringBuilder();
            if (_categorySelectedItem != null && _categorySelectedItem != string.Empty)
            {
                sb.Append("Category like '%" + _categorySelectedItem.Trim() + "%'");
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
                if (_inventoryid != null && _inventoryid != string.Empty)
                {
                    if (sb.Length > 0)
                    {
                        sb.Append(" and ");
                    }

                    sb.Append("Inventory_ID = " + Int32.Parse(_inventoryid) + "");
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

            if (_serial != null && _serial != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Department like '%" + _serial.Trim() + "%'");
            }

            if (_name != null && _name != string.Empty)
            {
                if (sb.Length > 0)
                {
                    sb.Append(" and ");
                }

                sb.Append("Name like '%" + _name.Trim() + "%'");
            }
            return sb.ToString();
        }
        public void receiveItem()
        {

        }

        public void refreshButton()
        {
            _inventoryGridSource = connection.dbTable("SELECT Inventory_ID, Category,Name, Make, Model, Serial, Quantity, Acquired FROM `ps4`.`inventory` WHERE inUse = 0;");
            _baseInventoryGridSource = _inventoryGridSource;
            NotifyOfPropertyChange(() => inventoryGridSource);
            _inuseGridSource = connection.dbTable("SELECT inventory.Inventory_ID, inventory.Name, employeerecords.Rank, employeerecords.First_Name, employeerecords.Last_Name, inventory.Date_Out, inventory.Due_back FROM inventory JOIN employeerecords ON inventory.Employee_ID = employeerecords.Employee_ID WHERE inventory.inUse = 1;");
            _baseInuseGridSource = _inuseGridSource;
            NotifyOfPropertyChange(() => inuseGridSource);
        }

        public void resetButton()
        {
            _categorySelectedItem = string.Empty;
            _inventoryid = string.Empty;
            _make = string.Empty;
            _model = string.Empty;
            _serial = string.Empty;
            _inventoryGridSource = connection.dbTable("SELECT Inventory_ID, Category,Name, Make, Model, Serial, Quantity, Acquired FROM `ps4`.`inventory` WHERE inUse = 0;");
            _baseInventoryGridSource = _inventoryGridSource;
            _inuseGridSource = connection.dbTable("SELECT inventory.Inventory_ID, inventory.Name, employeerecords.Rank, employeerecords.First_Name, employeerecords.Last_Name, inventory.Date_Out, inventory.Due_back FROM inventory JOIN employeerecords ON inventory.Employee_ID = employeerecords.Employee_ID WHERE inventory.inUse = 1;");
            _baseInuseGridSource = _inuseGridSource;
            NotifyOfPropertyChange(() => inuseGridSource);
            NotifyOfPropertyChange(() => categorySelectedItem);
            NotifyOfPropertyChange(() => inventoryid);
            NotifyOfPropertyChange(() => make);
            NotifyOfPropertyChange(() => model);
            NotifyOfPropertyChange(() => serial);
            NotifyOfPropertyChange(() => inventoryGridSource);
        }
        public void showItem()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_inventoryGridSelectedItem;
                _selectedInventoryID = dataRowView.Row[0].ToString();
                windowManager.ShowWindow(new ShowItemViewModel(_selectedInventoryID), null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected override void OnActivate()
        {
            _inventoryGridSource = connection.dbTable("SELECT Inventory_ID, Category,Name, Make, Model, Serial, Quantity, Acquired FROM `ps4`.`inventory` WHERE inUse = 0;");
            _baseInventoryGridSource = _inventoryGridSource;
            NotifyOfPropertyChange(() => inventoryGridSource);
            _inuseGridSource = connection.dbTable("SELECT inventory.Inventory_ID, inventory.Name, employeerecords.Rank, employeerecords.First_Name, employeerecords.Last_Name, inventory.Date_Out, inventory.Due_back FROM inventory JOIN employeerecords ON inventory.Employee_ID = employeerecords.Employee_ID WHERE inventory.inUse = 1;");
            _baseInuseGridSource = _inuseGridSource;
            NotifyOfPropertyChange(() => inuseGridSource);
            base.OnActivate();
        }
    }
}
