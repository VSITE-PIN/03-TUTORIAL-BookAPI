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

        // 1. Dodavanje knjige
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
                DateAdded = DateTime.Now
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();
        }

        // 2. Dohvat svih knjiga
        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        // 3. Dohvat jedne knjige po ID-u
        public Book? GetBookById(int id)
        {
            return _context.Books.FirstOrDefault(x => x.Id == id);
        }

        // 4. Ažuriranje knjige
        public Book? UpdateBookById(int id, BookVM bookVM)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book != null)
            {
                book.Title = bookVM.Title;
                book.Description = bookVM.Description;
                book.IsRead = bookVM.IsRead;
                book.DateRead = bookVM.IsRead ? bookVM.DateRead : null;
                book.Rate = bookVM.IsRead ? bookVM.Rate : null;
                book.Genre = bookVM.Genre;
                book.Author = bookVM.Author;
                book.CoverPictureURL = bookVM.CoverPictureURL;

                _context.SaveChanges();
            }

            return book;
        }

        // 5. Brisanje knjige
        public void DeleteBook(int id)
        {
            var book = _context.Books.FirstOrDefault(x => x.Id == id);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
