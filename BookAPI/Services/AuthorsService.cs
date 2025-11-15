using BookAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services
{
    public class AuthorsService
    {
        private readonly AppDbContext _context;

        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        // Add Author
        public void AddAuthor(AuthorVM author)
        {
            var _author = new Author()
            {
                FullName = author.FullName
            };

            _context.Authors.Add(_author);
            _context.SaveChanges();
        }

        // Get all authors
        public List<Author> GetAllAuthors()
        {
            return _context.Authors.ToList();
        }

        // Get author by id
        public Author GetAuthorById(int id)
        {
            return _context.Authors
                .Include(a => a.BookAuthors)
                .ThenInclude(ba => ba.Book)
                .FirstOrDefault(a => a.Id == id);
        }

        public AuthorWithBooksVM? GetAuthorWithBooks(int id)
        {
            var author = _context.Authors
                .Where(n => n.Id == id)
                .Select(n => new AuthorWithBooksVM
                {
                    FullName = n.FullName,
                    Books = n.BookAuthors
                        .Select(ba => ba.Book.Title)
                        .ToList()
                })
                .FirstOrDefault();

            return author;
        }

    }
}
