using System.Data.Entity;

namespace Post.Models
{
    public class PostContext : DbContext
    {
        public PostContext() : base("PostContext") { }

        public DbSet<PostEntry> Entries { get; set; }

    }
}
