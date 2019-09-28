using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PS4_MIS_v2._0.ViewModels.CriminalRecords;

namespace PS4_MIS_v2._0.ViewModels
{
    class CriminalRecordsViewModel
    {
        IWindowManager windowManager = new WindowManager();

        public void addCriminalRecordButton()
        {
            windowManager.ShowWindow(new AddCriminalRecordViewModel(), null, null);
        }


    }
}