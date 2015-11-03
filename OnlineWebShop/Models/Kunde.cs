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

    [Required(ErrorMessage = "Type your firstname")]
    [StringLength(50, ErrorMessage = "Max 50 characters in your firstname")]
    [RegularExpression(@"[A-Za-z \-]+", ErrorMessage = "Use only letters in your name")]
    public string Navn { get; set; }
    public string Adresse { get; set; }
    public string Epost { get; set; }
    public string Password { get; set; }
  }
}