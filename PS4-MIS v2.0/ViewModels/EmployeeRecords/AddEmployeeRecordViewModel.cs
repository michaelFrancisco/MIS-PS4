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
    internal class AddEmployeeRecordViewModel : Conductor<object>
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
        private bool _hasPicture = false;
        private bool _isPasswodEnabled = false;
        private bool _isUsernameEnabled = false;
        private string _lastname;
        private string _middlename;
        private string _password;
        private string _position;
        private ImageSource _profilePictureSource;
        private List<string> _rank;
        private string _rankSelectedItem;
        private string _remarks;
        private string _savedEmployeePictureFilePath;
        private List<string> _sex;
        private string _sexSelectedItem;
        private List<string> _userlevel;
        private string _userlevelSelectedItem;
        private string _username;
        private IWindowManager windowManager = new WindowManager();

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

        public void saveButton()
        {
            if (_canCreateAccount)
            {
                DataTable dt = connection.dbTable("SELECT MAX(Employee_ID) FROM employeerecords;");
                int nextID = Int32.Parse(dt.Rows[0][0].ToString());
                nextID++;
                connection.dbCommand("INSERT INTO `ps4`.`users` (`Employee_ID`, `Username`, `Password`) VALUES ('" + nextID + "', '" + _username + "', '" + _password + "');");
            }
            if (areRequiredFieldsComplete() && _hasPicture)
            {
                savePicture();
                connection.dbCommand("INSERT INTO `ps4`.`employeerecords` (`First_Name`, `Midle_Name`, `Last_Name`, `Sex`, `Birthdate`, `Age`, `Birthplace`, `Civil_Status`, `Address`, `Department`, `Position`, `Rank`, `User_Level`, `Remarks`, `Picture`) " +
                    "VALUES ('" + _firstname + "', '" + _middlename + "', '" + _lastname + "', '" + _sexSelectedItem + "', '" + _birthdateSelectedDate.ToString("yyyy-MM-dd") + "', '" + _age + "', '" + _birthplace + "', '" + _civilstatusSelectedItem + "', '" + _address + "', '" + _department + "', '" + _position + "', '" + _rankSelectedItem + "', '" + _userlevelSelectedItem + "', '" + _remarks + "', '" + _savedEmployeePictureFilePath + "');");
                DataTable dt2 = connection.dbTable("select MAX(Employee_ID) from employeerecords");
                connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Employee Record','" + dt2.Rows[0][0].ToString() + "', '" + currentUser.EmployeeID + "', 'Created Employee Record " + dt2.Rows[0][0].ToString() + "')");
                TryClose();
            }
            else if (areRequiredFieldsComplete())
            {
                connection.dbCommand("INSERT INTO `ps4`.`employeerecords` (`First_Name`, `Midle_Name`, `Last_Name`, `Sex`, `Birthdate`, `Age`, `Birthplace`, `Civil_Status`, `Address`, `Department`, `Position`, `Rank`, `User_Level`, `Remarks`, `Picture`) " +
                    "VALUES ('" + _firstname + "', '" + _middlename + "', '" + _lastname + "', '" + _sexSelectedItem + "', '" + _birthdateSelectedDate.ToString("yyyy-MM-dd") + "', '" + _age + "', '" + _birthplace + "', '" + _civilstatusSelectedItem + "', '" + _address + "', '" + _department + "', '" + _position + "', '" + _rankSelectedItem + "', '" + _userlevelSelectedItem + "', '" + _remarks + "', null);");
                DataTable dt2 = connection.dbTable("select MAX(Employee_ID) from employeerecords");
                connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Employee Record','" + dt2.Rows[0][0].ToString() + "', '" + currentUser.EmployeeID + "', 'Created Employee Record " + dt2.Rows[0][0].ToString() + "')");
                TryClose();
            }
            else
            {
                MessageBox.Show("Please fill out all required fields");
            }

        }

        protected override void OnActivate()
        {
            _birthdateSelectedDate = DateTime.Now;
            NotifyOfPropertyChange(() => _birthdateSelectedDate);
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