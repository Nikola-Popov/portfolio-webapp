using System;

namespace Post.Models
{
    public class PostEntry
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }

        public string Message { get; set; }

        public DateTime PostDate { get; set; }

    }
}