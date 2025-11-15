namespace BookAPI.Data
{
    public class BookVM
    {
        public string Title { get; set; }
        public string Description { get; set; }

        // Je li knjiga pročitana
        public bool IsRead { get; set; }

        // Datum čitanja (samo ako je pročitana)
        public DateTime? DateRead { get; set; }

        // Ocjena (1–5), ali samo ako je knjiga pročitana
        public int? Rate { get; set; }

        public string Genre { get; set; }
        public string Author { get; set; }
        public string CoverPictureURL { get; set; }
    }
}
