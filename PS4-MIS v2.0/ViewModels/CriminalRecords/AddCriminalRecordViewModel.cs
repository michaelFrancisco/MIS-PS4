using Caliburn.Micro;
using PS4_MIS_v2._0.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PS4_MIS_v2._0.ViewModels.CriminalRecords
{
    class AddCriminalRecordViewModel : Conductor<object>
    {
        IWindowManager windowManager = new WindowManager();
        private int _criminalID;
        private string _criminalpicture = null;
        private string _remarks;
        private string _haircolor;
        private string _eyecolor;
        private DateTime _dateofarrest;
        private string _arrestingofficer;
        private string _placeofarrest;
        private string _crime;
        private string _address;
        private string _birthplace;
        private int _age;
        private DateTime _birthdate;
        private List<string> _sex;
        private string _selectedSex;
        private string _lastname;
        private string _middlename;
        private string _firstname;

        public int criminalID
        {
            get { return _criminalID; }
            set { _criminalID = value; }
        }

        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string middlename
        {
            get { return _middlename; }
            set { _middlename = value; }
        }

        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }


        public List<string> sex
        {
            get { return new List<string> { "Male", "Female" }; }
            set { _sex = value; }
        }



        public string selectedSex
        {
            get
            {
                return this._selectedSex;
            }

            set
            {
                this._selectedSex = value;
                this.NotifyOfPropertyChange(() => this._selectedSex);
            }
        }

        public DateTime birthdate
        {
            get { return _birthdate; }
            set { _birthdate = value; }
        }

        public int age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string birthplace
        {
            get { return _birthplace; }
            set { _birthplace = value; }
        }

        public string address
        {
            get { return _address; }
            set { _address = value; }
        }

        public string crime
        {
            get { return _crime; }
            set { _crime = value; }
        }

        public string placeofarrest
        {
            get { return _placeofarrest; }
            set { _placeofarrest = value; }
        }

        public string arrestingofficer
        {
            get { return _arrestingofficer; }
            set { _arrestingofficer = value; }
        }

        public DateTime dateofarrest
        {
            get { return _dateofarrest; }
            set { _dateofarrest = value; }
        }

        public string eyecolor
        {
            get { return _eyecolor; }
            set { _eyecolor = value; }
        }

        public string haircolor
        {
            get { return _haircolor; }
            set { _haircolor = value; }
        }

        public string remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        public string criminalpicture
        {
            get { return _criminalpicture; }
            set { _criminalpicture = value; }
        }

        public void changePictureButton()
        {

        }

        public void takePictureButton()
        {

        }

        public void saveButton()
        {
            connection.dbCommand("INSERT INTO `ps4`.`criminalrecords` (`First_Name`, `Middle_Name`, `Last_Name`, `Sex`, `Birthdate`, `Age`, `Birthplace`, `Address`, `Crime`, `Place_of_Arrest`, `Arresting_Officer`, `Date_of_Arrest`, `Eye_Color`, `Hair_Color`, `Remarks`, `Picture`) " +
                "VALUES ('" + _firstname + "', '" + _middlename + "', '" + _lastname + "', '" + _selectedSex + "', '" + _birthdate + "', '" + _age + "', '" + _birthplace + "', '" + _address + "', '" + _crime + "', '" + _placeofarrest + "', '" + _arrestingofficer + "', '" + _dateofarrest + "', '" + _eyecolor + "', '" + _haircolor + "', '" + _remarks + "', '" + _criminalpicture + "');");
        }

        public void cancelButton()
        {
            TryClose();
        }
    }
}
