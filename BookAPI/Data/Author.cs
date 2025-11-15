namespace BookAPI.Data
{
    public class Author
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        // relacija M:N – autor može imati više knjiga
        public List<BookAuthor> BookAuthors { get; set; }
    }
}
