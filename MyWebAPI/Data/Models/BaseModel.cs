using FluentValidation.Results;
using System;
using System.Text.Json.Serialization;

namespace MyWebAPI.Data.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }

        [JsonIgnore]
        public DateTime CreatedAt { get; set; }

        [JsonIgnore]
        public DateTime UpdatedAt { get; set; }

        public abstract ValidationResult Validate();

        public virtual void ResetHiddenFields()
        {
            Id = default(int);
            CreatedAt = default(DateTime);
            UpdatedAt = default(DateTime);
        }
    }
}
