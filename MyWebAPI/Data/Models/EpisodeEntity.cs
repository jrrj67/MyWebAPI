using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;

namespace MyWebAPI.Data.Models
{
    public class EpisodeEntity : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Number { get; set; }
        public int Season { get; set; }
        public DateTime LaunchDate { get; set; }
        public int AnimeId { get; set; }
    }
}
