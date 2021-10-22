using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using System;

namespace MyWebAPI.Data.Models
{
    public class AnimeEntity : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime LaunchDate { get; set; }
    }
}
