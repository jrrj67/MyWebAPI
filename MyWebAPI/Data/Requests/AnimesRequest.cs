using System;

namespace MyWebAPI.Data.Requests
{
    public class AnimesRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
