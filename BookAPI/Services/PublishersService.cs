﻿using BookAPI.Data;
using BookAPI.ViewModel;

namespace BookAPI.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var newPublisher = new Publisher()
            {
                Name = publisher.Name
            };
            _context.Publishers.Add(newPublisher);
            _context.SaveChanges();
        }


    }
}
