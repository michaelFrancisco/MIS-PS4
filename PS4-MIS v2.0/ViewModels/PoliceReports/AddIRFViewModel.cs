using Caliburn.Micro;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PS4_MIS_v2._0.Model;
using System;
using System.Collections.Generic;
using System.Windows;

namespace PS4_MIS_v2._0.ViewModels.PoliceReports
{
    internal class AddIRFViewModel : Screen
    {
        private string _age;
        private string _barangay;
        private string _blotterentrynumber;
        private string _citizenship;
        private List<string> _civilstatus;
        private string _civilstatusSelectedItem;
        private DateTime _dateofbirth;
        private DateTime _dateofbirthSelectedDate;
        private DateTime _dateofincident;
        private DateTime _dateofincidentSelectedDate;
        private DateTime _datereported;
        private DateTime _datereportedSelectedDate;
        private string _deskofficermobile;
        private string _emailaddress;
        private string _familyname;
        private string _firstname;
        private string _highestedu;
        private string _homephone;
        private string _housenumber;
        private string _idcardpresented;
        private int _incidentHH;
        private int _incidentMM;
        private List<string> _incidentPeriod;
        private string _incidentPeriodSelectedItem;
        private string _middlename;
        private string _mobilephone;
        private string _nickname;
        private string _occupation;
        private string _otherbarangay;
        private string _otherhousenumber;
        private string _otherprovince;
        private string _othertown;
        private string _othervillage;
        private string _placeofbirth;
        private string _placeofincident;
        private string _province;
        private string _qualifier;
        private int _reportedHH;
        private int _reportedMM;
        private List<string> _reportedPeriod;
        private string _reportedPeriodSelectedItem;
        private List<string> _sex;
        private string _sexSelectedItem;
        private string _stationchiefmobile;
        private string _stationnumber;
        private string _town;
        private string _typeofincident;
        private string _village;

        public string age
        {
            get { return _age; }
            set { _age = value; }
        }

        public string barangay
        {
            get { return _barangay; }
            set { _barangay = value; }
        }

        public string blotterentrynumber
        {
            get { return _blotterentrynumber; }
            set { _blotterentrynumber = value; }
        }

        public string citizenship
        {
            get { return _citizenship; }
            set { _citizenship = value; }
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

        public DateTime dateofbirth
        {
            get { return _dateofbirth; }
            set { _dateofbirth = value; }
        }

        public DateTime dateofbirthSelectedDate
        {
            get { return _dateofbirthSelectedDate; }
            set { _dateofbirthSelectedDate = value; }
        }

        public DateTime dateofincident
        {
            get { return _dateofincident; }
            set { _dateofincident = value; }
        }

        public DateTime dateofincidentSelectedDate
        {
            get { return _dateofincidentSelectedDate; }
            set { _dateofincidentSelectedDate = value; }
        }

        public DateTime datereported
        {
            get { return _datereported; }
            set { _datereported = value; }
        }

        public DateTime datereportedSelectedDate
        {
            get { return _datereportedSelectedDate; }
            set { _datereportedSelectedDate = value; }
        }

        public string deskofficermobile
        {
            get { return _deskofficermobile; }
            set { _deskofficermobile = value; }
        }

        public string emailaddress
        {
            get { return _emailaddress; }
            set { _emailaddress = value; }
        }

        public string familyname
        {
            get { return _familyname; }
            set { _familyname = value; }
        }

        public string firstname
        {
            get { return _firstname; }
            set { _firstname = value; }
        }

        public string highestedu
        {
            get { return _highestedu; }
            set { _highestedu = value; }
        }

        public string homephone
        {
            get { return _homephone; }
            set { _homephone = value; }
        }

        public string housenumber
        {
            get { return _housenumber; }
            set { _housenumber = value; }
        }

        public string idcardpresented
        {
            get { return _idcardpresented; }
            set { _idcardpresented = value; }
        }

        public int incidentHH
        {
            get { return _incidentHH; }
            set { _incidentHH = value; }
        }

        public int incidentMM
        {
            get { return _incidentMM; }
            set { _incidentMM = value; }
        }

        public List<string> incidentPeriod
        {
            get { return new List<string> { "AM", "PM" }; }
            set { incidentPeriod = value; }
        }

        public string incidentPeriodSelectedItem
        {
            get { return _incidentPeriodSelectedItem; }
            set { _incidentPeriodSelectedItem = value; }
        }

        public string middlename
        {
            get { return _middlename; }
            set { _middlename = value; }
        }

        public string mobilephone
        {
            get { return _mobilephone; }
            set { _mobilephone = value; }
        }

        public string nickname
        {
            get { return _nickname; }
            set { _nickname = value; }
        }

        public string occupation
        {
            get { return _occupation; }
            set { _occupation = value; }
        }

        public string otherbarangay
        {
            get { return _otherbarangay; }
            set { _otherbarangay = value; }
        }

        public string otherhousenumber
        {
            get { return _otherhousenumber; }
            set { _otherhousenumber = value; }
        }

        public string otherprovince
        {
            get { return _otherprovince; }
            set { _otherprovince = value; }
        }

        public string othertown
        {
            get { return _othertown; }
            set { _othertown = value; }
        }

        public string othervillage
        {
            get { return _othervillage; }
            set { _othervillage = value; }
        }

        public string placeofbirth
        {
            get { return _placeofbirth; }
            set { _placeofbirth = value; }
        }

        public string placeofincident
        {
            get { return _placeofincident; }
            set { _placeofincident = value; }
        }

        public string province
        {
            get { return _province; }
            set { _province = value; }
        }

        public string qualifier
        {
            get { return _qualifier; }
            set { _qualifier = value; }
        }

        public int reportedHH
        {
            get { return _reportedHH; }
            set { _reportedHH = value; }
        }

        public int reportedMM
        {
            get { return _reportedMM; }
            set { _reportedMM = value; }
        }

        public List<string> reportedPeriod
        {
            get { return new List<string> { "AM", "PM" }; }
            set { _reportedPeriod = value; }
        }

        public string reportedPeriodSelectedItem
        {
            get { return _reportedPeriodSelectedItem; }
            set { _reportedPeriodSelectedItem = value; }
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

        public string stationchiefmobile
        {
            get { return _stationchiefmobile; }
            set { _stationchiefmobile = value; }
        }

        public string stationnumber
        {
            get { return _stationnumber; }
            set { _stationnumber = value; }
        }

        public string town
        {
            get { return _town; }
            set { _town = value; }
        }

        public string typeofincident
        {
            get { return _typeofincident; }
            set { _typeofincident = value; }
        }

        public string village
        {
            get { return _village; }
            set { _village = value; }
        }

        public void cancelButton()
        {
            filloutPDF();
        }

        public void saveButton()
        {
            connection.dbCommand("INSERT INTO `ps4`.`irf` (`Blotter_Entry_Number`, `Type_Of_Incident`, `DateTime_Reported`, `DateTime_of_Incident`, `Recorded_By`, `Place_Of_Incident`, `Station_Phone_Number`, `DO_Mobile`, `Chief_Mobile`) VALUES ('" + _blotterentrynumber + "', '" + _typeofincident + "', '" + datetimereported() + "', '" + datetimeincident() + "', '" + currentUser.EmployeeID + "', '" + _placeofincident + "', '" + _stationnumber + "', '" + _deskofficermobile + "', '" + _stationchiefmobile + "');");
            connection.dbCommand("INSERT INTO `ps4`.`irfa` (`Blotter_Entry_Number`, `Family_Name`, `First_Name`, `Middle_Name`, `Qualifier`, `Nickname`, `Citizenship`, `Sex`, `Civil_Status`, `Date_of_Birth`, `Age`, `Place_of_Birth`, `Home_Phone`, `Mobile_Phone`, `House_Number`, `Vilage`, `Barangay`, `Town`, `Province`, `Other_House_Number`, `Other_Village`, `Other_Barangay`, `Other_Town`, `Other_Province`, `Highest_Educational_Attainment`, `Occupation`, `ID_Card_Presented`, `Email_Address`) VALUES ('" + _blotterentrynumber + "', '" + _familyname + "', '" + _firstname + "', '" + _middlename + "', '" + _qualifier + "', '" + _nickname + "', '" + _citizenship + "', '" + _sexSelectedItem + "', '" + _civilstatusSelectedItem + "', '" + _dateofbirthSelectedDate + "', '" + _age + "', '" + _placeofbirth + "', '" + _homephone + "', '" + _mobilephone + "', '" + _housenumber + "', '" + _village + "', '" + _barangay + "', '" + _town + "', '" + _province + "', '" + _otherhousenumber + "', '" + _othervillage + "', '" + _otherbarangay + "', '" + _othertown + "', '" + _otherprovince + "', '" + _highestedu + "', '" + _occupation + "', '" + _idcardpresented + "', '" + _emailaddress + "');");
        }

        private void filloutPDF()
        {
            filloutItemsArray();
            PdfDocument pd = PdfReader.Open(getAppStartPath("IRF PAGE 1.pdf"), PdfDocumentOpenMode.Modify);
            for(int i = 0; i < 31; i++)
            {
                pd.AcroForm.Fields[i].Value = new PdfString(_itemsArray[i]);
            }
            if (pd.AcroForm.Elements.ContainsKey("/NeedAppearances"))
            {
                pd.AcroForm.Elements["/NeedAppearances"] = new PdfBoolean(true);
            }
            else
            {
                pd.AcroForm.Elements.Add("/NeedAppearances", new PdfBoolean(true));
            }
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            pd.Save(path + @"\IRF " + _blotterentrynumber + ".pdf");
        }

        private string[] _itemsArray = new string[31];

        private void filloutItemsArray()
        {
            _itemsArray[0] = _blotterentrynumber;
            _itemsArray[1] = _typeofincident;
            _itemsArray[2] = datetimereported().ToString();
            _itemsArray[3] = datetimeincident().ToString();
            _itemsArray[4] = _familyname;
            _itemsArray[5] = _firstname;
            _itemsArray[6] = _middlename;
            _itemsArray[7] = _qualifier;
            _itemsArray[8] = _nickname;
            _itemsArray[9] = _citizenship;
            _itemsArray[10] = _sexSelectedItem;
            _itemsArray[11] = _civilstatusSelectedItem;
            _itemsArray[12] = _dateofbirthSelectedDate.ToString();
            _itemsArray[13] = _age;
            _itemsArray[14] = _placeofbirth;
            _itemsArray[15] = _homephone;
            _itemsArray[16] = _mobilephone;
            _itemsArray[17] = _housenumber;
            _itemsArray[18] = _village;
            _itemsArray[19] = _barangay;
            _itemsArray[20] = _town;
            _itemsArray[21] = _province;
            _itemsArray[22] = _otherhousenumber;
            _itemsArray[23] = _othervillage;
            _itemsArray[24] = _otherbarangay;
            _itemsArray[25] = _othertown;
            _itemsArray[26] = _otherprovince;
            _itemsArray[27] = _highestedu;
            _itemsArray[28] = _occupation;
            _itemsArray[29] = _idcardpresented;
            _itemsArray[30] = _emailaddress;
        }


        private static String getAppStartPath(string filename)
        {
            String appStartPath = System.AppDomain.CurrentDomain.BaseDirectory;
            appStartPath = String.Format(appStartPath + @"\{0}\" + filename, "pdfs");
            return appStartPath;
        }

        private string datetimeincident()
        {
            int hour = _reportedHH;
            if (_incidentPeriodSelectedItem == "PM")
            {
                hour += 12;
            }
            return _dateofincident.ToString("yyyy-MM-dd") + " " + hour.ToString() + ":" + _incidentMM.ToString() + ":00";
        }

        private string datetimereported()
        {
            int hour = _reportedHH;
            if (_reportedPeriodSelectedItem == "PM")
            {
                hour += 12;
            }
            return _datereported.ToString("yyyy-MM-dd") + " " + hour.ToString() + ":" + _reportedMM.ToString() + ":00";
        }
    }
}