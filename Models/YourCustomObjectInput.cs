using System;
using System.ComponentModel.DataAnnotations;

namespace webapi_template_2.Models
{
    public class YourCustomObjectInput
    {
        [Required]
        [StringLength(100)]
        public string Arg1 {get; set;}
        public string Arg2 {get; set;}
        [DataType(DataType.Date)]
        public DateTime SomeDate{ get; set; }
    }
}