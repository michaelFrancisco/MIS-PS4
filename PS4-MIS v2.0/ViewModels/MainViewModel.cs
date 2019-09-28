using Caliburn.Micro;
using PS4_MIS_v2._0.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PS4_MIS_v2._0.ViewModels
{
    class MainViewModel : Conductor<object>
    {
        IWindowManager windowManager = new WindowManager();

        public void criminalRecordsButton()
        {
            ActivateItem(new CriminalRecordsViewModel());
        }

        public void employeeRecordsButton()
        {
            ActivateItem(new EmployeeRecordsViewModel());            
        }

        public void wantedPeopleButton()
        {
            ActivateItem(new MostWantedViewModel());
        }

        public void policeReportsButton()
        {
            ActivateItem(new PoliceReportsViewModel());
        }

        public void stolenVehiclesButton()
        {
            ActivateItem(new StolenVehiclesViewModel());
        }

        public void inventoryButton()
        {
            ActivateItem(new InventoryViewModel());
        }

        public void payrollButton()
        {
            ActivateItem(new PayrollViewModel());
        }

        public void logoutButton()
        { 
                windowManager.ShowWindow(new LoginViewModel(), null, null);
                TryClose();
        }

    }
}
