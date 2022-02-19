using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _210940320070.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Name is Necessary")]
        [StringLength(30, ErrorMessage = "Enter the Name within 20 letters")]

        public String ProductName { get; set; }
        
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Price is must")]
        [Range(typeof(Decimal), "0", "500",ErrorMessage ="{0} must be decimal/number between {1} and {2}")]
        public decimal Rate { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Description is Necessary")]
        [StringLength(30, ErrorMessage = "Enter the Name within 200 letters")]
        public String Description { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "CategoryName is Necessary")]
        [StringLength(30, ErrorMessage = "Enter the Name within 20 letters")]
        public String CategoryName { get; set; }


    }
}