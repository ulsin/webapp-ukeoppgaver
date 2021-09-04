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
                _holbergDb.Add(innBestilling);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        // Dette ble jo bare samme kode men med annen type, kan man lage den mer polymorf?
        // public bool lagre(Kunde innKunde)
        // {
        //     try
        //     {
        //         _holbergDb.Add(innKunde);
        //         return true;
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine(e);
        //         return false;
        //     }
        // }

        public List<Bestilling> hentAlle()
        {
            try
            {
                List<Bestilling> alleBestillinger = _holbergDb.Bestillinger.ToList();
                List<Kunde> alleKunder = _holbergDb.Kunder.ToList(); // funker magisk når disse står her i dunno hahah
                List<Pizza> allePizzar = _holbergDb.Pizzaer.ToList(); // jaja
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