using FitnessFoods.Shared.Entities;
using System;

namespace FitnessFoods.Domain.Entities
{
    public class ImportHistory: BaseEntity
    {
        public DateTime Time { get; set; }
        public bool Failure { get; set; } = false;
        public string File { get; set; } = null;

    }
}
