using System;
using System.ComponentModel.DataAnnotations;

namespace FitnessFoods.Shared.Entities
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
