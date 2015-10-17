using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop
{
  //med  fordel delt denne klassen i to, Produkt og Person
  public class Produkt
  {
    public string ProduktType { get; set; }
    public decimal Pris { get; set; }
    public int antall { get; set; }
    public string navn { get; set; }
    public string adresse { get; set; }
    public string telefonnr { get; set; }
  }
}