using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webshop.Models
{
  public class DBCustomer
  {
    public int DBCustomerId { get; set; }
    public string Email { get; set; }
    public byte[] LoginPassword { get; set; }
    public string Navn { get; set; }
    public string Address { get; set; }

    public static byte[] GeneratePasswordHash(string Password)
    {
      var algorithm = System.Security.Cryptography.SHA512.Create();
      byte[] input = System.Text.Encoding.ASCII.GetBytes(Password);

      return algorithm.ComputeHash(input);
    }

    public static bool CheckDuplicateEmail(string checkEmail)
    {
      using (OnlineStoreEntities bookDB = new OnlineStoreEntities())
      {
        var check = (from c in bookDB.Kunder
                     where String.Compare(c.Epost, checkEmail, StringComparison.InvariantCultureIgnoreCase) == 0
                     select new
                     {
                       Email = c.Epost
                     }).SingleOrDefault();

        return check == null;
      }
    }

    public static bool CheckDuplicateEmailIgnoreCustomer(string checkEmail, int customerId)
    {
      using (OnlineStoreEntities bookDB = new OnlineStoreEntities())
      {
        var check = (from c in bookDB.Kunder
                     where c.KId != customerId
                     && String.Compare(c.Epost, checkEmail, StringComparison.InvariantCultureIgnoreCase) == 0
                     select new
                     {
                       Email = c.Epost
                     }).SingleOrDefault();

        return check == null;
      }
    }
  }
}