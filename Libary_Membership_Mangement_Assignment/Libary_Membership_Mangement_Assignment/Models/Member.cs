using System;
using System.Collections.Generic;
using System.Text;

namespace Libary_Membership_Mangement_Assignment.Models
{
    public class Member
    {
        public int MemberID { get; set; }
        public string MemberName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = true;
        public int BorrowedBookCount { get; set; }

        public bool IsPremiumMember { get; set; }=false;

    }
}
