namespace webapp_ukeoppgaver.Models
{
    public class Bestilling
    {
        //TODO har tor noen tanker om dette, er ikke dette en bedre / mer code first måte?
        public int id { get; set; }
        public Pizza pizza { get; set; }
        public bool tykk { get; set; }
        public int antall { get; set; }
        // public Kunde kunde { get; set; } // fjern denne når du orienterer kunde først

        public override string ToString()
        {
            return "Bestilling: " + " " + id + " " + pizza.id + " " + pizza.type + " " + tykk + " " + antall + " " + 
                   kunde.id + " " + kunde.navn + " " + kunde.adresse + " " + kunde.tlfNr;
        }
    }
    

}