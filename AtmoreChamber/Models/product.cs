using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AtmoreChamber.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }

        [Display(Name = "Category")]
        [ForeignKey("ProductCategoryID")]
        public int ProductCategoryID { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string ProductName{ get; set; }

        [Display(Name = "Brand")]
        public string ProductBrand { get; set; }

        [Display(Name = "Type")]
        public string ProductType { get; set; }

        [Display(Name = "Description")]
        public string ProductDescription { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [Display(Name = "Amount instock")]
        public int Quantity { get; set; }



    }
}