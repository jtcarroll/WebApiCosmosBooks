

using Microsoft.EntityFrameworkCore;
using WebApiCosmosBooks.Entities;

namespace WebApiCosmosBooks.Data
{
    public class LibraryContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        #region Configuration
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseCosmos(
                "AccountEndpoint=https://datingappjc.documents.azure.com:443/;AccountKey=d5o5UBcHJ2klLIUhBXxP0YSJmIooZtqJTK7U1ap73gfRcJE6m2IhlJ3gVZr6o0EGudnb2FGOUbrCACDbywaV2A==;",
                databaseName: "Books");
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Container
            modelBuilder.Entity<Book>()
                .ToContainer("Books");
            #endregion

            #region PartitionKey
            modelBuilder.Entity<Book>()
                .HasPartitionKey(o => o.PartitionKey);
            #endregion

            #region ETag
            modelBuilder.Entity<Book>()
                .UseETagConcurrency();
            #endregion

            #region NoDiscriminator
            modelBuilder.Entity<Book>()
                .HasNoDiscriminator();
            #endregion

        }
    }
}
