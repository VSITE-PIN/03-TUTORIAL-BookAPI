using BookAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace BookAPI.Services
{
    public class PublisherService
    {
        private readonly AppDbContext _context;

        public PublisherService(AppDbContext context)
        {
            _context = context;
        }

        // Dodavanje izdavača
        public void AddPublisher(PublisherVM publisher)
        {
            var newPublisher = new Publisher
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(newPublisher);
            _context.SaveChanges();
        }

        // Dohvat svih izdavača
        public List<Publisher> GetAllPublishers()
        {
            return _context.Publishers.ToList();
        }

        // Dohvat izdavača po ID-u
        public Publisher? GetPublisherById(int id)
        {
            return _context.Publishers
                .Include(p => p.Books)
                .FirstOrDefault(p => p.Id == id);
        }

        public void DeletePublisher(int id)
        {
            var publisher = _context.Publishers.FirstOrDefault(x => x.Id == id);

            if (publisher != null)
            {
                _context.Publishers.Remove(publisher);
                _context.SaveChanges();
            }
        }

    }
}
