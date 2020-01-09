using Caliburn.Micro;
using PS4_MIS_v2._0.Model;
using PS4_MIS_v2._0.ViewModels.Dashboard;
using PS4_MIS_v2._0.ViewModels.Messages;
using PS4_MIS_v2._0.ViewModels.Notifications;
using PS4_MIS_v2._0.ViewModels.SystemLogs;
using System;
using System.Data;
using System.Media;
using System.Windows.Media;
using System.Windows.Threading;

namespace PS4_MIS_v2._0.ViewModels
{
    internal class MainViewModel : Conductor<object>
    {
        private Brush _criminalRecordsBrush;
        private double _criminalrecordsHeight;
        private Brush _dashboardBrush;
        private double _dashboardHeight;
        private string _displayName;
        private Brush _employeerecordsBrush;
        private double _employeerecordsHeight;
        private Brush _inventoryBrush;
        private double _inventoryHeight;
        private Brush _messagesBrush;
        private double _messagesHeight;
        private double _notificationsHeight;
        private string _notificationsText;
        private Brush _policeReportsBrush;
        private double _policereportsHeight;
        private Brush _stolenvehicleBrush;
        private double _stolenvehiclesHeight;
        private Brush _systemlogsBrush;
        private double _systemlogsHeight;
        private Brush _visitorlogbookbrush;
        private double _visitorlogbookHeight;
        private Brush _notificationsBrush;
        private IWindowManager windowManager = new WindowManager();

        public Brush notificationsBrush
        {
            get { return _notificationsBrush; }
            set { notificationsBrush = value; }
        }

        private Brush _notificationsForeground;

        public Brush notificationsForeground
        {
            get 
            {
                DataTable dt = connection.dbTable("Select * from messages where Receiver = " + currentUser.EmployeeID + " AND isAcknowledged = 0");
                if (dt.Rows.Count > 0)
                {
                    return new SolidColorBrush(Colors.Red);
                }
                else
                {
                    return new SolidColorBrush(Colors.White);
                }
            }
            set { _notificationsForeground = value; }
        }


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

        public Brush dashboardBrush
        {
            get { return _dashboardBrush; }
            set { _dashboardBrush = value; }
        }

        public double dashboardHeight
        {
            get { return _dashboardHeight; }
            set { _dashboardHeight = value; }
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

        public string notificationsText
        {
            get
            {
                DataTable dt = connection.dbTable("Select * from messages where Receiver = " + currentUser.EmployeeID + " AND isAcknowledged = 0");
                if (dt.Rows.Count > 0)
                {
                    SystemSounds.Beep.Play();
                    return "Notifications(" + dt.Rows.Count.ToString() + ")";
                }
                else
                {
                    return "Notifications(0)";
                }
            }
            set { _notificationsText = value; }
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

        public Brush systemlogsBrush
        {
            get { return _systemlogsBrush; }
            set { _systemlogsBrush = value; }
        }

        public double systemlogsHeight
        {
            get { return _systemlogsHeight; }
            set { _systemlogsHeight = value; }
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
            _employeerecordsBrush = null;
            _inventoryBrush = null;
            _messagesBrush = null;
            _stolenvehicleBrush = null;
            _visitorlogbookbrush = null;
            _policeReportsBrush = null;
            _dashboardBrush = null;
            _systemlogsBrush = null;
            NotifyOfPropertyChange(null);
        }

        public void criminalRecordsButton()
        {
            ActivateItem(new CriminalRecordsViewModel());
            clearColors();
            _criminalRecordsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => criminalRecordsBrush);
        }

        public void dashboardButton()
        {
            ActivateItem(new DashboardViewModel());
            clearColors();
            _dashboardBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);
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

        public void systemlogsButton()
        {
            ActivateItem(new SystemLogsViewModel());
            clearColors();
            _systemlogsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);
        }

        public void visitorLogbookButton()
        {
            ActivateItem(new VisitorLogbookViewModel());
            clearColors();
            _visitorlogbookbrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(null);//() => visitorlogbookbrush);
        }

        protected override void OnActivate()
        {
            DispatcherTimer dt = new DispatcherTimer();
            dt.Tick += new EventHandler(timer_Tick);
            dt.Interval = new TimeSpan(0, 0, 1); // execute every hour
            dt.Start();
            initializeSidebar();
            base.OnActivate();
        }

        private void initializeSidebar()
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
                    _systemlogsHeight = 0;
                    _dashboardHeight = 0;
                    NotifyOfPropertyChange(null);
                    break;

                case "Jailer":
                    _notificationsHeight = 40;
                    _messagesHeight = 0;
                    _criminalrecordsHeight = 40;
                    _policereportsHeight = 0;
                    _stolenvehiclesHeight = 0;
                    _inventoryHeight = 0;
                    _visitorlogbookHeight = 40;
                    _employeerecordsHeight = 0;
                    _systemlogsHeight = 0;
                    _dashboardHeight = 0;
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
                    _systemlogsHeight = 0;
                    _dashboardHeight = 0;
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
                    _systemlogsHeight = 40;
                    _dashboardHeight = 40;
                    NotifyOfPropertyChange(null);
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            NotifyOfPropertyChange(null);
        }
    }
}