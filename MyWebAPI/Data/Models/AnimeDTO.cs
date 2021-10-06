using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using MyWebAPI.Data.Validators;
using System;
using System.Text.Json.Serialization;

namespace MyWebAPI.Data.Models
{
    public class AnimeDTO : Anime
    {
        public AnimeDTO(string name, string description, DateTime launchDate) : base(name, description, launchDate)
        {
        }

        [JsonIgnore]
        public new int Id { get; set; }
    }
}
