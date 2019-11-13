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
        public string[] _itemsArray = new string[124];
        private string _a1;
        private string _a10;
        private string _a11;
        private string _a12;
        private string _a13;
        private string _a14;
        private string _a15;
        private string _a16;
        private string _a17;
        private string _a18;
        private string _a19;
        private string _a2;
        private string _a20;
        private string _a21;
        private string _a22;
        private string _a23;
        private string _a24;
        private string _a25;
        private string _a26;
        private string _a27;
        private string _a28;
        private string _a3;
        private string _a4;
        private string _a5;
        private string _a6;
        private List<string> _a7;
        private string _a7si;
        private List<string> _a8;
        private string _a8si;
        private DateTime _a9;
        private DateTime _a9sd;
        private string _b1;
        private string _b10;
        private string _b11;
        private string _b12;
        private string _b13;
        private string _b14;
        private string _b15;
        private string _b16;
        private string _b17;
        private List<string> _b18;
        private string _b18si;
        private string _b19;
        private string _b2;
        private string _b20;
        private string _b21;
        private string _b22;
        private string _b23;
        private string _b24;
        private string _b25;
        private string _b26;
        private string _b27;
        private string _b28;
        private string _b29;
        private string _b3;
        private string _b30;
        private string _b31;
        private string _b32;
        private string _b33;
        private string _b34;
        private string _b35;
        private string _b36;
        private string _b37;
        private string _b38;
        private string _b39;
        private string _b4;
        private string _b40;
        private string _b5;
        private string _b6;
        private List<string> _b7;
        private string _b7si;
        private List<string> _b8;
        private string _b8si;
        private DateTime _b9;
        private DateTime _b9sd;
        private string _c1;
        private string _c10;
        private string _c11;
        private string _c12;
        private string _c13;
        private string _c14;
        private string _c15;
        private string _c16;
        private string _c17;
        private string _c18;
        private string _c19;
        private string _c2;
        private string _c20;
        private string _c21;
        private string _c22;
        private string _c23;
        private string _c24;
        private string _c25;
        private string _c26;
        private string _c27;
        private string _c28;
        private string _c3;
        private string _c4;
        private string _c5;
        private string _c6;
        private List<string> _c7;
        private string _c7si;
        private List<string> _c8;
        private string _c8si;
        private DateTime _c9;
        private DateTime _c9sd;
        private string _d1;
        private string _e1;
        private string _e2;
        private string _e3;
        private string _e4;
        private string _e5;
        private string _e6;
        private string _e7;
        private string _z1;
        private List<string> _z10;
        private string _z10si;
        private string _z11;
        private string _z12;
        private string _z13;
        private string _z14;
        private string _z2;
        private DateTime _z3;
        private DateTime _z3sd;
        private int _z4;
        private int _z5;
        private List<string> _z6;
        private string _z6si;
        private DateTime _z7;
        private DateTime _z7sd;
        private int _z8;
        private int _z9;

        public string a1
        {
            get { return _a1; }
            set { _a1 = value; }
        }

        public string a10
        {
            get { return _a10; }
            set { _a10 = value; }
        }

        public string a11
        {
            get { return _a11; }
            set { _a11 = value; }
        }

        public string a12
        {
            get { return _a12; }
            set { _a12 = value; }
        }

        public string a13
        {
            get { return _a13; }
            set { _a13 = value; }
        }

        public string a14
        {
            get { return _a14; }
            set { _a14 = value; }
        }

        public string a15
        {
            get { return _a15; }
            set { _a15 = value; }
        }

        public string a16
        {
            get { return _a16; }
            set { _a16 = value; }
        }

        public string a17
        {
            get { return _a17; }
            set { _a17 = value; }
        }

        public string a18
        {
            get { return _a18; }
            set { _a18 = value; }
        }

        public string a19
        {
            get { return _a19; }
            set { _a19 = value; }
        }

        public string a2
        {
            get { return _a2; }
            set { _a2 = value; }
        }

        public string a20
        {
            get { return _a20; }
            set { _a20 = value; }
        }

        public string a21
        {
            get { return _a21; }
            set { _a21 = value; }
        }

        public string a22
        {
            get { return _a22; }
            set { _a22 = value; }
        }

        public string a23
        {
            get { return _a23; }
            set { _a23 = value; }
        }

        public string a24
        {
            get { return _a24; }
            set { _a24 = value; }
        }

        public string a25
        {
            get { return _a25; }
            set { _a25 = value; }
        }

        public string a26
        {
            get { return _a26; }
            set { _a26 = value; }
        }

        public string a27
        {
            get { return _a27; }
            set { _a27 = value; }
        }

        public string a28
        {
            get { return _a28; }
            set { _a28 = value; }
        }

        public string a3
        {
            get { return _a3; }
            set { _a3 = value; }
        }

        public string a4
        {
            get { return _a4; }
            set { _a4 = value; }
        }

        public string a5
        {
            get { return _a5; }
            set { _a5 = value; }
        }

        public string a6
        {
            get { return _a6; }
            set { _a6 = value; }
        }

        public List<string> a7
        {
            get { return new List<string> { "Male", "Female" }; }
            set { _a7 = value; }
        }

        public string a7si
        {
            get { return _a7si; }
            set { _a7si = value; }
        }

        public List<string> a8
        {
            get { return new List<string> { "Single", "Married", "Widow" }; }
            set { _a8 = value; }
        }

        public string a8si
        {
            get { return _a8si; }
            set { _a8si = value; }
        }

        public DateTime a9
        {
            get { return _a9; }
            set { _a9 = value; }
        }

        public DateTime a9sd
        {
            get { return _a9sd; }
            set
            {
                _a9sd = value;
                _a10 = (DateTime.Now.Year - _a9sd.Year).ToString();
                NotifyOfPropertyChange(() => _a10);
            }
        }

        public string b1
        {
            get { return _b1; }
            set { _b1 = value; }
        }

        public string b10
        {
            get { return _b10; }
            set { _b10 = value; }
        }

        public string b11
        {
            get { return _b11; }
            set { _b11 = value; }
        }

        public string b12
        {
            get { return _b12; }
            set { _b12 = value; }
        }

        public string b13
        {
            get { return _b13; }
            set { _b13 = value; }
        }

        public string b14
        {
            get { return _b14; }
            set { _b14 = value; }
        }

        public string b15
        {
            get { return _b15; }
            set { _b15 = value; }
        }

        public string b16
        {
            get { return _b16; }
            set { _b16 = value; }
        }

        public string b17
        {
            get { return _b17; }
            set { _b17 = value; }
        }

        public List<string> b18
        {
            get { return new List<string> { "Yes", "No" }; }
            set { _b18 = value; }
        }

        public string b18si
        {
            get { return _b18si; }
            set { _b18si = value; }
        }

        public string b19
        {
            get { return _b19; }
            set { _b19 = value; }
        }

        public string b2
        {
            get { return _b2; }
            set { _b2 = value; }
        }

        public string b20
        {
            get { return _b20; }
            set { _b20 = value; }
        }

        public string b21
        {
            get { return _b21; }
            set { _b21 = value; }
        }

        public string b22
        {
            get { return _b22; }
            set { _b22 = value; }
        }

        public string b23
        {
            get { return _b23; }
            set { _b23 = value; }
        }

        public string b24
        {
            get { return _b24; }
            set { _b24 = value; }
        }

        public string b25
        {
            get { return _b25; }
            set { _b25 = value; }
        }

        public string b26
        {
            get { return _b26; }
            set { _b26 = value; }
        }

        public string b27
        {
            get { return _b27; }
            set { _b27 = value; }
        }

        public string b28
        {
            get { return _b28; }
            set { _b28 = value; }
        }

        public string b29
        {
            get { return _b29; }
            set { _b29 = value; }
        }

        public string b3
        {
            get { return _b3; }
            set { _b3 = value; }
        }

        public string b30
        {
            get { return _b30; }
            set { _b30 = value; }
        }

        public string b31
        {
            get { return _b31; }
            set { _b31 = value; }
        }

        public string b32
        {
            get { return _b32; }
            set { _b32 = value; }
        }

        public string b33
        {
            get { return _b33; }
            set { _b33 = value; }
        }

        public string b34
        {
            get { return _b34; }
            set { _b34 = value; }
        }

        public string b35
        {
            get { return _b35; }
            set { _b35 = value; }
        }

        public string b36
        {
            get { return _b36; }
            set { _b36 = value; }
        }

        public string b37
        {
            get { return _b37; }
            set { _b37 = value; }
        }

        public string b38
        {
            get { return _b38; }
            set { _b38 = value; }
        }

        public string b39
        {
            get { return _b39; }
            set { _b39 = value; }
        }

        public string b4
        {
            get { return _b4; }
            set { _b4 = value; }
        }

        public string b40
        {
            get { return _b40; }
            set { _b40 = value; }
        }

        public string b5
        {
            get { return _b5; }
            set { _b5 = value; }
        }

        public string b6
        {
            get { return _b6; }
            set { _b6 = value; }
        }

        public List<string> b7
        {
            get { return new List<string> { "Male", "Female" }; }
            set { _b7 = value; }
        }

        public string b7si
        {
            get { return _b7si; }
            set { _b7si = value; }
        }

        public List<string> b8
        {
            get { return new List<string> { "Single", "Married", "Widow" }; }
            set { _b8 = value; }
        }

        public string b8si
        {
            get { return _b8si; }
            set { _b8si = value; }
        }

        public DateTime b9
        {
            get { return _b9; }
            set { _b9 = value; }
        }

        public DateTime b9sd
        {
            get { return _b9sd; }
            set
            {
                _b9sd = value;
                _b10 = (DateTime.Now.Year - _b9sd.Year).ToString();
                NotifyOfPropertyChange(() => _b10);
            }
        }

        public string c1
        {
            get { return _c1; }
            set { _c1 = value; }
        }

        public string c10
        {
            get { return _c10; }
            set { _c10 = value; }
        }

        public string c11
        {
            get { return _c11; }
            set { _c11 = value; }
        }

        public string c12
        {
            get { return _c12; }
            set { _c12 = value; }
        }

        public string c13
        {
            get { return _c13; }
            set { _c13 = value; }
        }

        public string c14
        {
            get { return _c14; }
            set { _c14 = value; }
        }

        public string c15
        {
            get { return _c15; }
            set { _c15 = value; }
        }

        public string c16
        {
            get { return _c16; }
            set { _c16 = value; }
        }

        public string c17
        {
            get { return _c17; }
            set { _c17 = value; }
        }

        public string c18
        {
            get { return _c18; }
            set { _c18 = value; }
        }

        public string c19
        {
            get { return _c19; }
            set { _c19 = value; }
        }

        public string c2
        {
            get { return _c2; }
            set { _c2 = value; }
        }

        public string c20
        {
            get { return _c20; }
            set { _c20 = value; }
        }

        public string c21
        {
            get { return _c21; }
            set { _c21 = value; }
        }

        public string c22
        {
            get { return _c22; }
            set { _c22 = value; }
        }

        public string c23
        {
            get { return _c23; }
            set { _c23 = value; }
        }

        public string c24
        {
            get { return _c24; }
            set { _c24 = value; }
        }

        public string c25
        {
            get { return _c25; }
            set { _c25 = value; }
        }

        public string c26
        {
            get { return _c26; }
            set { _c26 = value; }
        }

        public string c27
        {
            get { return _c27; }
            set { _c27 = value; }
        }

        public string c28
        {
            get { return _c28; }
            set { _c28 = value; }
        }

        public string c3
        {
            get { return _c3; }
            set { _c3 = value; }
        }

        public string c4
        {
            get { return _c4; }
            set { _c4 = value; }
        }

        public string c5
        {
            get { return _c5; }
            set { _c5 = value; }
        }

        public string c6
        {
            get { return _c6; }
            set { _c6 = value; }
        }

        public List<string> c7
        {
            get { return new List<string> { "Male", "Female" }; }
            set { _c7 = value; }
        }

        public string c7si
        {
            get { return _c7si; }
            set { _c7si = value; }
        }

        public List<string> c8
        {
            get { return new List<string> { "Single", "Married", "Widow" }; }
            set { _c8 = value; }
        }

        public string c8si
        {
            get { return _c8si; }
            set { _c8si = value; }
        }

        public DateTime c9
        {
            get { return _c9; }
            set { _c9 = value; }
        }

        public DateTime c9sd
        {
            get { return _c9sd; }
            set
            {
                _c9sd = value;
                _c10 = (DateTime.Now.Year - _c9sd.Year).ToString();
                NotifyOfPropertyChange(() => _c10);
            }
        }

        public string d1
        {
            get { return _d1; }
            set { _d1 = value; }
        }

        public string e1
        {
            get { return _e1; }
            set { _e1 = value; }
        }

        public string e2
        {
            get { return _e2; }
            set { _e2 = value; }
        }

        public string e3
        {
            get { return _e3; }
            set { _e3 = value; }
        }

        public string e4
        {
            get { return _e4; }
            set { _e4 = value; }
        }

        public string e5
        {
            get { return _e5; }
            set { _e5 = value; }
        }

        public string e6
        {
            get { return _e6; }
            set { _e6 = value; }
        }

        public string e7
        {
            get { return _e7; }
            set { _e7 = value; }
        }

        public string z1
        {
            get { return _z1; }
            set { _z1 = value; }
        }

        public List<string> z10
        {
            get { return new List<string> { "AM", "PM" }; }
            set { _z10 = value; }
        }

        public string z10si
        {
            get { return _z10si; }
            set { _z10si = value; }
        }

        public string z11
        {
            get { return _z11; }
            set { _z11 = value; }
        }

        public string z12
        {
            get { return _z12; }
            set { _z12 = value; }
        }

        public string z13
        {
            get { return _z13; }
            set { _z13 = value; }
        }

        public string z14
        {
            get { return _z14; }
            set { _z14 = value; }
        }

        public string z2
        {
            get { return _z2; }
            set { _z2 = value; }
        }

        public DateTime z3
        {
            get { return _z3; }
            set { _z3 = value; }
        }

        public DateTime z3sd
        {
            get { return _z3sd; }
            set { _z3sd = value; }
        }

        public int z4
        {
            get { return _z4; }
            set { _z4 = value; }
        }

        public int z5
        {
            get { return _z5; }
            set { _z5 = value; }
        }

        public List<string> z6
        {
            get { return new List<string> { "AM", "PM" }; }
            set { _z6 = value; }
        }

        public string z6si
        {
            get { return _z6si; }
            set { _z6si = value; }
        }

        public DateTime z7
        {
            get { return _z7; }
            set { _z7 = value; }
        }

        public DateTime z7sd
        {
            get { return _z7sd; }
            set { _z7sd = value; }
        }

        public int z8
        {
            get { return _z8; }
            set { _z8 = value; }
        }

        public int z9
        {
            get { return _z9; }
            set { _z9 = value; }
        }

        public void cancelButton()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Are you sure? Unsaved changes will be lost.", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                TryClose();
            }
        }

        public void saveasPDFButton()
        {
            MessageBoxResult dialogResult = MessageBox.Show("Save IRF " + _z1 + " to desktop as PDF?", "!", MessageBoxButton.YesNo);
            if (dialogResult == MessageBoxResult.Yes)
            {
                filloutPDF();
            }
        }

        public void saveButton()
        {
            connection.dbCommand("INSERT INTO `ps4`.`irf` (`Blotter_Entry_Number`, `Type_Of_Incident`, `DateTime_Reported`, `DateTime_of_Incident`, `Recorded_By`, `Place_Of_Incident`, `Station_Phone_Number`, `DO_Mobile`, `Chief_Mobile`, `Narrative`)" +
                "VALUES ('" + _z1 + "', '" + _z2 + "', '" + datetimereported() + "', '" + datetimeincident() + "', '" + currentUser.EmployeeID + "', '" + _z11 + "', '" + _z12 + "', '" + _z13 + "', '" + _z14 + "', '" + _d1 + "');");
            connection.dbCommand("INSERT INTO `ps4`.`irfa` (`Blotter_Entry_Number`, `Family_Name`, `First_Name`, `Middle_Name`, `Qualifier`, `Nickname`, `Citizenship`, `Sex`, `Civil_Status`, `Date_of_Birth`, `Age`, `Place_of_Birth`, `Home_Phone`, `Mobile_Phone`, `House_Number`, `Vilage`, `Barangay`, `Town`, `Province`, `Other_House_Number`, `Other_Village`, `Other_Barangay`, `Other_Town`, `Other_Province`, `Highest_Educational_Attainment`, `Occupation`, `ID_Card_Presented`, `Email_Address`) " +
                "VALUES ('" + _z1 + "', '" + _a1 + "', '" + _a2 + "', '" + _a3 + "', '" + _a4 + "', '" + _a5 + "', '" + _a6 + "', '" + _a7si + "', '" + _a8si + "', '" + _a9sd.ToString("yyyy-MM-dd") + "', '" + _a10 + "', '" + _a11 + "', '" + _a12 + "', '" + _a14 + "', '" + _a17 + "', '" + _a18 + "', '" + _a19 + "', '" + _a20 + "', '" + _a21 + "', '" + _a22 + "', '" + _a23 + "', '" + _a24 + "', '" + _a25 + "', '" + _a26 + "', '" + _a15 + "', '" + _a16 + "', '" + _a27 + "', '" + _a28 + "');");
            connection.dbCommand("INSERT INTO `ps4`.`irfb` (`Blotter_Entry_Number`, `Family_Name`, `First_Name`, `Middle_Name`, `Qualifier`, `Nickname`, `Citizenship`, `Sex`, `Civil_Status`, `Date_of_Birth`, `Age`, `Place_of_Birth`, `Home_Phone`, `Mobile_Phone`, `House_Number`, `Vilage`, `Barangay`, `Town`, `Province`, `Other_House_Number`, `Other_Village`, `Other_Barangay`, `Other_Town`, `Other_Province`, `Highest_Educational_Attainment`, `Work_Address`, `Relation_To_Victim`, `Email_Address`, `Rank`, `Unit_Assignment`, `Group_Affiliation`, `Previous_Criminal_Record`, `Status_Of_Previous_Case`, `Height`, `Weight`, `Color_Of_Eyes`, `Description_Of_Eyes`, `Color_Of_Hair`, `Description_Of_Hair`, `Under_The_Influence`) " +
                "VALUES ('" + _z1 + "', '" + _b1 + "', '" + _b2 + "', '" + _b3 + "', '" + _b4 + "', '" + _b5 + "', '" + _b6 + "', '" + _b7si + "', '" + _b8si + "', '" + _b9sd.ToString("yyyy-MM-dd") + "', '" + _b10 + "', '" + _b11 + "', '" + _b12 + "', '" + _b13 + "', '" + _b22 + "', '" + _b23 + "', '" + _b24 + "', '" + _b25 + "', '" + _b26 + "', '" + _b27 + "', '" + _b28 + "', '" + _b29 + "', '" + _b30 + "', '" + _b31 + "', '" + _b14 + "', '" + _b16 + "', '" + _b40 + "', '" + _b32 + "', '" + _b33 + "', '" + _b34 + "', '" + _b35 + "', '" + _b18si + "', '" + _b36 + "', '" + _b19 + "', '" + _b37 + "', '" + _b20 + "', '" + _b38 + "', '" + _b21 + "', '" + _b39 + "', '');");
            connection.dbCommand("INSERT INTO `ps4`.`irfc` (`Blotter_Entry_Number`, `Family_Name`, `First_Name`, `Middle_Name`, `Qualifier`, `Nickname`, `Citizenship`, `Sex`, `Civil_Status`, `Date_Of_Birth`, `Age`, `Place_Of_Birth`, `Home_Phone`, `Mobile_Phone`, `House_Number`, `Village`, `Barangay`, `Town`, `Province`, `Other_House_Number`, `Other_Village`, `Other_Barangay`, `Other_Town`, `Other_Province`, `Highest_Educational_Attainment`, `Occupation`, `Work_Address`, `Email_Address`) " +
                "VALUES ('" + _z1 + "', '" + _c1 + "', '" + _c2 + "', '" + _c3 + "', '" + _c4 + "', '" + _c5 + "', '" + _c6 + "', '" + _c7si + "', '" + _c8si + "', '" + _c9sd.ToString("yyyy-MM-dd") + "', '" + _c10 + "', '" + _c11 + "', '" + _c12 + "', '" + _c13 + "', '" + _c17 + "', '" + _c18 + "', '" + _c19 + "', '" + _c20 + "', '" + _c21 + "', '" + _c22 + "', '" + _c23 + "', '" + _c24 + "', '" + _c25 + "', '" + _c26 + "', '" + _c14 + "', '" + _c15 + "', '" + _c16 + "', '" + _c28 + "');");
            connection.dbCommand("INSERT INTO `ps4`.`irfd` (`Name_Of_Guardian`, `Guardian_Address`, `Home_Phone`, `Mobile_Phone`, `Diversion_Mechanism`, `Features`) VALUES ('" + _e1 + "', '" + _e2 + "', '" + _e3 + "', '" + _e4 + "', '" + _e5 + "', '" + _e6 + "');");
            TryClose();
        }

        private static String getAppStartPath(string filename)
        {
            String appStartPath = System.AppDomain.CurrentDomain.BaseDirectory;
            appStartPath = String.Format(appStartPath + @"{0}" + filename, @"pdfs\");
            return appStartPath;
        }

        private string datetimeincident()
        {
            int hour = _z8;
            if (_z10si == "PM")
            {
                hour += 12;
            }
            return _z7.ToString("yyyy-MM-dd") + " " + hour.ToString() + ":" + _z9.ToString() + ":00";
        }

        private string datetimereported()
        {
            int hour = _z4;
            if (_z6si == "PM")
            {
                hour += 12;
            }
            return _z3.ToString("yyyy-MM-dd") + " " + hour.ToString() + ":" + _z5.ToString() + ":00";
        }

        private void filloutItemsArray()
        {
            _itemsArray[0] = _z1;
            _itemsArray[1] = _z2;
            _itemsArray[2] = datetimereported();
            _itemsArray[3] = datetimeincident();
            _itemsArray[4] = _a1;
            _itemsArray[5] = _a2;
            _itemsArray[6] = _a3;
            _itemsArray[7] = _a4;
            _itemsArray[8] = _a5;
            _itemsArray[9] = _a6;
            _itemsArray[10] = _a7si;
            _itemsArray[11] = _a8si;
            _itemsArray[12] = _a9sd.ToString("yyyy-MM-dd");
            _itemsArray[13] = _a10;
            _itemsArray[14] = _a11;
            _itemsArray[15] = _a12;
            _itemsArray[16] = _a14;
            _itemsArray[17] = _a17;
            _itemsArray[18] = _a18;
            _itemsArray[19] = _a19;
            _itemsArray[20] = _a20;
            _itemsArray[21] = _a21;
            _itemsArray[22] = _a22;
            _itemsArray[23] = _a23;
            _itemsArray[24] = _a24;
            _itemsArray[25] = _a25;
            _itemsArray[26] = _a26;
            _itemsArray[27] = _a15;
            _itemsArray[28] = _a16;
            _itemsArray[29] = _a27;
            _itemsArray[30] = _a28;
            _itemsArray[31] = _b1;
            _itemsArray[32] = _b2;
            _itemsArray[33] = _b3;
            _itemsArray[34] = _b4;
            _itemsArray[35] = _b5;
            _itemsArray[36] = _b6;
            _itemsArray[37] = _b7si;
            _itemsArray[38] = _b8si;
            _itemsArray[39] = _b9sd.ToString("yyyy-MM-dd");
            _itemsArray[40] = _b10;
            _itemsArray[41] = _b11;
            _itemsArray[42] = _b12;
            _itemsArray[43] = _b13;
            _itemsArray[44] = _b22;
            _itemsArray[45] = _b23;
            _itemsArray[46] = _b24;
            _itemsArray[47] = _b25;
            _itemsArray[48] = _b26;
            _itemsArray[49] = _b27;
            _itemsArray[50] = _b28;
            _itemsArray[51] = _b29;
            _itemsArray[52] = _b30;
            _itemsArray[53] = _b31;
            _itemsArray[54] = _b14;
            _itemsArray[55] = _b15;
            _itemsArray[56] = _b16;
            _itemsArray[57] = _b40;
            _itemsArray[58] = _b32;
            _itemsArray[59] = _b33;
            _itemsArray[60] = _b34;
            _itemsArray[61] = _b35;
            _itemsArray[62] = _b36;
            _itemsArray[63] = _b19;
            _itemsArray[64] = _b37;
            _itemsArray[65] = _b20;
            _itemsArray[66] = _b38;
            _itemsArray[67] = _b21;
            _itemsArray[68] = _b39;
            _itemsArray[69] = _e1;
            _itemsArray[70] = _e2;
            _itemsArray[71] = _e3;
            _itemsArray[72] = _e4;
            _itemsArray[73] = _e5;
            _itemsArray[74] = _z1;
            _itemsArray[75] = _a2 + " " + _a3 + ". " + _a1;
            _itemsArray[76] = _a18;
            _itemsArray[77] = _z2;
            _itemsArray[78] = datetimereported();
            _itemsArray[79] = datetimeincident();
            _itemsArray[80] = _z11;
            _itemsArray[81] = _c1;
            _itemsArray[82] = _c2;
            _itemsArray[83] = _c3;
            _itemsArray[84] = _c4;
            _itemsArray[85] = _c5;
            _itemsArray[86] = _c6;
            _itemsArray[87] = _c7si;
            _itemsArray[88] = _c8si;
            _itemsArray[89] = _c9sd.ToString("yyyy-MM-dd");
            _itemsArray[90] = _c10;
            _itemsArray[91] = _c11;
            _itemsArray[92] = _c12;
            _itemsArray[93] = _c13;
            _itemsArray[94] = _c17;
            _itemsArray[95] = _c18;
            _itemsArray[96] = _c19;
            _itemsArray[97] = _c20;
            _itemsArray[98] = _c21;
            _itemsArray[99] = _c22;
            _itemsArray[100] = _c23;
            _itemsArray[101] = _c24;
            _itemsArray[102] = _c25;
            _itemsArray[103] = _c26;
            _itemsArray[104] = _c14;
            _itemsArray[105] = _c15;
            _itemsArray[106] = _c16;
            _itemsArray[107] = _c28;
            _itemsArray[108] = _z1;
            _itemsArray[109] = _z2;
            _itemsArray[110] = _z8 + ":" + _z9 + " " + _z10si;
            _itemsArray[111] = _z7sd.ToString("yyyy-MM-dd");
            _itemsArray[112] = _z11;
            _itemsArray[117] = _z13;
            _itemsArray[118] = _z14;
            _itemsArray[119] = _e7;
            _itemsArray[120] = _d1;
            _itemsArray[121] = "Novaliches Police Station 4";
            _itemsArray[122] = _z12;
            _itemsArray[123] = "PLTCOL ROSSEL I CEJAS";
        }

        private void filloutPDF()
        {
            filloutItemsArray();
            PdfDocument pd = PdfReader.Open(getAppStartPath("IRF.pdf"), PdfDocumentOpenMode.Modify);
            for (int i = 0; i < pd.AcroForm.Fields.Count; i++)
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
            pd.Save(path + @"\IRF " + _z1 + ".pdf");
        }
    }
}