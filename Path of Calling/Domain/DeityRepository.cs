using System.Collections.Generic;
using System.Linq;

namespace PathOfCalling.Domain
{
    public static class DeityRepository
    {
        private static readonly List<Deity> _deities = new()
        {
            new Deity
            {
                Id = "Knight_God",
                Name = "St. Michael",
                ArchetypeId = "Knight",
                Mythology = "Christliche Tradition",
                Title = "Schutzpatron der Ritter",
                Description = "Verkörperung von Mut, Pflicht und Gerechtigkeit.",
                Stats = new Dictionary<GodStatType, int>
                {
                    { GodStatType.Vitality, 4 },
                    { GodStatType.Might,    2 },
                    { GodStatType.Guard,    5 },
                    { GodStatType.Speed,    1 },
                    { GodStatType.Focus,    3 }
                }
            },
            new Deity
            {
                Id = "Samurai_God",
                Name = "Hachiman",
                ArchetypeId = "Samurai",
                Mythology = "Shinto",
                Title = "Gott des Krieges und der Kampfkunst",
                Description = "Patron des Bushido, steht für Disziplin und reinen Willen.",
                Stats = new Dictionary<GodStatType, int>
                {
                    { GodStatType.Vitality, 2 },
                    { GodStatType.Might,    4 },
                    { GodStatType.Guard,    3 },
                    { GodStatType.Speed,    3 },
                    { GodStatType.Focus,    3 }
                }
            },
            new Deity
            {
                Id = "Viking_God",
                Name = "Thor",
                ArchetypeId = "Viking",
                Mythology = "Nordische Mythologie",
                Title = "Gott des Donners",
                Description = "Verkörperung von Stärke, Schutz und Kampfeslust.",
                Stats = new Dictionary<GodStatType, int>
                {
                    { GodStatType.Vitality, 4 },
                    { GodStatType.Might,    5 },
                    { GodStatType.Guard,    3 },
                    { GodStatType.Speed,    2 },
                    { GodStatType.Focus,    1 }
                }
            },
            new Deity
            {
                Id = "Bard_God",
                Name = "Hermes",
                ArchetypeId = "Bard",
                Mythology = "Griechische Mythologie",
                Title = "Gott der Reisenden und Boten",
                Description = "Symbol für Kommunikation, Handel und schnelle Entscheidungen.",
                Stats = new Dictionary<GodStatType, int>
                {
                    { GodStatType.Vitality, 2 },
                    { GodStatType.Might,    2 },
                    { GodStatType.Guard,    2 },
                    { GodStatType.Speed,    4 },
                    { GodStatType.Focus,    5 }
                }
            }
        };

        public static List<Deity> GetAll() => _deities;

        public static Deity? GetByArchetype(string archetypeId)
            => _deities.FirstOrDefault(d => d.ArchetypeId == archetypeId);
    }
}
