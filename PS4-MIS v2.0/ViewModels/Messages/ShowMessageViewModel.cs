using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PS4_MIS_v2._0.ViewModels.Messages
{
    class ShowMessageViewModel : Screen
    {
        string _selectedMessageID;
        public ShowMessageViewModel(string selectedMessageID)
        {
            _selectedMessageID = selectedMessageID;
        }

        private string _subject;

        public string subject
        {
            get { return _subject; }
            set { _subject = value; }
        }

        private string _body;

        public string body
        {
            get { return _body; }
            set { _body = value; }
        }


        protected override void OnActivate()
        {
            DataTable dt = connection.dbTable("select Subject, Body from messages where Message_ID = " + _selectedMessageID + ";");
            _subject = dt.Rows[0][0].ToString();
            _body = dt.Rows[0][1].ToString();
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }

        public void ok()
        {
            TryClose();
        }
    }
}
