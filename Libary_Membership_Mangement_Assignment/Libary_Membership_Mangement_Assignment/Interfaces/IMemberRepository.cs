using Libary_Membership_Mangement_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libary_Membership_Mangement_Assignment.Interfaces
{
    public interface IMemberRepository
    {
        Member? GetMemberById(int memberId);
        void UpdateBorrowedBookCount(int memberId);

    }
}
