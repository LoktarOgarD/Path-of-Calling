using System;
using System.Collections.Generic;
using System.Linq;
using PathOfCalling.Domain;

namespace PathOfCalling
{
    public static class PersonalityTestService
    {
        private const string KNIGHT  = "Knight";
        private const string SAMURAI = "Samurai";
        private const string VIKING  = "Viking";
        private const string BARD    = "Bard";

        // 20 Fragen, in 5 Level à 4 Fragen aufgeteilt
        private static readonly List<Question> AllQuestions = new()
        {
            // --- Level 1: Neigung / Energie ---
            new Question
            {
                Id = 1,
                Level = 1,
                GodName = "Thor",
                Text = "Haben Sie oft das Bedürfnis nach neuen Eindrücken, nach Abwechslung und Aufregung?",
                ArchetypeWeights = new Dictionary<string, double> { { VIKING, 1.0 }, { BARD, 0.5 } }
            },
            new Question
            {
                Id = 2,
                Level = 1,
                GodName = "Hachiman",
                Text = "Denken Sie nach, bevor Sie etwas unternehmen?",
                ArchetypeWeights = new Dictionary<string, double> { { SAMURAI, 1.0 }, { KNIGHT, 0.5 } }
            },
            new Question
            {
                Id = 3,
                Level = 1,
                GodName = "Thor",
                Text = "Handeln und sprechen Sie immer schnell, ohne nachzudenken?",
                ArchetypeWeights = new Dictionary<string, double> { { VIKING, 1.0 } }
            },
            new Question
            {
                Id = 4,
                Level = 1,
                GodName = "Hermes",
                Text = "Können Sie leicht Leben in eine langweilige Gesellschaft bringen?",
                ArchetypeWeights = new Dictionary<string, double> { { BARD, 1.0 }, { VIKING, 0.5 } }
            },

            // --- Level 2: Emotion ---
            new Question
            {
                Id = 5,
                Level = 2,
                GodName = "Hermes",
                Text = "Haben Sie oft Stimmungsschwankungen?",
                ArchetypeWeights = new Dictionary<string, double> { { BARD, 0.8 }, { VIKING, 0.6 } }
            },
            new Question
            {
                Id = 6,
                Level = 2,
                GodName = "Hachiman",
                Text = "Fühlen Sie sich oft ohne Grund unglücklich?",
                ArchetypeWeights = new Dictionary<string, double> { { SAMURAI, -0.5 }, { KNIGHT, 0.5 } }
            },
            new Question
            {
                Id = 7,
                Level = 2,
                GodName = "Thor",
                Text = "Waren Sie jemals wütend, wenn jemand Sie übertroffen hat?",
                ArchetypeWeights = new Dictionary<string, double> { { VIKING, 1.0 }, { SAMURAI, 0.3 } }
            },
            new Question
            {
                Id = 8,
                Level = 2,
                GodName = "St. Michael",
                Text = "Machen Sie sich oft Sorgen über Dinge, die Sie gesagt oder getan haben?",
                ArchetypeWeights = new Dictionary<string, double> { { KNIGHT, 0.8 }, { SAMURAI, 0.4 } }
            },

            // --- Level 3: Pflicht ---
            new Question
            {
                Id = 9,
                Level = 3,
                GodName = "St. Michael",
                Text = "Wenn Sie etwas versprechen, halten Sie Ihr Versprechen immer ein?",
                ArchetypeWeights = new Dictionary<string, double> { { KNIGHT, 1.0 }, { SAMURAI, 0.5 } }
            },
            new Question
            {
                Id = 10,
                Level = 3,
                GodName = "St. Michael",
                Text = "Sind Sie immer bereit, einem Bedürftigen zu helfen?",
                ArchetypeWeights = new Dictionary<string, double> { { KNIGHT, 1.0 } }
            },
            new Question
            {
                Id = 11,
                Level = 3,
                GodName = "Hermes",
                Text = "Klatschen Sie manchmal oder verbreiten Sie gerne Gerüchte?",
                ArchetypeWeights = new Dictionary<string, double> { { BARD, 0.8 } }
            },
            new Question
            {
                Id = 12,
                Level = 3,
                GodName = "Hachiman",
                Text = "Bevorzugen Sie Bücher gegenüber Treffen mit Menschen?",
                ArchetypeWeights = new Dictionary<string, double> { { SAMURAI, 1.0 } }
            },

            // --- Level 4: Ruhe / Rückzug ---
            new Question
            {
                Id = 13,
                Level = 4,
                GodName = "Hachiman",
                Text = "Bevorzugen Sie beim Reisen Landschaften gegenüber Gesprächen?",
                ArchetypeWeights = new Dictionary<string, double> { { SAMURAI, 1.0 } }
            },
            new Question
            {
                Id = 14,
                Level = 4,
                GodName = "Hachiman",
                Text = "Sind Sie in Gesellschaft eher still?",
                ArchetypeWeights = new Dictionary<string, double> { { SAMURAI, 0.8 }, { KNIGHT, 0.4 } }
            },
            new Question
            {
                Id = 15,
                Level = 4,
                GodName = "Hachiman",
                Text = "Gehen Sie langsam und bedächtig?",
                ArchetypeWeights = new Dictionary<string, double> { { SAMURAI, 0.7 } }
            },
            new Question
            {
                Id = 16,
                Level = 4,
                GodName = "Hermes",
                Text = "Wären Sie sehr unglücklich, wenn Sie lange ohne soziale Kontakte wären?",
                ArchetypeWeights = new Dictionary<string, double> { { BARD, 1.0 } }
            },

            // --- Level 5: Ausdruck & Sozialität ---
            new Question
            {
                Id = 17,
                Level = 5,
                GodName = "Hermes",
                Text = "Sind Sie gerne in Gesellschaft?",
                ArchetypeWeights = new Dictionary<string, double> { { BARD, 1.0 } }
            },
            new Question
            {
                Id = 18,
                Level = 5,
                GodName = "Hermes",
                Text = "Können Sie Ihre Gefühle in Gesellschaft frei zeigen und ausgelassen feiern?",
                ArchetypeWeights = new Dictionary<string, double> { { BARD, 1.0 }, { VIKING, 0.5 } }
            },
            new Question
            {
                Id = 19,
                Level = 5,
                GodName = "Thor",
                Text = "Interessieren Sie sich für Wetten oder Herausforderungen?",
                ArchetypeWeights = new Dictionary<string, double> { { VIKING, 1.0 }, { BARD, 0.4 } }
            },
            new Question
            {
                Id = 20,
                Level = 5,
                GodName = "Hermes",
                Text = "Können Sie leicht Leben in eine langweilige Gesellschaft bringen?",
                ArchetypeWeights = new Dictionary<string, double> { { BARD, 1.0 } }
            }
        };

        public static void RunTrialsWithLevels(Player player)
        {
            var scores = new Dictionary<string, double>
            {
                { KNIGHT, 0.0 },
                { SAMURAI, 0.0 },
                { VIKING,  0.0 },
                { BARD,    0.0 }
            };

            Console.Clear();
            Console.WriteLine("=== Die Prüfungen der Götter beginnen ===");
            Console.WriteLine("Du wirst 5 Level mit jeweils 4 Fragen und einem inneren Gegner durchlaufen.\n");
            Console.WriteLine("Antwort-Skala: 1 = kaum, 2 = teilweise, 3 = stark.");
            Console.WriteLine("Drücke eine Taste, um zu beginnen...");
            Console.ReadKey(true);

            for (int level = 1; level <= 5; level++)
            {
                RunSingleLevel(player, level, scores);
            }

            // nach allen 5 Levels → Archetyp bestimmen
            var winning = scores.OrderByDescending(kv => kv.Value).First();
            player.ArchetypeId = winning.Key;

            Console.Clear();
            Console.WriteLine("=== Abschluss der Prüfungsfragen ===\n");
            var arch = ArchetypeRepository.GetById(player.ArchetypeId);
            Console.WriteLine($"Die Götter haben entschieden. Dein Archetyp ist: {arch?.Name ?? player.ArchetypeId}");
            Console.WriteLine($"Temperament: {arch?.Temperament}");
            Console.WriteLine($"Patron: {arch?.GodName}");
            Console.WriteLine("\nPunkteverteilung:");
            foreach (var kv in scores)
            {
                Console.WriteLine($"- {kv.Key}: {kv.Value:F1}");
            }

            PlayerArchetypeSetup.ApplyBaseStats(player);

            Console.WriteLine("\nNun stellst du dich deinem persönlichen Schatten...");
            Console.WriteLine("Drücke eine Taste, um den großen Schattenkampf zu beginnen.");
            Console.ReadKey(true);

            var shadow = ShadowEnemyRepository.GetShadowForArchetype(player.ArchetypeId);
            bool shadowDefeated = ShadowCombatService.RunFinalShadowFight(player, shadow);

            if (shadowDefeated && player.UltimateUnlocked)
            {
                Console.WriteLine("\nDu bist bereit für die letzte Prüfung gegen deinen Gott. (Geplant für spätere Version)");
            }
            else if (shadowDefeated)
            {
                Console.WriteLine("\nDu hast den Schatten besiegt, aber deine Ultimate ist noch versiegelt.");
            }
            else
            {
                Console.WriteLine("\nDer Schatten bleibt vorerst bestehen. In dieser MVP-Version endet der Weg hier.");
            }

            Console.WriteLine("\nDrücke eine Taste, um fortzufahren...");
            Console.ReadKey(true);
        }

        private static void RunSingleLevel(Player player, int level, Dictionary<string, double> scores)
        {
            Console.Clear();
            Console.WriteLine($"=== Prüfungslevel {level} von 5 ===\n");

            var questionsForLevel = AllQuestions
                .Where(q => q.Level == level)
                .OrderBy(q => q.Id)
                .ToList();

            foreach (var q in questionsForLevel)
            {
                ProcessQuestion(q, scores);
            }

            Console.WriteLine($"\nDie Götter beobachten dich... Du hast Level {level} der Fragen abgeschlossen.");
            Console.WriteLine("Nun stellt sich dir ein innerer Schatten entgegen.");
            Console.WriteLine("Drücke eine Taste, um den Kampf zu beginnen...");
            Console.ReadKey(true);

            string? leadingArch = GetLeadingArchetype(scores);
            var minorShadow = ShadowEnemyRepository.GetMinorShadowForLevel(level, leadingArch);
            bool won = ShadowCombatService.RunMinorShadowFight(player, minorShadow);

            if (won)
            {
                Console.WriteLine("\nDu hast den inneren Gegner besiegt und erhältst einen Skill-Punkt.");
                AllocateSkillPoint(player);
            }
            else
            {
                Console.WriteLine("\nDu konntest diesen Schatten nicht überwinden. In dieser MVP-Version geht es trotzdem weiter.");
            }

            Console.WriteLine("\nDrücke eine Taste, um zum nächsten Prüfungslevel zu gehen...");
            Console.ReadKey(true);
        }

        private static void ProcessQuestion(Question question, Dictionary<string, double> scores)
        {
            Console.Clear();
            Console.WriteLine($"Frage {question.Id} (Level {question.Level}/5)");
            Console.WriteLine($"{question.GodName} richtet das Wort an dich:\n");
            Console.WriteLine(question.Text);
            Console.WriteLine();

            int answer = AskAnswerOnScale();
            double answerWeight = GetAnswerMultiplier(answer);

            foreach (var kvp in question.ArchetypeWeights)
            {
                string archetypeId = kvp.Key;
                double factor = kvp.Value;

                if (!scores.ContainsKey(archetypeId))
                    scores[archetypeId] = 0.0;

                scores[archetypeId] += answerWeight * factor;
            }
        }

        private static int AskAnswerOnScale()
        {
            while (true)
            {
                Console.WriteLine("Wie stark trifft das auf dich zu?");
                Console.WriteLine("1) Kaum / eher nein");
                Console.WriteLine("2) Teils / kommt vor");
                Console.WriteLine("3) Stark / eindeutig ja");
                Console.Write("> ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value) && value >= 1 && value <= 3)
                    return value;

                Console.WriteLine("Ungültige Eingabe, bitte 1, 2 oder 3 eingeben.\n");
            }
        }

        private static double GetAnswerMultiplier(int answer)
        {
            return answer switch
            {
                1 => 1.0,
                2 => 2.5,
                3 => 4.0,
                _ => 0.0
            };
        }

        private static string? GetLeadingArchetype(Dictionary<string, double> scores)
        {
            var best = scores.OrderByDescending(kv => kv.Value).FirstOrDefault();
            return best.Value > 0 ? best.Key : null;
        }

        private static void AllocateSkillPoint(Player player)
        {
            Console.Clear();
            Console.WriteLine("Du erhältst 1 Skill-Punkt.");
            Console.WriteLine("Wähle eine Eigenschaft, die du stärken möchtest:\n");

            var stats = new List<StatType>
            {
                StatType.Strength,
                StatType.Discipline,
                StatType.Courage,
                StatType.Wisdom,
                StatType.Creativity
            };

            for (int i = 0; i < stats.Count; i++)
            {
                var s = stats[i];
                Console.WriteLine($"{i + 1}) {s} (aktuell: {player.Stats[s]})");
            }

            Console.Write("\nAuswahl (Zahl): ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int index) && index >= 1 && index <= stats.Count)
            {
                var chosen = stats[index - 1];
                player.Stats[chosen] += 1;
                Console.WriteLine($"\n{chosen} wurde um 1 Punkt erhöht. Neuer Wert: {player.Stats[chosen]}");
            }
            else
            {
                Console.WriteLine("\nUngültige Eingabe. Skill-Punkt wurde nicht verteilt.");
            }
        }
    }
}
