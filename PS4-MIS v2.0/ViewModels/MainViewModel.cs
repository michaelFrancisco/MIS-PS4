using Caliburn.Micro;
using PS4_MIS_v2._0.ViewModels.Blotter;
using PS4_MIS_v2._0.ViewModels.Bookings;
using System.Windows.Media;

namespace PS4_MIS_v2._0.ViewModels
{
    internal class MainViewModel : Conductor<object>
    {
        private Brush _blotterBrush;
        private Brush _bookingsBrush;
        private Brush _criminalRecordsBrush;
        private Brush _employeerecordsBrush;
        private Brush _inventoryBrush;
        private Brush _messagesBrush;
        private Brush _payrollBrush;
        private Brush _policeReportsBrush;
        private Brush _stolenvehicleBrush;
        private Brush _visitorlogbookbrush;
        private IWindowManager windowManager = new WindowManager();

        public Brush blotterBrush
        {
            get { return _blotterBrush; }
            set { _blotterBrush = value; }
        }

        public Brush bookingsBrush
        {
            get { return _bookingsBrush; }
            set { _bookingsBrush = value; }
        }

        public Brush criminalRecordsBrush
        {
            get { return _criminalRecordsBrush; }
            set { _criminalRecordsBrush = value; }
        }

        public Brush employeerecordsBrush
        {
            get { return _employeerecordsBrush; }
            set { _employeerecordsBrush = value; }
        }

        public Brush inventoryBrush
        {
            get { return _inventoryBrush; }
            set { _inventoryBrush = value; }
        }

        public Brush messagesBrush
        {
            get { return _messagesBrush; }
            set { _messagesBrush = value; }
        }

        public Brush payrollBrush
        {
            get { return _payrollBrush; }
            set { _payrollBrush = value; }
        }

        public Brush policeReportsBrush
        {
            get { return _policeReportsBrush; }
            set { _policeReportsBrush = value; }
        }
        public Brush stolenvehicleBrush
        {
            get { return _stolenvehicleBrush; }
            set { _stolenvehicleBrush = value; }
        }
        public Brush visitorlogbookbrush
        {
            get { return _visitorlogbookbrush; }
            set { _visitorlogbookbrush = value; }
        }

        public void blotterButton()
        {
            ActivateItem(new BlotterViewModel());
            clearColors();
            _blotterBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => blotterBrush);
        }

        public void bookingsButton()
        {
            ActivateItem(new BookingsViewModel());
            clearColors();
            _bookingsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => bookingsBrush);
        }
        public void clearColors()
        {
            _criminalRecordsBrush = null;
            NotifyOfPropertyChange(() => criminalRecordsBrush);
            _employeerecordsBrush = null;
            NotifyOfPropertyChange(() => employeerecordsBrush);
            _inventoryBrush = null;
            NotifyOfPropertyChange(() => inventoryBrush);
            _messagesBrush = null;
            NotifyOfPropertyChange(() => messagesBrush);
            _payrollBrush = null;
            NotifyOfPropertyChange(() => payrollBrush);
            _stolenvehicleBrush = null;
            NotifyOfPropertyChange(() => stolenvehicleBrush);
            _visitorlogbookbrush = null;
            NotifyOfPropertyChange(() => visitorlogbookbrush);
            _policeReportsBrush = null;
            NotifyOfPropertyChange(() => policeReportsBrush);
        }

        public void criminalRecordsButton()
        {
            ActivateItem(new CriminalRecordsViewModel());
            clearColors();
            _criminalRecordsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => criminalRecordsBrush);
        }

        public void employeeRecordsButton()
        {
            ActivateItem(new EmployeeRecordsViewModel());
            clearColors();
            _employeerecordsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => employeerecordsBrush);
        }

        public void inventoryButton()
        {
            ActivateItem(new InventoryViewModel());
            clearColors();
            _inventoryBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => inventoryBrush);
        }

        public void logoutButton()
        {
            windowManager.ShowWindow(new LoginViewModel(), null, null);
            TryClose();
        }

        public void messagesButton()
        {
            clearColors();
            _messagesBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => messagesBrush);
        }

        public void payrollButton()
        {
            ActivateItem(new PayrollViewModel());
            clearColors();
            _payrollBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => payrollBrush);
        }

        public void policeReportsButton()
        {
            ActivateItem(new PoliceReportsViewModel());
            clearColors();
            _policeReportsBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => policeReportsBrush);
        }

        public void stolenVehiclesButton()
        {
            ActivateItem(new StolenVehiclesViewModel());
            clearColors();
            _stolenvehicleBrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => stolenvehicleBrush);
        }

        public void visitorLogbookButton()
        {
            clearColors();
            _visitorlogbookbrush = new SolidColorBrush(Colors.DarkBlue);
            NotifyOfPropertyChange(() => visitorlogbookbrush);
        }
    }
}