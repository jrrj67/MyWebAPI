using System;

namespace MyWebAPI.Data.Requests
{
    public class EpisodesRequest
    {
        public int AnimeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Season { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
