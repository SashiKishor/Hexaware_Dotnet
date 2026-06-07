using System;
using System.Collections.Generic;
using System.Text;
using Libary_Membership_Mangement_Assignment.Interfaces;

namespace Libary_Membership_Mangement_Assignment.Services
{
    public class LibraryService
    {
        private IBookRepository _bookRepository;
        private IMemberRepository _memberRepository;
        private INotificationService _notificationService;

        public LibraryService(IBookRepository bookRepo, IMemberRepository memberRepo, INotificationService notificationService)
        {
            _bookRepository = bookRepo;
            _memberRepository = memberRepo;
            _notificationService = notificationService;
        }

        public string BorrowBook(int memberId, int bookId)
        {

            if(memberId <= 0)
            {
                throw new ArgumentException("Invalid member id");
            }
            if (bookId <= 0)
            {
                throw new ArgumentException("Invalid book id");
            }

            var member = _memberRepository.GetMemberById(memberId);
            var book=_bookRepository.GetBookById(bookId);
            int bookBorrowLimit = 3;
            
           
            if (member == null)
            {
                throw new ArgumentException ("Member does not exist");
            }
            if (!member.IsActive)
            {
                throw new ArgumentException("Member is inactive");
            }
            if (member.IsPremiumMember)
            {
                bookBorrowLimit = 5;
            }
            if (book == null)
            {
                throw new ArgumentException("Book does not exist");
            }
            if (!book.IsAvailable)
            {
                throw new ArgumentException("Book is not available");
            }
            if (member.BorrowedBookCount >= bookBorrowLimit)
            {
                throw new ArgumentException($"Borrowing limit reached");
            }

            _bookRepository.MarkBookAsBorrowed(bookId);
            _memberRepository.UpdateBorrowedBookCount(memberId);
            _notificationService.SendBorrowNotification(member.Email, book.BookTitle);
            return "Book borrowed successfully";
        }


    }
}
