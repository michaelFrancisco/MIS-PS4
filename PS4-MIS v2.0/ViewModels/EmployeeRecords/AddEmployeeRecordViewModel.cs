using Caliburn.Micro;
using PS4_MIS_v2._0.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace PS4_MIS_v2._0.ViewModels.EmployeeRecords
{
    class AddEmployeeRecordViewModel : Conductor<object>
    {
        IWindowManager windowManager = new WindowManager();
        public void cancelButton()
        {
            TryClose();
        }
    }
}
