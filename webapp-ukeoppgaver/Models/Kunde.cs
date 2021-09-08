using System.Collections.Generic;

namespace webapp_ukeoppgaver.Models
{
    public class Kunde
    {
        public int id { get; set; }
        public string navn { get; set; }
        public string adresse { get; set; }
        public string tlfNr { get; set; }
        
        // Ha kunde som hoved tabell, bestilling sterkt avhengig av kunde, pizza avhengig av bestilling
        public virtual List<Bestilling> bestillinger { get; set; }
    }
}