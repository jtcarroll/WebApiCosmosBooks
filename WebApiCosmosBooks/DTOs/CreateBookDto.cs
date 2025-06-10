namespace WebApiCosmosBooks.DTOs
{
    public class CreateBookDto
    {
        public string Title { get; set; }
        public int NmPages { get; set; }
        public List<string> Authors { get; set; }
    }
}
