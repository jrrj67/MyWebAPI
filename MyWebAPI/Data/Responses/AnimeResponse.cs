using System;
using System.Collections.Generic;

namespace MyWebAPI.Data.Responses
{
    public class AnimeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }

        // Navigation property
        public List<EpisodeResponse> Episodes { get; set; }
    }
}
