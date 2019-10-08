using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_MIS_v2._0.ViewModels.PoliceReports
{
    class EditIRFViewModel
    {
        private string _selectedIRFID;
        public EditIRFViewModel(string selectedIRFID)
        {
            _selectedIRFID = selectedIRFID;
        }
    }
}
