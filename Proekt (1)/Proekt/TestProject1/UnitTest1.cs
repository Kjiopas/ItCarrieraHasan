using NUnit.Framework;
using ConsoleApp20.Bussiness;
using ConsoleApp20.Data.Models;
using ConsoleApp20.Data;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp20.Tests
{
    [TestFixture]
    public class BookBussinessTests
    {
        private Contexts _context;
        private BookBussiness _bookBusiness;
        [SetUp]
        public void Setup()
        {
            _context = new Contexts();
            _bookBusiness = new BookBussiness(_context);
        }

        [Test]
        public void GetAllBooks_ShouldReturnAllBooks()
        {
            // Arrange
            var bookBusiness = new BookBussiness(_context);

            // Act
            var result = bookBusiness.GetAllBooks();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(_context.Books.Count(), result.Count);
        }

        


        [Test]
        public void GetBookById_NonExistingId_ShouldReturnNull()
        {
            // Arrange
            var bookBusiness = new BookBussiness(_context);
            int nonExistingId = -1;

            // Act
            var result = bookBusiness.GetBookById(nonExistingId);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void AddNewBook_ShouldAddBook()
        {
            // Arrange
            var bookBusiness = new BookBussiness(_context);
            var newBook = new Books { author = "John Doe", name = "Sample Book", price = 20.99M };

            // Act
            bookBusiness.AddNewBook(newBook);
            var addedBook = _context.Books.Find(newBook.id);

            // Assert
            Assert.IsNotNull(addedBook);
            Assert.AreEqual(newBook.id, addedBook.id);
        }

       

        [Test]
        public void RemoveBook_NonExistingId_ShouldNotRemoveBook()
        {
            // Arrange
            var bookBusiness = new BookBussiness(_context);
            int nonExistingId = -1;

            // Act
            bool result = bookBusiness.RemoveBook(nonExistingId);

            // Assert
            Assert.IsFalse(result);
        }

        

        [Test]
        public void UpdateBook_NonExistingBook_ShouldNotUpdate()
        {
            // Arrange
            var bookBusiness = new BookBussiness(_context);
            int nonExistingId = -1;
            var updatedBook = new Books { id = nonExistingId, author = "Updated Author", name = "Updated Name", price = 15.99M };

            // Act
            bookBusiness.UpdateBook(updatedBook);
            var updatedBookInDb = _context.Books.Find(nonExistingId);

            // Assert
            Assert.IsNull(updatedBookInDb);
        }
    }
}
