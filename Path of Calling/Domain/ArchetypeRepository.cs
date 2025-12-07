using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public static class ArchetypeRepository
    {
        private static readonly List<Archetype> _archetypes = new()
        {
            new Archetype
            {
                Id = "Knight",
                Name = "Knight",
                Temperament = Temperament.Melancholic,
                GodId = "Knight_God",
                GodName = "St. Michael",
                ShortDescription = "Ehre, Pflicht und Ausdauer.",
                CoreAttributes = new List<string>
                {
                    "Schutz der Schwachen",
                    "Verantwortung",
                    "Durchhaltevermögen"
                }
            },
            new Archetype
            {
                Id = "Samurai",
                Name = "Samurai",
                Temperament = Temperament.Phlegmatic,
                GodId = "Samurai_God",
                GodName = "Hachiman",
                ShortDescription = "Disziplin, Fokus und Reinheit.",
                CoreAttributes = new List<string>
                {
                    "Bushido",
                    "Meditation",
                    "Meisterschaft durch Übung"
                }
            },
            new Archetype
            {
                Id = "Viking",
                Name = "Viking",
                Temperament = Temperament.Choleric,
                GodId = "Viking_God",
                GodName = "Thor",
                ShortDescription = "Stärke, Mut und Entschlossenheit.",
                CoreAttributes = new List<string>
                {
                    "Wettkampf",
                    "Abenteuerlust",
                    "Furchtlosigkeit"
                }
            },
            new Archetype
            {
                Id = "Bard",
                Name = "Bard",
                Temperament = Temperament.Sanguine,
                GodId = "Bard_God",
                GodName = "Hermes",
                ShortDescription = "Inspiration, Kreativität und soziale Bindungen.",
                CoreAttributes = new List<string>
                {
                    "Kommunikation",
                    "Diplomatie",
                    "Reisen & Netzwerken"
                }
            }
        };

        public static List<Archetype> GetAll() => _archetypes;

        public static Archetype? GetById(string id)
            => _archetypes.Find(a => a.Id == id);
    }
}
