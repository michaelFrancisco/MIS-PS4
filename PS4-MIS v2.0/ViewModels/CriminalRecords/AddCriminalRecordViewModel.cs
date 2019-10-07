using Caliburn.Micro;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace PS4_MIS_v2._0.ViewModels.CriminalRecords
{
    internal class AddCriminalRecordViewModel : Conductor<object>
    {
        private static string _criminalPictureFilePath;
        private static string _savedCriminalPictureFilePath;
        private string _address;
        private string _age;
        private string _arrestingofficer;
        private DateTime _birthdate;
        private DateTime _birthdateSelectedDate;
        private string _birthplace;
        private string _crime;
        private string _criminalID;
        private string _criminalPicture = null;
        private ImageSource _criminalPictureSource;
        private DateTime _dateofarrest;
        private DateTime _dateofarrestSelectedDate;
        private string _eyecolor;
        private string _firstname;
        private string _haircolor;
        private bool _hasPicture = false;
        private string _hospital;
        private string _lastname;
        private string _middlename;
        private string _placeofarrest;
        private string _remarks;
        private string _selectedSex;
        private List<string> _sex;
        private IWindowManager windowManager = new WindowManager();

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string age
        {
            get { return _age; }
            set
            {
                _age = value;
                NotifyOfPropertyChange(() => age);
            }
        }

        public string arrestingofficer
        {
            get { return _arrestingofficer; }
            set { _arrestingofficer = value; }
        }

        public DateTime birthdate
        {
            get { return _birthdate; }
            set
            {
                _birthdate = value;
                NotifyOfPropertyChange(() => age);
            }
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

        public string crime
        {
            get { return _crime; }
            set { _crime = value; }
        }

        public string criminalID
        {
            get { return _criminalID; }
            set { _criminalID = value; }
        }

        public string criminalpicture
        {
            get { return _criminalPicture; }
            set { _criminalPicture = value; }
        }

        public ImageSource criminalPictureSource
        {
            get { return this._criminalPictureSource; }
            set { this._criminalPictureSource = value; }
        }

        public DateTime dateofarrest
        {
            get { return _dateofarrest; }
            set { _dateofarrest = value; }
        }

        public DateTime dateofarrestSelectedDate
        {
            get { return _dateofarrestSelectedDate; }
            set { _dateofarrestSelectedDate = value; }
        }

        public string eyecolor
        {
            get { return _eyecolor; }
            set { _eyecolor = value; }
        }

        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string haircolor
        {
            get { return _haircolor; }
            set { _haircolor = value; }
        }

        public string hospital
        {
            get { return _hospital; }
            set { _hospital = value; }
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

        public string placeofarrest
        {
            get { return _placeofarrest; }
            set { _placeofarrest = value; }
        }

        public string remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public string selectedSex
        {
            get { return this._selectedSex; }

            set
            {
                this._selectedSex = value;
                this.NotifyOfPropertyChange(() => this.selectedSex);
            }
        }

        public List<string> sex
        {
            get { return new List<string> { "Male", "Female" }; }
            set { _sex = value; }
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
                _criminalPictureFilePath = op.FileName;
                ImageSource imgsource = new BitmapImage(new Uri(_criminalPictureFilePath));
                _criminalPictureSource = imgsource;
                this.NotifyOfPropertyChange(() => this.criminalPictureSource);
                _hasPicture = true;
            }
        }

        public void saveButton()
        {
            if (areRequiredFieldsComplete() && _hasPicture)
            {
                savePicture();
                connection.dbCommand("INSERT INTO `ps4`.`criminalrecords` (`First_Name`, `Middle_Name`, `Last_Name`, `Sex`, `Birthdate`, `Age`, `Birthplace`, `Address`, `Crime`, `Place_of_Arrest`, `Arresting_Officer`, `Date_of_Arrest`, `Eye_Color`, `Hair_Color`, `Remarks`, `Picture`, `Hospital`) " +
                    "VALUES ('" + _firstname + "', '" + _middlename + "', '" + _lastname + "', '" + _selectedSex + "', '" + _birthdateSelectedDate.ToString("yyyy-MM-dd") + "', '" + _age + "', '" + _birthplace + "', '" + _address + "', '" + _crime + "', '" + _placeofarrest + "', '" + _arrestingofficer + "', '" + _dateofarrestSelectedDate.ToString("yyyy-MM-dd") + "', '" + _eyecolor + "', '" + _haircolor + "', '" + _remarks + "', '" + _savedCriminalPictureFilePath + "', '" + _hospital + "');");
                TryClose();
            }
            else if (areRequiredFieldsComplete())
            {
                connection.dbCommand("INSERT INTO `ps4`.`criminalrecords` (`First_Name`, `Middle_Name`, `Last_Name`, `Sex`, `Birthdate`, `Age`, `Birthplace`, `Address`, `Crime`, `Place_of_Arrest`, `Arresting_Officer`, `Date_of_Arrest`, `Eye_Color`, `Hair_Color`, `Remarks`, `Picture`, `Hospital`) " +
                    "VALUES ('" + _firstname + "', '" + _middlename + "', '" + _lastname + "', '" + _selectedSex + "', '" + _birthdateSelectedDate.ToString("yyyy-MM-dd") + "', '" + _age + "', '" + _birthplace + "', '" + _address + "', '" + _crime + "', '" + _placeofarrest + "', '" + _arrestingofficer + "', '" + _dateofarrestSelectedDate.ToString("yyyy-MM-dd") + "', '" + _eyecolor + "', '" + _haircolor + "', '" + _remarks + "', null, '" + _hospital + "');");
                TryClose();
            }
            else
            {
                MessageBox.Show("Please fill out all required fields");
            }
        }

        protected override void OnActivate()
        {
            _birthdateSelectedDate = DateTime.Now.Date;
            _dateofarrestSelectedDate = DateTime.Now.Date;
            NotifyOfPropertyChange(() => birthdateSelectedDate);
            NotifyOfPropertyChange(() => dateofarrestSelectedDate);
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
            string name = System.IO.Path.GetFileName(_criminalPictureFilePath);
            string destinationPath = getAppStartPath(name, "criminalPictures");
            destinationPath = destinationPath.Replace(@"\", @"\\");
            destinationPath = destinationPath.Replace(@"\\\\", @"\\");
            _savedCriminalPictureFilePath = destinationPath;
            File.Copy(_criminalPictureFilePath, destinationPath, true);
        }

        private bool areRequiredFieldsComplete()
        {
            if (
                _firstname == string.Empty ||
                _middlename == string.Empty ||
                _lastname == string.Empty ||
                _selectedSex == string.Empty ||
                _crime == string.Empty ||
                _placeofarrest == string.Empty ||
                _arrestingofficer == string.Empty ||
                _selectedSex == string.Empty
                )
                return false;
            else
                return true;
        }
    }
}