using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public class Archetype
    {
        public string Id { get; set; }          // "Knight", "Samurai" ...
        public string Name { get; set; }        // Anzeigename
        public Temperament Temperament { get; set; }
        public string GodId { get; set; }       // Verknüpfung zum Gott
        public string GodName { get; set; }     // z.B. "St. Michael"
        public string ShortDescription { get; set; }
        public List<string> CoreAttributes { get; set; } = new();
    }
}
