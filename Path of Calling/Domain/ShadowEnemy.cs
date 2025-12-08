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

        // vorbereitet für Hybrid-Kampfsystem (Würfel + Basiswerte)
        public int AttackPower { get; set; }
        public int DefensePower { get; set; }
    }

    public static class ShadowEnemyRepository
    {
        // === Großer Schatten-Boss pro Archetyp (für Final God Trial-Vorbereitung) ===
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
                    MaxHp = 16,
                    Hp = 16,
                    AttackPower = 5,
                    DefensePower = 5
                },
                "Samurai" => new ShadowEnemy
                {
                    Id = "Shadow_Chaos",
                    ArchetypeId = "Samurai",
                    Name = "The Chaos",
                    Title = "Verkörperung der Unordnung",
                    Description = "Repräsentiert Prokrastination und fehlende Struktur. Steht der Perfektion des Samurai im Weg.",
                    MaxHp = 16,
                    Hp = 16,
                    AttackPower = 5,
                    DefensePower = 5
                },
                "Viking" => new ShadowEnemy
                {
                    Id = "Shadow_Weakling",
                    ArchetypeId = "Viking",
                    Name = "The Weakling",
                    Title = "Verkörperung der Angst",
                    Description = "Symbolisiert körperliche Schwäche und Angst vor dem Tod. Nimmt dem Wikinger die Ehre.",
                    MaxHp = 16,
                    Hp = 16,
                    AttackPower = 6,
                    DefensePower = 4
                },
                "Bard" => new ShadowEnemy
                {
                    Id = "Shadow_Judge",
                    ArchetypeId = "Bard",
                    Name = "The Judge",
                    Title = "Verkörperung des Urteils",
                    Description = "Steht für Manipulation, Spott und soziale Verurteilung. Blockiert den freien Ausdruck des Barden.",
                    MaxHp = 16,
                    Hp = 16,
                    AttackPower = 4,
                    DefensePower = 6
                },
                _ => new ShadowEnemy
                {
                    Id = "Shadow_Doubt",
                    ArchetypeId = "",
                    Name = "Innerer Zweifel",
                    Title = "Ein namenloser Schatten",
                    Description = "Verkörpert allgemeine Unsicherheit.",
                    MaxHp = 12,
                    Hp = 12,
                    AttackPower = 4,
                    DefensePower = 4
                }
            };
        }

        // === Kleine, levelbasierte Schatten vor dem finalen Archetyp-Schatten ===
        // Wird nach jedem Level (4 Fragen) aufgerufen.
        // archetypeId = vorläufig führender Archetyp (oder null/"" am Anfang)
        public static ShadowEnemy GetMinorShadowForLevel(int level, string? archetypeId)
        {
            if (string.IsNullOrWhiteSpace(archetypeId))
            {
                // noch kein klarer Archetyp → generischer Gegner
                return GetGenericMinorShadow(level);
            }

            return archetypeId switch
            {
                "Knight"  => GetKnightMinorShadow(level),
                "Samurai" => GetSamuraiMinorShadow(level),
                "Viking"  => GetVikingMinorShadow(level),
                "Bard"    => GetBardMinorShadow(level),
                _         => GetGenericMinorShadow(level)
            };
        }

        // === Knight: The Sloth – Weg durch Bequemlichkeit / Lähmung ===
        private static ShadowEnemy GetKnightMinorShadow(int level) => level switch
        {
            1 => new ShadowEnemy
            {
                Id = "Knight_Shadow_Comfort",
                ArchetypeId = "Knight",
                Name = "Shadow of Comfort",
                Title = "Süße Bequemlichkeit",
                Description = "Flüstert dir zu, dass Ausruhen angenehmer ist als Verantwortung.",
                MaxHp = 6,
                Hp = 6,
                AttackPower = 3,
                DefensePower = 3
            },
            2 => new ShadowEnemy
            {
                Id = "Knight_Shadow_Delay",
                ArchetypeId = "Knight",
                Name = "Shadow of Delay",
                Title = "Stimme des Aufschubs",
                Description = "Versucht, dich dazu zu bringen, wichtige Aufgaben auf morgen zu verschieben.",
                MaxHp = 7,
                Hp = 7,
                AttackPower = 3,
                DefensePower = 4
            },
            3 => new ShadowEnemy
            {
                Id = "Knight_Shadow_Doubt",
                ArchetypeId = "Knight",
                Name = "Shadow of Doubt",
                Title = "Nagende Unsicherheit",
                Description = "Lässt dich an deiner eigenen Würde und Fähigkeit zweifeln.",
                MaxHp = 8,
                Hp = 8,
                AttackPower = 4,
                DefensePower = 4
            },
            4 => new ShadowEnemy
            {
                Id = "Knight_Shadow_Burden",
                ArchetypeId = "Knight",
                Name = "Shadow of Burden",
                Title = "Last der Verantwortung",
                Description = "Macht jede Pflicht so schwer, dass du sie am liebsten gar nicht beginnst.",
                MaxHp = 9,
                Hp = 9,
                AttackPower = 4,
                DefensePower = 5
            },
            _ => GetGenericMinorShadow(level)
        };

        // === Samurai: The Chaos – Weg durch Ablenkung / Strukturverlust ===
        private static ShadowEnemy GetSamuraiMinorShadow(int level) => level switch
        {
            1 => new ShadowEnemy
            {
                Id = "Samurai_Shadow_Distraction",
                ArchetypeId = "Samurai",
                Name = "Shadow of Distraction",
                Title = "Flackernder Fokus",
                Description = "Lenkt deinen Geist ständig von deinem Weg ab.",
                MaxHp = 6,
                Hp = 6,
                AttackPower = 3,
                DefensePower = 3
            },
            2 => new ShadowEnemy
            {
                Id = "Samurai_Shadow_Disorder",
                ArchetypeId = "Samurai",
                Name = "Shadow of Disorder",
                Title = "Innere Unordnung",
                Description = "Zerreißt deine Struktur und lässt dich planlos handeln.",
                MaxHp = 7,
                Hp = 7,
                AttackPower = 3,
                DefensePower = 4
            },
            3 => new ShadowEnemy
            {
                Id = "Samurai_Shadow_Procrastination",
                ArchetypeId = "Samurai",
                Name = "Shadow of Procrastination",
                Title = "Meister des Aufschubs",
                Description = "Flüstert dir zu, dass der perfekte Moment noch nicht gekommen ist.",
                MaxHp = 8,
                Hp = 8,
                AttackPower = 4,
                DefensePower = 4
            },
            4 => new ShadowEnemy
            {
                Id = "Samurai_Shadow_BrokenDiscipline",
                ArchetypeId = "Samurai",
                Name = "Shadow of Broken Discipline",
                Title = "Zerbrochenes Ritual",
                Description = "Lässt deine Rituale auseinanderfallen und deine Klinge rosten.",
                MaxHp = 9,
                Hp = 9,
                AttackPower = 4,
                DefensePower = 5
            },
            _ => GetGenericMinorShadow(level)
        };

        // === Viking: The Weakling – Weg durch Angst / Flucht ===
        private static ShadowEnemy GetVikingMinorShadow(int level) => level switch
        {
            1 => new ShadowEnemy
            {
                Id = "Viking_Shadow_Fear",
                ArchetypeId = "Viking",
                Name = "Shadow of Fear",
                Title = "Leises Zittern",
                Description = "Schickt dir Zweifel, bevor du in die Schlacht gehst.",
                MaxHp = 6,
                Hp = 6,
                AttackPower = 4,
                DefensePower = 2
            },
            2 => new ShadowEnemy
            {
                Id = "Viking_Shadow_Hesitation",
                ArchetypeId = "Viking",
                Name = "Shadow of Hesitation",
                Title = "Sekunde des Zögerns",
                Description = "Nimmt dir den Mut für den ersten Schritt.",
                MaxHp = 7,
                Hp = 7,
                AttackPower = 4,
                DefensePower = 3
            },
            3 => new ShadowEnemy
            {
                Id = "Viking_Shadow_Pain",
                ArchetypeId = "Viking",
                Name = "Shadow of Pain",
                Title = "Erinnerung an Niederlagen",
                Description = "Lässt alte Wunden größer erscheinen, als sie sind.",
                MaxHp = 8,
                Hp = 8,
                AttackPower = 5,
                DefensePower = 3
            },
            4 => new ShadowEnemy
            {
                Id = "Viking_Shadow_Cowardice",
                ArchetypeId = "Viking",
                Name = "Shadow of Cowardice",
                Title = "Stimme der Flucht",
                Description = "Überzeugt dich, dass Weglaufen sicherer ist als Ehre.",
                MaxHp = 9,
                Hp = 9,
                AttackPower = 5,
                DefensePower = 4
            },
            _ => GetGenericMinorShadow(level)
        };

        // === Bard: The Judge – Weg durch Scham / Urteil ===
        private static ShadowEnemy GetBardMinorShadow(int level) => level switch
        {
            1 => new ShadowEnemy
            {
                Id = "Bard_Shadow_Gossip",
                ArchetypeId = "Bard",
                Name = "Shadow of Gossip",
                Title = "Flüsternde Zunge",
                Description = "Benutzt Worte, um andere zu verletzen statt zu heilen.",
                MaxHp = 6,
                Hp = 6,
                AttackPower = 3,
                DefensePower = 3
            },
            2 => new ShadowEnemy
            {
                Id = "Bard_Shadow_Shame",
                ArchetypeId = "Bard",
                Name = "Shadow of Shame",
                Title = "Brennende Peinlichkeit",
                Description = "Lässt dich glauben, dass du dich nicht zeigen darfst.",
                MaxHp = 7,
                Hp = 7,
                AttackPower = 3,
                DefensePower = 4
            },
            3 => new ShadowEnemy
            {
                Id = "Bard_Shadow_Manipulation",
                ArchetypeId = "Bard",
                Name = "Shadow of Manipulation",
                Title = "Falsches Lächeln",
                Description = "Verführt dich dazu, dich zu verstellen, um gemocht zu werden.",
                MaxHp = 8,
                Hp = 8,
                AttackPower = 4,
                DefensePower = 4
            },
            4 => new ShadowEnemy
            {
                Id = "Bard_Shadow_SocialCage",
                ArchetypeId = "Bard",
                Name = "Shadow of the Social Cage",
                Title = "Unsichtbare Ketten",
                Description = "Lässt dich alles durch die Augen der anderen sehen.",
                MaxHp = 9,
                Hp = 9,
                AttackPower = 4,
                DefensePower = 5
            },
            _ => GetGenericMinorShadow(level)
        };

        // === Generische Schatten, falls Archetyp noch unklar ist ===
        private static ShadowEnemy GetGenericMinorShadow(int level)
        {
            int baseHp = 5 + level;
            return new ShadowEnemy
            {
                Id = $"Shadow_Generic_L{level}",
                ArchetypeId = "",
                Name = "Unklarer Schatten",
                Title = "Formlose Unsicherheit",
                Description = "Ein undefinierter Aspekt deiner inneren Zweifel.",
                MaxHp = baseHp,
                Hp = baseHp,
                AttackPower = 3 + level / 2,
                DefensePower = 3 + level / 2
            };
        }
    }
}
