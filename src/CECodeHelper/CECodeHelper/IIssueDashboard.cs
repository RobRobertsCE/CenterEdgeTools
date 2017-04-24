using System;
using System.Windows.Forms;

namespace CECodeHelper
{
    public interface IIssueDashboard
    {
        void DisplayMessage(string message);
        void ExceptionHandler(Exception ex);
        void DisplayAccountsDialog();
        void DisplayDbVersionDialog();
    }
}