namespace webapp_ukeoppgaver.Models
{
    public class Bestilling
    {
        public int id { get; set; }
        public Pizza pizza { get; set; }
        public bool tykk { get; set; }
        public int antall { get; set; }
        public Kunde kunde { get; set; }
    }
}