namespace WebApiCosmosBooks.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string PartitionKey { get; set; }
        public string Title { get; set; }
        public int NmPages { get; set; }
        public List<string> Authors { get; set; }
    }
}
