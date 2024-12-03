namespace BookAPI.Data
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead { get; set; }
        public int? Rate { get; set; }
        public string Genre { get; set; }
        public string CoverPictureURL { get; set; }
        public int PublihserId { get; set; }
        //više autora za istu knjigu
        public List<int> AuthorIds { get; set; }

    }

}
