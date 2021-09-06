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

        //TODO omg fix this how do you even with all the types why did i make it so hard aaaa
        // Only like lets you do the add but nothing shows up in the database
        // must find a way to properly separate the data, and also make customers if there are anone
        public bool lagre(Bestilling innBestilling)
        {
            try
            {
                // used this a bit: https://stackoverflow.com/questions/315946/how-do-i-get-the-max-id-with-linq-to-entity
                
                // Tester om kunden finnes. Om den finnes lages ny kunde i DB, om den ikke finnes saa brukes gammel ID
                // Should probably test on more that just the name, and should seperate name haha
                // Could have it be so that we changed the DB entry if the adress was updated but that is way more than the task is asking.
                Kunde testKunde = _holbergDb.Kunder.FirstOrDefault(k => k.navn == innBestilling.kunde.navn);
                if (testKunde is null) //om innkunden ikke fantes
                {
                    innBestilling.kunde.id = _holbergDb.Kunder.Max(b => b.id) + 1;
                }
                else // om kunden fantes.
                {
                    // innBestilling.kunde.id = testKunde.id; // This line did not work, gave error for adding customer with duplicate ID
                    innBestilling.kunde = testKunde; // this line worked well.
                }

                // Increments order ID, and pizza ID.
                // Needs to be removed in favour of pizza list dropdown
                innBestilling.id = _holbergDb.Bestillinger.Max(b => b.id) + 1; // increments the bestillingId
                innBestilling.pizza.id = _holbergDb.Pizzaer.Max(b => b.id) + 1;
                
                Console.WriteLine(innBestilling.ToString()); //need some debug yoo
                
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
                List<Bestilling> alleBestillinger = _holbergDb.Bestillinger.ToList();
                List<Kunde> alleKunder = _holbergDb.Kunder.ToList(); // funker magisk når disse står her i dunno hahah
                List<Pizza> allePizzar = _holbergDb.Pizzaer.ToList(); // jaja
                
                // cheap debug writes
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

    }
}
