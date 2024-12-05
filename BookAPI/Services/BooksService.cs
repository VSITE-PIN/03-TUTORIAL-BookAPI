
using System.Collections.Generic;
using System.Linq;
using BookAPI.Data;

namespace BookAPI.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        public void AddBook(BookVM book)
        {
            var newBook = new Book
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                Author = book.Author,
                CoverPictureURL = book.CoverPictureURL,
                DateAdded = System.DateTime.Now
            };
            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(b => b.Id == id);
        }

        public Book UpdateBookById(int id, BookVM book)
        {
            var existingBook = _context.Books.FirstOrDefault(b => b.Id == id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Description = book.Description;
                existingBook.IsRead = book.IsRead;
                existingBook.DateRead = book.IsRead ? book.DateRead : null;
                existingBook.Rate = book.IsRead ? book.Rate : null;
                existingBook.Genre = book.Genre;
                existingBook.Author = book.Author;
                existingBook.CoverPictureURL = book.CoverPictureURL;
                _context.SaveChanges();
            }
            return existingBook;
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
