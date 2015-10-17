using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webshop.Models;
namespace webshop.ViewModels
{
  public class ShoppingCartViewModel
  {
      public List<CartItem> CartItems { get; set; }
      public decimal CartTotal { get; set; }
  }
}