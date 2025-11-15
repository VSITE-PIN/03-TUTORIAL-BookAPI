namespace BookAPI.Data
{
    public class BookWithAuthorsVM
    {
        public string Title { get; set; }
        public string Description { get; set; }

        // Da li smo pročitali knjigu
        public bool IsRead { get; set; }

        // Datum kada smo ju pročitali (može biti null ako nije pročitana)
        public DateTime? DateRead { get; set; }

        // Ocjena (može biti null ako nije pročitana)
        public int? Rate { get; set; }

        public string Genre { get; set; }
        public string CoverPictureURL { get; set; }

        public string PublisherName { get; set; }
        public List<string> AuthorNames { get; set; }
    }
}
