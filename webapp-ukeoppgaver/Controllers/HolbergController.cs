using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;
using webapp_ukeoppgaver.Models;

namespace webapp_ukeoppgaver.Controllers
{
    [Route("[controller]/[action]")]
    public class HolbergController : ControllerBase
    {
        private readonly HolbergDb _holbergDb;

        public HolbergController(HolbergDb holbergDb)
        {
            _holbergDb = holbergDb;
        }
        
        /*
         // Adrian sitt forslag, tror den er bra!!
         public bool lagre<T>(T innObj) where T : class
        {
            try
            {
                _holbergDb.Add(innObj);
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        */

        // Tester om kunden finnes. Om den finnes lages ny kunde i DB, om den ikke finnes saa brukes gammel ID
        // Should probably test on more that just the name, and should seperate name haha
        // Used this a bit: https://stackoverflow.com/questions/315946/how-do-i-get-the-max-id-with-linq-to-entity

        public bool lagre(Bestilling innBestilling)
        {
            try
            {
                // hent kunde fra database, add bestilling på bestilling liste, så bare save changes på db, trenger ikke gå inn
                // om kunde ikke finnes, så bare ny bestilling
                // hent pizza bastert på navn overlapp, legg den til på bestillingen, så save db.
                // må ha kunde ut, og må ha pizza ut, så det kan saves, for å unngå duplikat
                //TODO spør om det er en bedre måte legge inn kunde og pizza, uten å gå innom DB for å først hente de ut | Nop, er ikke det
                // Could have it be so that we changed the DB entry if the adress was updated but that is way more than the task is asking.
                Kunde testKunde = _holbergDb.Kunder.FirstOrDefault(k => k.navn == innBestilling.kunde.navn);
                // feels hacky to get the whole pizza because i can't get the id but ye
                Pizza testPizza = _holbergDb.Pizzaer.FirstOrDefault(p => p.type == innBestilling.pizza.type);
                innBestilling.pizza = testPizza;
                
                
                if (testKunde is null) //om innkunden ikke fantes, lager ny kunde med ny ID
                {
                    innBestilling.kunde.id = _holbergDb.Kunder.Max(b => b.id) + 1; // trenger ikke, Tor sa at den auto when atribbute is id
                }
                else // om kunden fantes, setter kunde lik kunde på DB
                {
                    //TODO spør hvorfor det ikke går å feste på bare ID | Går ikke, må hente objekt ut for at DB skal skjønne at det ikke er duplikat
                    // innBestilling.kunde.id = testKunde.id; // This line did not work, gave error for adding customer with duplicate ID
                    innBestilling.kunde = testKunde; // this line worked well.
                }

                // TODO spør om det er nødvendig og incremente på denne måten | NB! Ikke nødvendig!!
                // Increments order ID
                innBestilling.id = _holbergDb.Bestillinger.Max(b => b.id) + 1; // increments the bestillingId // tor sier trenger ikke dette
                
                //debug
                Console.WriteLine(innBestilling.ToString());
                
                _holbergDb.Add(innBestilling);
                _holbergDb.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
        public List<Bestilling> hentAlle()
        {
            try
            {
                //TODO spør om hvorofr du hente lister for å gå det itl å gå | Woop glemte å spørre, men kanskje det løser seg selv når jeg orienterer den til bestilling
                List<Bestilling> alleBestillinger = _holbergDb.Bestillinger.ToList();
                List<Kunde> alleKunder = _holbergDb.Kunder.ToList(); // funker magisk når disse to står her i dunno hahah
                List<Pizza> allePizzar = _holbergDb.Pizzaer.ToList();
                
                //debug
                foreach (var bestilling in alleBestillinger)
                {
                    Console.WriteLine(bestilling.ToString());
                }
                return alleBestillinger;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

        public List<Pizza> hentPizza()
        {
            try
            {
                return _holbergDb.Pizzaer.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }

    }
}
