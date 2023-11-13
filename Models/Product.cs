using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;//3shan DatabaseGenerated



namespace Models;

//create the Product class
//lazem kolo public 3ashan yb2a visible lel app
public enum CategoryType
{
    Electronics,
    phones,
    Laptops,
    Groceries,
    Home,
    Toys
}

// class Seller
// {
//     [Key]
//     public int Id { get; set; }

//     [StringLength(50, MinimumLength = 3)]
//     [Required]
//     public string Name { get; set; }

//     [Required]
//     public string Address { get; set; }

//     [Required]
//     public string Phone { get; set; }

//     [Required]
//     public string Email { get; set; }

//     [Required]
//     public string Password { get; set; }

//     [Required]
//     public string ConfirmPassword { get; set; }
// }

public class Product
{
    //properties
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//auto increment and unique
        public int Id { get; set; }

        [StringLength(50, MinimumLength = 3)]
        [Required]
        public string Name { get; set; }

        [Required]
        public CategoryType Category { get; set; }

        [Required]
        [Range(0.01, 10000000)]
        public float Price { get; set; }

        [Required]
        public string ImageUrl { get; set; }
        
        [Required]
        public string Description { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        // [Required]
        // public Seller Seller { get; set; }

}