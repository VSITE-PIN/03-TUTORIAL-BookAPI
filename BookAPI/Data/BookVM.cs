namespace BookAPI.Data
{
    public class BookVM
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsRead { get; set; }
        public DateTime? DateRead {  get; set; }
        public int? Rate { get; set; }
        public required string Genre { get; set; }
        public required string CoverPictureURL { get; set; }
        public int PublihserId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
