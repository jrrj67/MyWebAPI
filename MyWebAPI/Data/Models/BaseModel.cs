﻿using FluentValidation.Results;
using System;
using System.Text.Json.Serialization;

namespace MyWebAPI.Data.Models
{
    public abstract class BaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}