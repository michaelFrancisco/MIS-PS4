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

namespace PS4_MIS_v2._0.ViewModels.EmployeeRecords
{
    internal class EditEmployeeRecordViewModel : Screen
    {
        private string _address;
        private string _age;
        private DateTime _birthdate;
        private DateTime _birthdateSelectedDate;
        private string _birthplace;
        private bool _canCreateAccount = false;
        private List<string> _civilstatus;
        private string _civilstatusSelectedItem;
        private string _department;
        private string _employeeID;
        private string _employeePictureFilePath;
        private string _firstname;
        private bool _hasAccount = false;
        private bool _hasPicture = false;
        private bool _isPasswodEnabled;
        private bool _isUsernameEnabled;
        private string _lastname;
        private string _middlename;
        private string _password;
        private string _position;
        private ImageSource _profilePictureSource;
        private List<string> _rank;
        private string _rankSelectedItem;
        private string _remarks;
        private string _savedEmployeePictureFilePath;
        private string _selectedEmployeeID;
        private List<string> _sex;
        private string _sexSelectedItem;
        private List<string> _userlevel;
        private string _userlevelSelectedItem;
        private string _username;
        private IWindowManager windowManager = new WindowManager();

        public EditEmployeeRecordViewModel(string selectedEmployeeID)
        {
            _selectedEmployeeID = selectedEmployeeID;
        }

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string age
        {
            get { return _age; }
            set { _age = value; }
        }

        public DateTime birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public DateTime birthdateSelectedDate
        {
            get { return _birthdateSelectedDate; }
            set
            {
                _birthdateSelectedDate = value;
                _age = (DateTime.Now.Year - _birthdateSelectedDate.Year).ToString();
                NotifyOfPropertyChange(() => age);
            }
        }

        public string birthplace
        {
            get { return _birthplace; }
            set { _birthplace = value; }
        }

        public bool canCreateAccount
        {
            get { return _canCreateAccount; }
            set { _canCreateAccount = value; }
        }

        public List<string> civilstatus
        {
            get { return new List<string> { "Single", "Married", "Widowed" }; }
            set { _civilstatus = value; }
        }

        public string civilstatusSelectedItem
        {
            get { return _civilstatusSelectedItem; }
            set { _civilstatusSelectedItem = value; }
        }

        public string department
        {
            get { return _department; }
            set { _department = value; }
        }

        public string employeeID
        {
            get { return _employeeID; }
            set { _employeeID = value; }
        }

        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public bool isPasswordEnabled
        {
            get { return _isPasswodEnabled; }
            set { _isPasswodEnabled = value; }
        }

        public bool isUsernameEnabled
        {
            get { return _isUsernameEnabled; }
            set { _isUsernameEnabled = value; }
        }

        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }

        public string middlename
        {
            get { return _middlename; }
            set { _middlename = value; }
        }

        public string password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string position
        {
            get { return _position; }
            set { _position = value; }
        }

        public ImageSource profilePictureSource
        {
            get { return _profilePictureSource; }
            set { _profilePictureSource = value; }
        }

        public List<string> rank
        {
            get { return new List<string> { "Patrolman/Patrolwoman", "Police Corporal", "Police Staff Sergeant", "Police Master Sergeant", "Police Senior Master Sergeant", "Police Chief Master Sergeant", "Police Executive Master Sergeant", "Police Lieutenant", "Police Captain", "Police Major", "Police Lieutenant Colonel", "Police Colonel", "Police Brigadier General", "Police Major General", "Police Lieutenant General", "Police General" }; }
            set { _rank = value; }
        }

        public string rankSelectedItem
        {
            get { return _rankSelectedItem; }
            set { _rankSelectedItem = value; }
        }

        public string remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public List<string> sex
        {
            get { return new List<string> { "Male", "Female" }; }
            set { _sex = value; }
        }

        public string sexSelectedItem
        {
            get { return _sexSelectedItem; }
            set { _sexSelectedItem = value; }
        }

        public List<string> userlevel
        {
            get { return new List<string> { "Administrator", "Desk Officer", "Inventory", "Jailer" }; }
            set { _userlevel = value; }
        }

        public string userlevelSelectedItem
        {
            get { return _userlevelSelectedItem; }
            set { _userlevelSelectedItem = value; }
        }

        public string username
        {
            get { return _username; }
            set { _username = value; }
        }

        public void cancelButton()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }

        public void canCreateNo()
        {
            _canCreateAccount = false;
            _isPasswodEnabled = false;
            _isUsernameEnabled = false;
            NotifyOfPropertyChange(() => canCreateAccount);
            NotifyOfPropertyChange(() => isUsernameEnabled);
            NotifyOfPropertyChange(() => isPasswordEnabled);
        }

        public void canCreateYes()
        {
            _canCreateAccount = true;
            _isPasswodEnabled = true;
            _isUsernameEnabled = true;
            NotifyOfPropertyChange(() => canCreateAccount);
            NotifyOfPropertyChange(() => isUsernameEnabled);
            NotifyOfPropertyChange(() => isPasswordEnabled);
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
                _employeePictureFilePath = op.FileName;
                ImageSource imgsource = new BitmapImage(new Uri(_employeePictureFilePath));
                _profilePictureSource = imgsource;
                this.NotifyOfPropertyChange(() => this.profilePictureSource);
                _hasPicture = true;
            }
        }

        public void initializeValues()
        {
            DataTable dt = connection.dbTable("select * from employeerecords where Employee_ID =" + _selectedEmployeeID + ";");
            _employeeID = dt.Rows[0][0].ToString();
            NotifyOfPropertyChange(() => employeeID);
            _firstname = dt.Rows[0][1].ToString();
            NotifyOfPropertyChange(() => firstname);
            _middlename = dt.Rows[0][2].ToString();
            NotifyOfPropertyChange(() => middlename);
            _lastname = dt.Rows[0][3].ToString();
            NotifyOfPropertyChange(() => lastname);
            _sexSelectedItem = dt.Rows[0][4].ToString();
            NotifyOfPropertyChange(() => sexSelectedItem);
            _birthdateSelectedDate = (DateTime)dt.Rows[0][5];
            NotifyOfPropertyChange(() => birthdateSelectedDate);
            _age = dt.Rows[0][6].ToString();
            NotifyOfPropertyChange(() => age);
            _birthplace = dt.Rows[0][7].ToString();
            NotifyOfPropertyChange(() => birthplace);
            _civilstatusSelectedItem = dt.Rows[0][8].ToString();
            NotifyOfPropertyChange(() => civilstatusSelectedItem);
            _address = dt.Rows[0][9].ToString();
            NotifyOfPropertyChange(() => address);
            _department = dt.Rows[0][10].ToString();
            NotifyOfPropertyChange(() => department);
            _position = dt.Rows[0][11].ToString();
            NotifyOfPropertyChange(() => position);
            _rankSelectedItem = dt.Rows[0][12].ToString();
            NotifyOfPropertyChange(() => rank);
            _userlevelSelectedItem = dt.Rows[0][13].ToString();
            NotifyOfPropertyChange(() => userlevelSelectedItem);
            _remarks = dt.Rows[0][14].ToString();
            NotifyOfPropertyChange(() => remarks);
            if (dt.Rows[0][15].ToString() != string.Empty)
            {
                ImageSource imgsource = new BitmapImage(new Uri(dt.Rows[0][15].ToString()));
                _profilePictureSource = imgsource;
                NotifyOfPropertyChange(() => profilePictureSource);
            }
            dt = connection.dbTable("Select * from users where Employee_ID = " + _selectedEmployeeID + "");
            if (dt.Rows.Count > 0)
            {
                _hasAccount = true;
                _username = dt.Rows[0][1].ToString();
                _password = dt.Rows[0][1].ToString();
                _canCreateAccount = true;
                _isPasswodEnabled = true;
                _isUsernameEnabled = true;
                NotifyOfPropertyChange(() => canCreateAccount);
                NotifyOfPropertyChange(() => username);
                NotifyOfPropertyChange(() => password);
                NotifyOfPropertyChange(() => isPasswordEnabled);
                NotifyOfPropertyChange(() => isUsernameEnabled);
            }
        }

        public void saveButton()
        {
            if (_hasAccount && _canCreateAccount)
            {
                connection.dbCommand("UPDATE `ps4`.`users` SET `Username` = '" + _username + "', `Password` = '" + _password + "' WHERE (`Employee_ID` = " + _selectedEmployeeID + ");");
            }
            else if (!_hasAccount && _canCreateAccount)
            {
                connection.dbCommand("INSERT INTO `ps4`.`users` (`Employee_ID`, `Username`, `Password`) VALUES ('" + _selectedEmployeeID + "', '" + _username + "', '" + _password + "');");
            }
            else if (_hasAccount && !_canCreateAccount)
            {
                connection.dbCommand("DELETE FROM `ps4`.`users` WHERE (`Employee_ID` = '" + _selectedEmployeeID + "');");
            }
            if (areRequiredFieldsComplete() && _hasPicture)
            {
                savePicture();
                connection.dbCommand("UPDATE `ps4`.`employeerecords` SET `First_Name` = '" + _firstname + "', `Midle_Name` = '" + _middlename + "', `Last_Name` = '" + _lastname + "', `Sex` = '" + _sexSelectedItem + "', `Birthdate` = '" + _birthdateSelectedDate.ToString("yyyy-MM-dd") + "', `Age` = '" + _age + "', `Birthplace` = '" + _birthplace + "', `Civil_Status` = '" + _civilstatusSelectedItem + "', `Address` = '" + _address + "', `Department` = '" + _department + "', `Position` = '" + _position + "', `Rank` = '" + _rankSelectedItem + "', `User_Level` = '" + _userlevelSelectedItem + "', `Remarks` = '" + _remarks + "', `Picture` = '" + _savedEmployeePictureFilePath + "' WHERE (`Employee_ID` = '" + _selectedEmployeeID + "');");
                connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Employee Record','" + _employeeID + "', '" + currentUser.EmployeeID + "', 'Edited Employee Record " + _employeeID + "')");
                TryClose();
            }
            else if (areRequiredFieldsComplete())
            {
                connection.dbCommand("UPDATE `ps4`.`employeerecords` SET `First_Name` = '" + _firstname + "', `Midle_Name` = '" + _middlename + "', `Last_Name` = '" + _lastname + "', `Sex` = '" + _sexSelectedItem + "', `Birthdate` = '" + _birthdateSelectedDate.ToString("yyyy-MM-dd") + "', `Age` = '" + _age + "', `Birthplace` = '" + _birthplace + "', `Civil_Status` = '" + _civilstatusSelectedItem + "', `Address` = '" + _address + "', `Department` = '" + _department + "', `Position` = '" + _position + "', `Rank` = '" + _rankSelectedItem + "', `User_Level` = '" + _userlevelSelectedItem + "', `Remarks` = '" + _remarks + "' WHERE (`Employee_ID` = '" + _selectedEmployeeID + "');");
                connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Employee Record','" + _employeeID + "', '" + currentUser.EmployeeID + "', 'Edited Employee Record " + _employeeID + "')");
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

        private bool areRequiredFieldsComplete()
        {
            if (
                _firstname == string.Empty ||
                _middlename == string.Empty ||
                _lastname == string.Empty ||
                _sexSelectedItem == string.Empty ||
                _age == string.Empty ||
                _department == string.Empty ||
                _rankSelectedItem == string.Empty ||
                _userlevelSelectedItem == string.Empty
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
            string name = System.IO.Path.GetFileName(_employeePictureFilePath);
            string destinationPath = getAppStartPath(name, "employeePictures");
            destinationPath = destinationPath.Replace(@"\", @"\\");
            destinationPath = destinationPath.Replace(@"\\\\", @"\\");
            _savedEmployeePictureFilePath = destinationPath;
            File.Copy(_employeePictureFilePath, destinationPath, true);
        }
    }
}