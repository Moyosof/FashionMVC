using System.ComponentModel.DataAnnotations;

namespace FashionMVC.Models
{
    public class Fashion
    {
        [Key]
        public int Id { get; set; }
        public string BrandName { get; set; }
        [Required(ErrorMessage ="Please choose a clothe type")]
        public ClothesType ClothesType { get; set; }
        public string Size { get; set; }


    }
}
