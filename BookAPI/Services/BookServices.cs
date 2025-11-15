using BookAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services
{
    public class BooksService
    {
        private readonly AppDbContext _context;

        public BooksService(AppDbContext context)
        {
            _context = context;
        }

        // GET all books (može i dalje vraćati pune Book objekte)
        public List<Book> GetAllBooks()
        {
            return _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthors)
                    .ThenInclude(ba => ba.Author)
                .ToList();
        }

        // GET single book WITH authors and publisher name
        public BookWithAuthorsVM? GetBookById(int id)
        {
            var book = _context.Books
                .Where(n => n.Id == id)
                .Select(book => new BookWithAuthorsVM
                {
                    Title = book.Title,
                    Description = book.Description,
                    IsRead = book.IsRead,
                    DateRead = book.IsRead ? book.DateRead : null,
                    Rate = book.IsRead ? book.Rate : null,
                    Genre = book.Genre,
                    CoverPictureURL = book.CoverPictureURL,
                    PublisherName = book.Publisher.Name,
                    AuthorNames = book.BookAuthors
                        .Select(x => x.Author.FullName)
                        .ToList()
                })
                .FirstOrDefault();

            return book;
        }

        // ADD book
        public void AddBook(BookVM book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead ? book.DateRead : null,
                Rate = book.IsRead ? book.Rate : null,
                Genre = book.Genre,
                CoverPictureURL = book.CoverPictureURL,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();

            // nakon što smo dodali knjigu, punimo veznu tablicu BookAuthor
            if (book.AuthorIds != null && book.AuthorIds.Any())
            {
                foreach (var id in book.AuthorIds)
                {
                    var bookAuthor = new BookAuthor()
                    {
                        BookId = newBook.Id,
                        AuthorId = id
                    };

                    _context.BookAuthors.Add(bookAuthor);
                }

                _context.SaveChanges();
            }
        }

        // UPDATE book by id
        public void UpdateBookById(int id, BookVM book)
        {
            var existingBook = _context.Books
                .Include(b => b.BookAuthors)
                .FirstOrDefault(b => b.Id == id);

            if (existingBook == null)
            {
                return;
            }

            existingBook.Title = book.Title;
            existingBook.Description = book.Description;
            existingBook.IsRead = book.IsRead;
            existingBook.DateRead = book.IsRead ? book.DateRead : null;
            existingBook.Rate = book.IsRead ? book.Rate : null;
            existingBook.Genre = book.Genre;
            existingBook.CoverPictureURL = book.CoverPictureURL;
            existingBook.PublisherId = book.PublisherId;

            // osvježi autore: obriši stare veze, dodaj nove
            _context.BookAuthors.RemoveRange(existingBook.BookAuthors ?? new List<BookAuthor>());

            if (book.AuthorIds != null && book.AuthorIds.Any())
            {
                existingBook.BookAuthors = book.AuthorIds
                    .Select(aid => new BookAuthor
                    {
                        BookId = existingBook.Id,
                        AuthorId = aid
                    })
                    .ToList();
            }

            _context.SaveChanges();
        }

        // DELETE book
        public void DeleteBookById(int id)
        {
            var book = _context.Books.FirstOrDefault(b => b.Id == id);

            if (book == null) return;

            _context.Books.Remove(book);
            _context.SaveChanges();
        }
    }
}
