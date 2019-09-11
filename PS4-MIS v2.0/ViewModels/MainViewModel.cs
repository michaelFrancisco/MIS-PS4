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
        public void loadCriminalRecords()
        {
            ActivateItem(new CriminalRecordsViewModel());
        }
    }
}
