using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;// key attribute
using System.Data.Entity;//Entity Framework
using System.Data.Entity.ModelConfiguration.Conventions;

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

    ////[Required(ErrorMessage = "Type your address")]
    ////[StringLength(50, ErrorMessage = "Max 50 characters in your address")]
    public string Adresse { get; set; }
    public string Password { get; set; }

    //[Required(ErrorMessage = "Type your email")]
    //[StringLength(100, ErrorMessage = "Cannot be longer than 100 characters")]
    //[RegularExpression(@"^([\w\.\-]+)@([\w\-\.]+)\.([\w]{2,3})$",
    //    ErrorMessage = "Invalid email address. Example: abc@def.com")]
    public string Epost { get; set; }
    public virtual List<OrdreItem> Ordre { get; set; }

    public class OrdreItem
    {
      [Key]
      public string OrdreId { get; set; }
      public System.DateTime time { get; set; }
      public string vareNavn { get; set; }
      public int Quantity { get; set; }
      public int KId { get; set; }
      public virtual Kunde Kunde { get; set; }
      public virtual Vare vare { get; set; }

    }
  }
  public class Vare
  {
    [Key]
    public int VareId { get; set; }
    public string ProduktNavn { get; set; }
    public string ProduktMerke { get; set; }
    public decimal Pris { get; set; }
    public int Antall { get; set; }
  }

  public partial class OnlineStoreEntities : DbContext
  {
    public OnlineStoreEntities()
        : base("name=OnlineStoreEntities")
    {
     // Database.CreateIfNotExists();
    }

    public DbSet<Kunde> Kunder { get; set; }
    public DbSet<Vare> Vareer { get; set; }
    public DbSet<CartItem> ShopppingCartItem { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
      // Add any configuration or mapping stuff here
    }
  }
}