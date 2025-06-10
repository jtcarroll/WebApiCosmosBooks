namespace WebApiCosmosBooks.DTOs
{
    public class KeysDto
    {
        public required string ClientId { get; set; }
        public required string TenantId { get; set; }
        public required string[] Scopes { get; set; }
    }
}
