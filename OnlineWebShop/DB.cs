using webshop.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace webshop
{
    public class DB
    {
        public bool settInnBestillng(Produkt bestiltProdukt)
        {
            int kundeID; // brukes til enten eksisterende KId eller den nye KId
            
            var db = new OnlineStoreEntities();
      // se om kunden eksitere
      Kunde funnetKunde = db.Kunder.FirstOrDefault(k => k.Navn == bestiltProdukt.navn);

            using (var dbTransaksjon = db.Database.BeginTransaction())
            {
                if (funnetKunde == null)
                {
                    // opprett kunder obj
                    var kunde = new Kunde();
                    kunde.Navn = bestiltProdukt.navn;
                    kunde.Adresse = bestiltProdukt.adresse;
                    kunde.Telefonnr = bestiltProdukt.telefonnr;
                    try
                    {
                        db.Kunder.Add(kunde);
                        db.SaveChanges();
                        kundeID = kunde.KId; // nå har kunde.KId fått riktig verdi (den nye ID)
                    }
                    catch (Exception feil)
                    {
                        dbTransaksjon.Rollback();
                        return false;
                    }
                }
                else
                {
                    kundeID = funnetKunde.KId;
                }

                // registrer bestillingen på kunden, enten ny eller gammel
                var bestilling = new Bestilling()
                {   // en annen måte å initsiere attributter i en klasse når den
                  //instansieres (må ikke ha konstruktør for å gjøre dette)
                    KId = kundeID,
                    Antall = bestiltProdukt.antall,
                    ProduktNavn = bestiltProdukt.ProduktType,
                    Pris = bestiltProdukt.Pris
                };

                try
                {
                    db.Bestillinger.Add(bestilling);
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

    public List<Produkt> listAlleBestillnger()
    {
      using (var db = new OnlineStoreEntities())
      {
        List<Kunde> alleKunder = db.Kunder.ToList();
   
        List<Produkt> alleBestillinger = new List<Produkt>();
        foreach (var kunde in alleKunder)
        {
          foreach (var best in kunde.Bestillinger)
          {
            var enBestilling = new Produkt();
            enBestilling.navn = kunde.Navn;
            enBestilling.adresse = kunde.Adresse;
            enBestilling.telefonnr = kunde.Telefonnr;
            enBestilling.ProduktType = best.ProduktNavn;
            enBestilling.antall = best.Antall;
            enBestilling.Pris = best.Pris;
            alleBestillinger.Add(enBestilling);
          }
        }
        return alleBestillinger;
      }
    }
  }
}