using Caliburn.Micro;
using PS4_MIS_v2._0.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;

namespace PS4_MIS_v2._0.ViewModels.Inventory
{
    internal class DispatchItemsViewModel : Screen
    {
        private DataTable _baseInventoryGridSource;
        private List<string> _category;
        private string _categorySelectedItem;
        private string _chosenEmployee;
        private object _dispatchGridSelectedItem;
        private DataTable _dispatchGridSource;
        private DateTime _duebackSelectedDate;
        private object _inventoryGridSelectedItem;
        private DataTable _inventoryGridSource;
        private string _inventoryid;
        private string _make;
        private string _model;
        private string _name;
        private string _selectedEmployeeID;
        private string _selectedInventoryID;
        private string _serial;
        private IWindowManager windowManager = new WindowManager();

        public DispatchItemsViewModel(string selectedEmployeeID)
        {
            _selectedEmployeeID = selectedEmployeeID;
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
                DataView dv = new DataView(_baseInventoryGridSource);
                dv.RowFilter = query();
                _inventoryGridSource = dv.ToTable();
                NotifyOfPropertyChange(() => inventoryGridSource);
            }
        }

        public string chosenEmployee
        {
            get { return _chosenEmployee; }
            set { _chosenEmployee = value; }
        }

        public object dispatchGridSelectedItem
        {
            get { return _dispatchGridSelectedItem; }
            set { _dispatchGridSelectedItem = value; }
        }

        public DataTable dispatchGridSource
        {
            get { return _dispatchGridSource; }
            set { _dispatchGridSource = value; }
        }

        public DateTime duebackSelectedDate
        {
            get { return _duebackSelectedDate; }
            set { _duebackSelectedDate = value; }
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

        public void cancelButton()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }

        public void giveButton()
        {
            try
            {
                DataRowView dataRowView = (DataRowView)_inventoryGridSelectedItem;
                _dispatchGridSource.Rows.Add(dataRowView.Row[0], dataRowView.Row[1], dataRowView.Row[2], dataRowView.Row[3], dataRowView.Row[4], dataRowView.Row[5], dataRowView.Row[6]);
                _inventoryGridSource.Rows.Remove(dataRowView.Row);
                NotifyOfPropertyChange(() => dispatchGridSource);
                NotifyOfPropertyChange(() => inventoryGridSource);
            }
            catch { }
        }

        public void initializeDataTables()
        {
            _inventoryGridSource = connection.dbTable("SELECT Inventory_ID, Category,Name, Make, Model, Serial, Quantity, Acquired FROM `ps4`.`inventory` WHERE inUse = 0;");
            _baseInventoryGridSource = _inventoryGridSource;
            _dispatchGridSource = connection.dbTable("SELECT Inventory_ID, Category,Name, Make, Model, Serial, Quantity, Acquired FROM `ps4`.`inventory` WHERE Employee_ID = " + _selectedEmployeeID + ";");
            NotifyOfPropertyChange(() => dispatchGridSource);
            NotifyOfPropertyChange(() => inventoryGridSource);
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

                sb.Append("Serial like '%" + _serial.Trim() + "%'");
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

        public void resetButton()
        {
            _categorySelectedItem = string.Empty;
            _inventoryid = string.Empty;
            _make = string.Empty;
            _model = string.Empty;
            _serial = string.Empty;
            _name = string.Empty;
            _inventoryGridSource = _baseInventoryGridSource;
            NotifyOfPropertyChange(() => categorySelectedItem);
            NotifyOfPropertyChange(() => inventoryid);
            NotifyOfPropertyChange(() => make);
            NotifyOfPropertyChange(() => model);
            NotifyOfPropertyChange(() => serial);
            NotifyOfPropertyChange(() => name);
            NotifyOfPropertyChange(() => inventoryGridSource);
        }

        public void saveButton()
        {
            int j = _dispatchGridSource.Rows.Count;
            for (int i = 0; i < j; i++)
            {
                connection.dbCommand("UPDATE `ps4`.`inventory` SET `inUse` = '1', `Date_Out` = '" + DateTime.Now.ToString("yyyy-MM-dd") + "', `Due_Back` = '" + _duebackSelectedDate.ToString("yyyy-MM-dd") + "', `Employee_ID` = '" + _selectedEmployeeID + "' WHERE(`Inventory_ID` = " + _dispatchGridSource.Rows[i][0].ToString() + ")");
                connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Inventory','" + _dispatchGridSource.Rows[i][0].ToString() + "', '" + currentUser.EmployeeID + "', 'Item " + _dispatchGridSource.Rows[i][0].ToString() + " was dispatched')");
            }
            TryClose();
        }

        public void setEmployeeName()
        {
            DataTable dt = connection.dbTable("SELECT Rank, First_Name, Last_Name FROM ps4.employeerecords where Employee_ID = " + _selectedEmployeeID + ";");
            _chosenEmployee = dt.Rows[0][0].ToString() + " " + dt.Rows[0][1].ToString() + " " + dt.Rows[0][2].ToString();
            NotifyOfPropertyChange(() => chosenEmployee);
        }

        public void takeButton()
        {
            DataRowView dataRowView = (DataRowView)_dispatchGridSelectedItem;
            _inventoryGridSource.Rows.Add(dataRowView.Row[0], dataRowView.Row[1], dataRowView.Row[2], dataRowView.Row[3], dataRowView.Row[4], dataRowView.Row[5], dataRowView.Row[6]);
            _dispatchGridSource.Rows.Remove(dataRowView.Row);
            NotifyOfPropertyChange(() => dispatchGridSource);
            NotifyOfPropertyChange(() => inventoryGridSource);
        }

        protected override void OnActivate()
        {
            _duebackSelectedDate = DateTime.Now;
            NotifyOfPropertyChange(() => duebackSelectedDate);
            setEmployeeName();
            initializeDataTables();
            base.OnActivate();
        }
    }
}