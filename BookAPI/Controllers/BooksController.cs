﻿using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    public class BooksController : Controller
    {
        public class BookVM
        {
            public string Title { get; set; }
            public string Description { get; set; }
            //Da li smo pročitali knjigu
            public bool IsRead { get; set; }
            //datum kada smo ju pročitali (nullable Datetime - ako ju nismo 
            //pročitala datum će imati vrijednost null)
            public DateTime? DateRead { get; set; }
            public int? Rate { get; set; }
            public string Genre { get; set; }
            public string Author { get; set; }
            public string CoverPictureURL { get; set; }
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
