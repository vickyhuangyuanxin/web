using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace webshop.Models
{
  public class Kunde
  {
    [Key]
    public int KId { get; set; }
    [Required(ErrorMessage = "Type your name")]
    [StringLength(50, ErrorMessage = "Max 50 characters in your firstname")]
    [RegularExpression(@"[A-Za-z \-]+", ErrorMessage = "Use only letters in your name")]
     public string Navn { get; set; }


    [Required(ErrorMessage = "Type your Adresse")]
    [StringLength(50, ErrorMessage = "Max 50 characters in your firstname")]
    [RegularExpression(@"[A-Za-z \-]+", ErrorMessage = "Use only letters in your Address")]
    public string Adresse { get; set; }

    //TODO regex validation
    [Required(ErrorMessage = "Type your Email")]
    [StringLength(100, ErrorMessage = "Cannot be longer than 100 characters")]
    [RegularExpression(@"^([\w\.\-]+)@([\w\-\.]+)\.([\w]{2,3})$",
      ErrorMessage = "Invalid email address. Example: abc@def.com")]
    [DataType(DataType.EmailAddress)]
    public string Epost { get; set; }

    [Required(ErrorMessage = "Type your Password")]
    [StringLength(50, ErrorMessage = "Max 50 characters in your passord")]
    public string Password { get; set; }

 //   public virtual List<CartItem> Ordre { get; set; }
  }
}