using System;

namespace MyWebAPI.Data.Models
{
    public class Episode : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Season { get; set; }
        public DateTime LaunchDate { get; set; }
        public int AnimeId { get; set; }
    }
}
