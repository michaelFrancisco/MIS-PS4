using Caliburn.Micro;
using PS4_MIS_v2._0.Model;
using System.Data;

namespace PS4_MIS_v2._0.ViewModels.Notifications
{
    internal class ShowNotificationViewModel : Screen
    {
        private string _body;
        private string _selectedMessageID;

        private string _subject;

        public ShowNotificationViewModel(string selectedMessageID)
        {
            _selectedMessageID = selectedMessageID;
        }
        public string body
        {
            get { return _body; }
            set { _body = value; }
        }

        public string subject
        {
            get { return _subject; }
            set { _subject = value; }
        }
        public void ok()
        {
            connection.dbCommand("UPDATE `ps4`.`messages` SET `isAcknowledged` = '1' WHERE (`Message_ID` = '" + _selectedMessageID + "');");
            connection.dbCommand("INSERT INTO `ps4`.`system_log` (`Type`,`Item_ID`, `User`, `Action`) VALUES('Message','" + _selectedMessageID + "', '" + currentUser.EmployeeID + "', 'Acknowledged Message " + _selectedMessageID + "')");
            TryClose();
        }

        protected override void OnActivate()
        {
            DataTable dt = connection.dbTable("select Subject, Body from messages where Message_ID = " + _selectedMessageID + ";");
            _subject = dt.Rows[0][0].ToString();
            _body = dt.Rows[0][1].ToString();
            NotifyOfPropertyChange(null);
            base.OnActivate();
        }
    }
}