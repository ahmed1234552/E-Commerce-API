using System.ComponentModel.DataAnnotations;



//create the Product class

enum CategoryType
{
    Electronics,
    Phones,
    Laptops,
    Groceries,
    Home,
    Toys
}

class Product
{
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public CategoryType Category { get; set; }

        [Required]
        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
        public decimal Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
        public string Description { get; set; }

}