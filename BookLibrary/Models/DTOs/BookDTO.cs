namespace BookLibrary.Models.DTOs
{
    public class BookDTO
    {
        public Guid Guid { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public bool Available { get; set; }
    }
}
