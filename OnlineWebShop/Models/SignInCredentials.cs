
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prosjekt1.Models
{
  public class SignInCredentials
  {
    [Required(ErrorMessage = "Email is required")]
    [StringLength(160)]
    public string Email { get; set; }
    [Required(ErrorMessage = "Password is required")]
    [StringLength(160)]
    public string LoginPassword { get; set; }
  }
}