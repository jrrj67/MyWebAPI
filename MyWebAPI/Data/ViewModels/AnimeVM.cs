using System;
using System.ComponentModel.DataAnnotations;

namespace MyWebAPI.Data.ViewModels
{
    public class AnimeVM
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime LaunchDate { get; set; }
    }
}