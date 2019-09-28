using Caliburn.Micro;
using PS4_MIS_v2._0.ViewModels.EmployeeRecords;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_MIS_v2._0.ViewModels
{
    class EmployeeRecordsViewModel
    {
        IWindowManager windowManager = new WindowManager();
        public void addEmployeeRecordButton()
        {
            windowManager.ShowWindow(new AddEmployeeRecordViewModel(), null, null);
        }
    }
}
