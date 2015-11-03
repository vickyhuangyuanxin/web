using webshop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

// actions connecting to DB
namespace webshop.Logic
{
    public class DB
    {
        public bool SettInnNyVare(Vare NyProdukt)
        {
         var db = new OnlineStoreEntities();
      // se om kunden eksitere
      // Kunde funnetKunde = db.Kunder.FirstOrDefault(k => k.Navn == NyProdukt.navn);
            using (var dbTransaksjon = db.Database.BeginTransaction())
            {
                var nyVare = new Vare()
                {   // en annen måte å initsiere attributter i en klasse når den
                  //instansieres (må ikke ha konstruktør for å gjøre dette)
                    Antall = NyProdukt.Antall,
                    ProduktNavn = NyProdukt.ProduktNavn,
                    ProduktMerke = NyProdukt.ProduktMerke,
                    Pris = NyProdukt.Pris
                };
                try
                {
                    db.Vareer.Add(nyVare);
                    db.SaveChanges();
                    dbTransaksjon.Commit();
                    return true;
                }
                catch (Exception feil)
                {
                    dbTransaksjon.Rollback();
                    return false;
                }
            }
        }

    public bool SettInnNyKunde(Kunde nykunde)
    {
      var db = new OnlineStoreEntities();
      // se om kunden eksitere
      // Kunde funnetKunde = db.Kunder.FirstOrDefault(k => k.Navn == NyProdukt.navn);
      using (var dbTransaksjon = db.Database.BeginTransaction())
      {
        var kunde = new Kunde()
        {   // en annen måte å initsiere attributter i en klasse når den
            //instansieres (må ikke ha konstruktør for å gjøre dette)
          Navn = nykunde.Navn,
          Adresse = nykunde.Adresse,
          Epost = nykunde.Epost,
          Password = nykunde.Password
        };
        try
        {
          db.Kunder.Add(nykunde);
          db.SaveChanges();
          dbTransaksjon.Commit();
          return true;
        }
        catch (Exception feil)
        {
          dbTransaksjon.Rollback();
          return false;
        }
      }
    }
    public static byte[] GeneratePasswordHash(string Password)
    {
      var algorithm = System.Security.Cryptography.SHA512.Create();
      byte[] input = System.Text.Encoding.ASCII.GetBytes(Password);

      return algorithm.ComputeHash(input);
    }

    public static bool CheckDuplicateEpost(string checkEpost)
    {
      using (OnlineStoreEntities DB = new OnlineStoreEntities())
      {
        var check = (from c in DB.Kunder
                     where String.Compare(c.Epost, checkEpost, StringComparison.InvariantCultureIgnoreCase) == 0
                     select new
                     {
                       Epost = c.Epost
                     }).SingleOrDefault();

        return check == null;
      }
    }

    public static bool CheckDuplicateEpostIgnoreCustomer(string checkEpost, int customerId)
    {
      using (OnlineStoreEntities DB = new OnlineStoreEntities())
      {
        var check = (from c in DB.Kunder
                     where c.KId != customerId
                     && String.Compare(c.Epost, checkEpost, StringComparison.InvariantCultureIgnoreCase) == 0
                     select new
                     {
                       Epost = c.Epost
                     }).SingleOrDefault();

        return check == null;
      }
    }

    public List<Vare> listAlleVare()
    {
      using (var db = new OnlineStoreEntities())
      {
        List<Vare> VarerFraDb = db.Vareer.ToList();
        List<Vare> alleVareer = new List<Vare>();
        foreach (var vare in VarerFraDb)
        {   
          var enVare = new Vare();
          enVare.Antall = vare.Antall;
          enVare.Pris = vare.Pris;
          enVare.ProduktNavn = vare.ProduktNavn;
          enVare.ProduktMerke = vare.ProduktMerke;
          enVare.VareId = vare.VareId;
          alleVareer.Add(enVare);
        }
        return alleVareer;
      }
    }
    public void Dispose()
    {
      throw new NotImplementedException();
    }
  }
}