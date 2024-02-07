using System.ComponentModel.DataAnnotations;

namespace NewProducts.Entity.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Phone Number is Required")]
        public long Phno { get; set; }
    }
}
