using Caliburn.Micro;
using PS4_MIS_v2._0.Model;
using PS4_MIS_v2._0.ViewModels.Messages;
using PS4_MIS_v2._0.ViewModels.Notifications;
using System.Data;
using System.Windows.Media;

namespace PS4_MIS_v2._0.ViewModels
{
    internal class MainViewModel : Conductor<object>
    {
        private Brush _criminalRecordsBrush;
        private double _criminalrecordsHeight;
        private string _displayName;
        private Brush _employeerecordsBrush;
        private double _employeerecordsHeight;
        private Brush _inventoryBrush;
        private double _inventoryHeight;
        private Brush _messagesBrush;
        private double _messagesHeight;
        private double _notificationsHeight;
        private Brush _policeReportsBrush;
        private double _policereportsHeight;
        private Brush _stolenvehicleBrush;
        private double _stolenvehiclesHeight;
        private Brush _visitorlogbookbrush;
        private double _visitorlogbookHeight;
        private Brush notificationsBrush;
        private IWindowManager windowManager = new WindowManager();
        public Brush criminalRecordsBrush
        {
            get { return _criminalRecordsBrush; }
            set { _criminalRecordsBrush = value; }
        }


        public double criminalrecordsHeight
        {
            get { return _criminalrecordsHeight; }
            set { _criminalrecordsHeight = value; }
        }

        public string displayName
        {
            get { return _displayName; }
            set { _displayName = value; }
        }

        public Brush employeerecordsBrush
        {
            get { return _employeerecordsBrush; }
            set { _employeerecordsBrush = value; }
        }

        public double employeerecordsHeight
        {
            get { return _employeerecordsHeight; }
            set { _employeerecordsHeight = value; }
        }

        public Brush inventoryBrush
        {
            get { return _inventoryBrush; }
            set { _inventoryBrush = value; }
        }

        public double inventoryHeight
        {
            get { return _inventoryHeight; }
            set { _inventoryHeight = value; }
        }

        public Brush messagesBrush
        {
            get { return _messagesBrush; }
            set { _messagesBrush = value; }
        }

        public double messagesHeight
        {
            get { return _messagesHeight; }
            set { _messagesHeight = value; }
        }

        public double notificationsHeight
        {
            get { return _notificationsHeight; }
            set { _notificationsHeight = value; }
        }

        public Brush _notificationsBrush
        {
            get { return notificationsBrush; }
            set { notificationsBrush = value; }
        }
        public Brush policeReportsBrush
        {
            get { return _policeReportsBrush; }
            set { _policeReportsBrush = value; }
        }

        public double policereportsHeight
        {
            get { return _policereportsHeight; }
            set { _policereportsHeight = value; }
        }

        public Brush stolenvehicleBrush
        {
            get { return _stolenvehicleBrush; }
            set { _stolenvehicleBrush = value; }
        }

        public double stolenvehiclesHeight
        {
            get { return _stolenvehiclesHeight; }
            set { _stolenvehiclesHeight = value; }
        }

        public Brush visitorlogbookbrush
        {
            get { return _visitorlogbookbrush; }
            set { _visitorlogbookbrush = value; }
        }

        public double visitorlogbookHeight
        {
            get { return _visitorlogbookHeight; }
            set { _visitorlogbookHeight = value; }
        }

        public void clearColors()
        {
            _criminalRecordsBrush = null;
            NotifyOfPropertyChange(null);//() => criminalRecordsBrush);
            _employeerecordsBrush = null;
            NotifyOfPropertyChange(null);//() => employeerecordsBrush);
            _inventoryBrush = null;
            NotifyOfPropertyChange(null);//() => inventoryBrush);
            _messagesBrush = null;
            NotifyOfPropertyChange(null);//() => messagesBrush);
            _stolenvehicleBrush = null;
            NotifyOfPropertyChange(null);//() => stolenvehicleBrush);
            _visitorlogbookbrush = null;
            NotifyOfPropertyChange(null);//() => visitorlogbookbrush);
            _policeReportsBrush = null;
            NotifyOfPropertyChange(null);//() => policeReportsBrush);
        }

        public void criminalRecordsButton()
        {
            ActivateItem(new CriminalRecordsViewModel());
            clearColors();
            _criminalRecordsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => criminalRecordsBrush);
        }

        public void employeeRecordsButton()
        {
            ActivateItem(new EmployeeRecordsViewModel());
            clearColors();
            _employeerecordsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => employeerecordsBrush);
        }

        public void inventoryButton()
        {
            ActivateItem(new InventoryViewModel());
            clearColors();
            _inventoryBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => inventoryBrush);
        }

        public void logoutButton()
        {
            windowManager.ShowWindow(new LoginViewModel(), null, null);
            TryClose();
        }

        public void messagesButton()
        {
            ActivateItem(new MessagesViewModel());
            clearColors();
            _messagesBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => messagesBrush);
        }

        public void notificationsButton()
        {
            ActivateItem(new NotificationsViewModel());
            clearColors();
            _notificationsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => notificationsBrush);
        }

        public void policeReportsButton()
        {
            ActivateItem(new PoliceReportsViewModel());
            clearColors();
            _policeReportsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => policeReportsBrush);
        }

        public void stolenVehiclesButton()
        {
            ActivateItem(new StolenVehiclesViewModel());
            clearColors();
            _stolenvehicleBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => stolenvehicleBrush);
        }

        public void visitorLogbookButton()
        {
            clearColors();
            _visitorlogbookbrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => visitorlogbookbrush);
        }

        private string _notificationsText;

        public string notificationsText
        {
            get
            {
                DataTable dt = connection.dbTable("Select * from messages where Receiver = " + currentUser.EmployeeID + " AND isAcknowledged = 0");
                return "Notifications(" + dt.Rows.Count.ToString() + ")";
            }
            set { _notificationsText = value; }
        }


        protected override void OnActivate()
        {
            _displayName = currentUser.Rank + " " + currentUser.Firstname + " " + currentUser.Lastname;
            NotifyOfPropertyChange(null);//() => displayName);
            switch (currentUser.UserLevel)
            {
                case "Inventory":
                    _notificationsHeight = 40;
                    _messagesHeight = 0;
                    _criminalrecordsHeight = 0;
                    _policereportsHeight = 0;
                    _stolenvehiclesHeight = 0;
                    _inventoryHeight = 40;
                    _visitorlogbookHeight = 0;
                    _employeerecordsHeight = 0;
                    NotifyOfPropertyChange(null);
                    break;
                case "Jailer":
                    _notificationsHeight = 40;
                    _messagesHeight = 0;
                    _criminalrecordsHeight = 0;
                    _policereportsHeight = 0;
                    _stolenvehiclesHeight = 0;
                    _inventoryHeight = 0;
                    _visitorlogbookHeight = 40;
                    _employeerecordsHeight = 0;
                    NotifyOfPropertyChange(null);
                    break;
                case "Desk Officer":
                    _notificationsHeight = 40;
                    _messagesHeight = 0;
                    _criminalrecordsHeight = 40;
                    _policereportsHeight = 40;
                    _stolenvehiclesHeight = 40;
                    _inventoryHeight = 0;
                    _visitorlogbookHeight = 0;
                    _employeerecordsHeight = 0;
                    NotifyOfPropertyChange(null);
                    break;
                case "Administrator":
                    _notificationsHeight = 40;
                    _messagesHeight = 40;
                    _criminalrecordsHeight = 40;
                    _policereportsHeight = 40;
                    _stolenvehiclesHeight = 40;
                    _inventoryHeight = 40;
                    _visitorlogbookHeight = 40;
                    _employeerecordsHeight = 40;
                    NotifyOfPropertyChange(null);
                    break;
            }
            base.OnActivate();
        }
    }
}