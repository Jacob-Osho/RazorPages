using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesGeneral.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The name field cannot be empty")]
        [MaxLength(50,ErrorMessage ="Name can't contain more then 50 symbols"),MinLength(2,ErrorMessage = "Name can't be less then 2 symbols")]
        public string Name { get; set; }
        [Required]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$",ErrorMessage = "Invalid email Adress")]
        [MaxLength(50, ErrorMessage = "Email can't contain more then 50 symbols"), MinLength(2, ErrorMessage = "Email can't be less then 2 symbols")]
        public string Email { get; set; }
        public string PhotoPath { get; set; }
        public Dept? Department { get; set; }
    }
}
