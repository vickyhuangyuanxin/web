using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webshop.Models
{
  //med virtual Kunde og vare list
  public class CartItem
  {
    //public string ProduktType { get; set; }
    //public decimal Pris { get; set; }
    //public int antall { get; set; }
    //public string navn { get; set; }
    //public string adresse { get; set; }
    //public string Password { get; set; }
    [Key]
    public string ItemId { get; set; }
    public string CartId { get; set; }
    public int VareId { get; set; }
    public int Quantity { get; set; }
    //public int KId { get; set; }
    //public virtual Kunde Kunde { get; set; }
    public virtual Vare Vare { get; set; }
  }
}