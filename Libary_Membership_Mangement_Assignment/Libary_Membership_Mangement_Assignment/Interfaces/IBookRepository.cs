using Libary_Membership_Mangement_Assignment.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libary_Membership_Mangement_Assignment.Interfaces
{
    public interface IBookRepository
    {
        Book? GetBookById(int id);
        void MarkBookAsBorrowed(int id);
    }
}
