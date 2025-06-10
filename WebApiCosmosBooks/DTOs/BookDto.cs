namespace WebApiCosmosBooks.DTOs
{
    public class BookDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int NmPages { get; set; }
        public List<string> Authors { get; set; }
    }
}
