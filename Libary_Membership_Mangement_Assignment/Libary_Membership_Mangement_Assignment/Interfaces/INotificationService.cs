using System;
using System.Collections.Generic;
using System.Text;

namespace Libary_Membership_Mangement_Assignment.Interfaces
{
    public interface INotificationService
    {
        void SendBorrowNotification(string email, string bookTitle);
    }
}
