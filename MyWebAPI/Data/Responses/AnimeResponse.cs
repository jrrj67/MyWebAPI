﻿using System;

namespace MyWebAPI.Data.Responses
{
    public class AnimeResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
