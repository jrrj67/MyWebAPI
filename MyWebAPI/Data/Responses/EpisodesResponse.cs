using System;

namespace MyWebAPI.Data.Responses
{
    public class EpisodesResponse
    {
        public int Id { get; set; }
        public int AnimeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Season { get; set; }
        public DateTime LaunchDate { get; set; }

        // Navigation property
        public object Anime { get; set; }
    }
}
