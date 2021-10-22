using System;

namespace MyWebAPI.Data.Models
{
    public class Anime : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
