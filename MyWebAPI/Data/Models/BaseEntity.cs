using FluentValidation.Results;
using System;

namespace MyWebAPI.Data.Models
{
    public abstract class BaseEntity<T> : BaseModel
    {
        public abstract void Update(T model);
        public abstract ValidationResult Validate();
    }
}
