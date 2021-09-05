using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Mvc;
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
                int bestillingId = _holbergDb.Bestillinger.Max(b => b.id);
                int pizzaId = _holbergDb.Pizzaer.Max(b => b.id);
                int kundeId = _holbergDb.Kunder.Max(b => b.id);
                // var userId = _holbergDb.Kunder.OrderByDescending(k => k.id).FirstOrDefault();

                innBestilling.id = _holbergDb.Bestillinger.Max(b => b.id) + 1;
                innBestilling.pizza.id = ++pizzaId;
                innBestilling.kunde.id = ++kundeId;
                // can probably temporarily fix this by getting max id and setting it + 1 to the inn obj in both pizza and stuff ye
                Console.WriteLine(innBestilling.ToString()); //need some debug yoo
                _holbergDb.Add(innBestilling);
                // forgot to save changes KMS
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