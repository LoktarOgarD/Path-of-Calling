using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public class ShadowEnemy
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string ArchetypeId { get; set; } = ""; // Knight / Samurai / Viking / Bard oder "" für generische Gegner
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public int MaxHp { get; set; }
        public int Hp { get; set; }
    }

    public static class ShadowEnemyRepository
    {
        public static ShadowEnemy GetShadowForArchetype(string archetypeId)
        {
            return archetypeId switch
            {
                "Knight" => new ShadowEnemy
                {
                    Id = "Shadow_Sloth",
                    ArchetypeId = "Knight",
                    Name = "The Sloth",
                    Title = "Verkörperung der Lähmung",
                    Description = "Symbolisiert Stagnation und die Weigerung zu handeln. Hält den Ritter davon ab, seinen Pflichten zu folgen.",
                    MaxHp = 10,
                    Hp = 10
                },
                "Samurai" => new ShadowEnemy
                {
                    Id = "Shadow_Chaos",
                    ArchetypeId = "Samurai",
                    Name = "The Chaos",
                    Title = "Verkörperung der Unordnung",
                    Description = "Repräsentiert Prokrastination und fehlende Struktur. Steht der Perfektion des Samurai im Weg.",
                    MaxHp = 10,
                    Hp = 10
                },
                "Viking" => new ShadowEnemy
                {
                    Id = "Shadow_Weakling",
                    ArchetypeId = "Viking",
                    Name = "The Weakling",
                    Title = "Verkörperung der Angst",
                    Description = "Symbolisiert körperliche Schwäche und Angst vor dem Tod. Nimmt dem Wikinger die Ehre.",
                    MaxHp = 10,
                    Hp = 10
                },
                "Bard" => new ShadowEnemy
                {
                    Id = "Shadow_Judge",
                    ArchetypeId = "Bard",
                    Name = "The Judge",
                    Title = "Verkörperung des Urteils",
                    Description = "Steht für Manipulation, Spott und soziale Verurteilung. Blockiert den freien Ausdruck des Barden.",
                    MaxHp = 10,
                    Hp = 10
                },
                _ => new ShadowEnemy
                {
                    Id = "Shadow_Doubt",
                    ArchetypeId = "",
                    Name = "Innerer Zweifel",
                    Title = "Ein namenloser Schatten",
                    Description = "Verkörpert allgemeine Unsicherheit.",
                    MaxHp = 8,
                    Hp = 8
                }
            };
        }

        // kleine generische Schatten für Level 1–4, bevor Archetyp feststeht
        public static ShadowEnemy GetMinorShadowForLevel(int level)
        {
            switch (level)
            {
                case 1:
                    return new ShadowEnemy
                    {
                        Id = "Shadow_Instinct",
                        Name = "Shadow of Instinct",
                        Title = "Unruhiger Impuls",
                        Description = "Testet deine Kontrolle über spontanes Handeln.",
                        MaxHp = 6,
                        Hp = 6
                    };
                case 2:
                    return new ShadowEnemy
                    {
                        Id = "Shadow_Emotion",
                        Name = "Shadow of Emotion",
                        Title = "Sturm der Gefühle",
                        Description = "Stellt deine emotionale Stabilität auf die Probe.",
                        MaxHp = 7,
                        Hp = 7
                    };
                case 3:
                    return new ShadowEnemy
                    {
                        Id = "Shadow_Duty",
                        Name = "Shadow of Duty",
                        Title = "Stimme der Bequemlichkeit",
                        Description = "Versucht, dich von deinen Pflichten abzuhalten.",
                        MaxHp = 8,
                        Hp = 8
                    };
                case 4:
                    return new ShadowEnemy
                    {
                        Id = "Shadow_Silence",
                        Name = "Shadow of Silence",
                        Title = "Stille Versuchung",
                        Description = "Testet deine Fähigkeit, in Ruhe bei dir zu bleiben.",
                        MaxHp = 9,
                        Hp = 9
                    };
                default:
                    return new ShadowEnemy
                    {
                        Id = "Shadow_Generic",
                        Name = "Unbekannter Schatten",
                        Title = "Formlose Angst",
                        Description = "Eine undefinierte innere Blockade.",
                        MaxHp = 5,
                        Hp = 5
                    };
            }
        }
    }
}
