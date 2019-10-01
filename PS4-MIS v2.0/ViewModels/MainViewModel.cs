using Caliburn.Micro;
using System.Windows.Media;

namespace PS4_MIS_v2._0.ViewModels
{
    internal class MainViewModel : Conductor<object>
    {
        private Brush _criminalRecordsBrush;
        private string _displayName;
        private Brush _employeerecordsBrush;
        private Brush _inventoryBrush;
        private Brush _messagesBrush;
        private Brush _policeReportsBrush;
        private Brush _stolenvehicleBrush;
        private Brush _visitorlogbookbrush;
        private IWindowManager windowManager = new WindowManager();
        public Brush criminalRecordsBrush
        {
            get { return _criminalRecordsBrush; }
            set { _criminalRecordsBrush = value; }
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