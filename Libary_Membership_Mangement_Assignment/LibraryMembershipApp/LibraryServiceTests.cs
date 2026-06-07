using Libary_Membership_Mangement_Assignment.Interfaces;
using Libary_Membership_Mangement_Assignment.Services;
using Libary_Membership_Mangement_Assignment.Models;
using Moq;

namespace LibraryMembershipApp
{
    [TestFixture]
    public class LibraryServiceTests
    {

        private Mock<IBookRepository> _bookRepository;
        private Mock<IMemberRepository> _memberRepository;
        private Mock<INotificationService> _notificationService;
        private LibraryService _service;


        [SetUp]
        public void Setup()
        {
            _bookRepository = new Mock<IBookRepository>();
            _memberRepository = new Mock<IMemberRepository>();
            _notificationService = new Mock<INotificationService>();
            _service = new LibraryService(_bookRepository.Object, _memberRepository.Object, _notificationService.Object);
        }

        [Test]
        public void BorrowBook_WhenAllConditionsAreValid_ShouldReturnSuccessMessage()
        {
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book {BookId=1,BookTitle="One Piece",AuthorName="echiro oda" });
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member {MemberID=1,MemberName="Sashi",BorrowedBookCount=1,Email="sashi@gmail.com"});

            var validSetup = _service.BorrowBook(1, 1);

            Assert.That(validSetup, Is.EqualTo("Book borrowed successfully"));
            _bookRepository.Verify(a => a.GetBookById(1), Times.Once());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Once());
            _bookRepository.Verify(a=>a.MarkBookAsBorrowed(1),Times.Once());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Once());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Once());
        }

        [Test]
        public void BorrowBook_WhenMemberDoesNotExist_ShouldReturnMemberNotFound()
        {
            
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns((Member)null);
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book { BookId = 1, BookTitle = "One Piece", AuthorName = "echiro oda" });

            var expectedException =Assert.Throws<ArgumentException>(()=>_service.BorrowBook(1,1));

            Assert.That(expectedException.Message, Is.EqualTo("Member does not exist"));
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Once());
            _bookRepository.Verify(a => a.GetBookById(1), Times.Once());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Never());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Never());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Never());
        }

        [Test]
        public void BorrowBook_WhenMemberIsInactive_ShouldReturnMemberIsNotActive()
        {
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book { BookId = 1, BookTitle = "One Piece", AuthorName = "echiro oda" });
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member { MemberID = 1, MemberName = "Sashi", BorrowedBookCount = 1, Email = "sashi@gmail.com",IsActive=false });

            var expectedException = Assert.Throws<ArgumentException>(() => _service.BorrowBook(1, 1));
            Assert.That(expectedException.Message, Is.EqualTo("Member is inactive"));
            _bookRepository.Verify(a => a.GetBookById(1), Times.Once());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Once());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Never());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Never());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Never());
        }

        [Test]
        public void BorrowBook_WhenBookDoesNotExist_ShouldReturnBookNotFound()
        {
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member { MemberID = 1, MemberName = "Sashi", BorrowedBookCount = 1, Email = "sashi@gmail.com" });

            var expectedException = Assert.Throws<ArgumentException>(() => _service.BorrowBook(1, 1));
            Assert.That(expectedException.Message, Is.EqualTo("Book does not exist"));
            _bookRepository.Verify(a => a.GetBookById(1), Times.Once());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Once());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Never());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Never());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Never());
        }

        [Test]
        public void BorrowBook_WhenBookIsNotAvailable_ShouldReturnBookIsNotAvailable()
        {
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book { BookId = 1, BookTitle = "One Piece", AuthorName = "echiro oda" ,IsAvailable=false});
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member { MemberID = 1, MemberName = "Sashi", BorrowedBookCount = 1, Email = "sashi@gmail.com" });

            var expectedException = Assert.Throws<ArgumentException>(() => _service.BorrowBook(1, 1));
            Assert.That(expectedException.Message, Is.EqualTo("Book is not available"));
            _bookRepository.Verify(a => a.GetBookById(1), Times.Once());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Once());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Never());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Never());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Never());
        }

        [Test]
        public void BorrowBook_WhenBorrowingLimitReached_ShouldReturnBorrowingLimitReached()
        {
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book { BookId = 1, BookTitle = "One Piece", AuthorName = "echiro oda" });
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member { MemberID = 1, MemberName = "Sashi", BorrowedBookCount = 3, Email = "sashi@gmail.com" });

            var expectedException = Assert.Throws<ArgumentException>(() => _service.BorrowBook(1, 1));
            Assert.That(expectedException.Message, Is.EqualTo("Borrowing limit reached"));
            _bookRepository.Verify(a => a.GetBookById(1), Times.Once());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Once());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Never());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Never());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Never());
        }

        [Test]
        public void BorrowBook_WhenMemberIdIsInvalid_ShouldReturnInvalidMemberId()
        {
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book { BookId = 1, BookTitle = "One Piece", AuthorName = "echiro oda" });
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member { MemberID = 1, MemberName = "Sashi", BorrowedBookCount = 3, Email = "sashi@gmail.com" });

            var expectedException = Assert.Throws<ArgumentException>(() => _service.BorrowBook(0, 1));
            Assert.That(expectedException.Message, Is.EqualTo("Invalid member id"));
            _bookRepository.Verify(a => a.GetBookById(1), Times.Never());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Never());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Never());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Never());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Never());
        }


        [Test]
        public void BorrowBook_WhenBookIdIsInvalid_ShouldReturnInvalidBookId()
        {
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book { BookId = 1, BookTitle = "One Piece", AuthorName = "echiro oda" });
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member { MemberID = 1, MemberName = "Sashi", BorrowedBookCount = 3, Email = "sashi@gmail.com" });

            var expectedException = Assert.Throws<ArgumentException>(() => _service.BorrowBook(1, 0));
            Assert.That(expectedException.Message, Is.EqualTo("Invalid book id"));
            _bookRepository.Verify(a => a.GetBookById(1), Times.Never());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Never());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Never());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Never());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Never());
        }

        [Test]
        public void BorrowBook_WhenNormalMemberHasThreeBooks_ShouldReturnBorrowingLimitReached()
        {
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book { BookId = 1, BookTitle = "One Piece", AuthorName = "echiro oda" });
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member { MemberID = 1, MemberName = "Sashi", BorrowedBookCount = 3, Email = "sashi@gmail.com" });

            var expectedException = Assert.Throws<ArgumentException>(() => _service.BorrowBook(1, 1));
            Assert.That(expectedException.Message, Is.EqualTo("Borrowing limit reached"));
            _bookRepository.Verify(a => a.GetBookById(1), Times.Once());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Once());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Never());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Never());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Never());
        }

        [Test]
        public void BorrowBook_WhenPremiumMemberHasThreeBooks_ShouldAllowBorrowing()
        {
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book { BookId = 1, BookTitle = "One Piece", AuthorName = "echiro oda" });
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member { MemberID = 1, MemberName = "Sashi", BorrowedBookCount = 3, Email = "sashi@gmail.com",IsPremiumMember=true });

            var validSetup = _service.BorrowBook(1, 1);

            Assert.That(validSetup, Is.EqualTo("Book borrowed successfully"));

            _bookRepository.Verify(a => a.GetBookById(1), Times.Once());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Once());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Once());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Once());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Once());
        }

        public void BorrowBook_WhenPremiumMemberHasFiveBooks_ShouldReturnBorrowingLimitReached()
        {
            _bookRepository.Setup(a => a.GetBookById(1)).Returns(new Book { BookId = 1, BookTitle = "One Piece", AuthorName = "echiro oda" });
            _memberRepository.Setup(a => a.GetMemberById(1)).Returns(new Member { MemberID = 1, MemberName = "Sashi", BorrowedBookCount = 5, Email = "sashi@gmail.com" ,IsPremiumMember=true});

            var expectedException = Assert.Throws<ArgumentException>(() => _service.BorrowBook(1, 1));
            Assert.That(expectedException.Message, Is.EqualTo("Borrowing limit reached"));
            _bookRepository.Verify(a => a.GetBookById(1), Times.Once());
            _memberRepository.Verify(a => a.GetMemberById(1), Times.Once());
            _bookRepository.Verify(a => a.MarkBookAsBorrowed(1), Times.Never());
            _memberRepository.Verify(a => a.UpdateBorrowedBookCount(1), Times.Never());
            _notificationService.Verify(a => a.SendBorrowNotification("sashi@gmail.com", "One Piece"), Times.Never());
        }





    }
}
