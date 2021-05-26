using FitnessFoods.Domain.Enums;
using FitnessFoods.Shared.Entities;
using System;

namespace FitnessFoods.Domain.Entities
{
    public class Product: BaseEntity
    {
        public string Code { get; set; }
        public Status? Status { get; set; }
        public DateTime? Imported_t { get; set; }
        public string Url { get; set; }
        public string Creator { get; set; }
        public long Created_t { get; set; } 
        public long Last_modified_t { get; set; } 
        public string Product_name { get; set; }
        public string Quantity { get; set; }
        public string Brands { get; set; }
        public string Categories { get; set; }
        public string Labels { get; set; }
        public string Cities { get; set; }
        public string Purchase_places { get; set; }
        public string Stores { get; set; }
        public string Ingredients_text { get; set; }
        public string Traces { get; set; }
        public string Serving_size { get; set; }
        public double? Serving_quantity { get; set; }
        public int? Nutriscore_score { get; set; }
        public string Nutriscore_grade { get; set; }
        public string Main_category { get; set; }
        public string Image_url { get; set; }
    }
}
