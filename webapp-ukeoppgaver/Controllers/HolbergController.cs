using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using webapp_ukeoppgaver.Models;

namespace webapp_ukeoppgaver.Controllers
{
    [Route("[controller]/[action]")]
    public class HolbergController
    {
        private readonly HolbergDb _holbergDb;

        public HolbergController(HolbergDb holbergDb)
        {
            _holbergDb = holbergDb;
        }

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
        public bool lagre(Kunde innKunde)
        {
            try
            {
                _holbergDb.Add(innKunde);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
        
    }
}