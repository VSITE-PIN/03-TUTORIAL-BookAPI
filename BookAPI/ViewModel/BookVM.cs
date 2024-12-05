
namespace BookAPI.ViewModel
{ 
        public class BookVM
        {
            public string? Title { get; set; }
            public string? Description { get; set; }
            //Da li smo pročitali knjigu
            public bool IsRead { get; set; }

        private DateTime dateRead;

        //datum kada smo ju pročitali (nullable Datetime - ako ju nismo
        //pročitala datum će imati vrijednost null)
        public DateTime GetDateRead()
        {
            return dateRead;
        }

        //datum kada smo ju pročitali (nullable Datetime - ako ju nismo
        //pročitala datum će imati vrijednost null)
        public void SetDateRead(DateTime value)
        {
            dateRead = value;
        }

        //ocjena (nullable int - ako ju nismo pročitali ne možemo ju ocijeniti
        //pa će vrijednost biti null)
        public int? Rate { get; set; }
            public string? Genre { get; set; }
            public string? Author { get; set; }
            public string? CoverPictureURL { get; set; }
            public int PublihserId { get; set; }
            //više autora za istu knjigu 
            public List<int> AuthorIds { get; set; }
        public IEnumerable<object> BookAuthors { get; internal set; }
    }
}
