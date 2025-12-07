using System;
using System.Collections.Generic;
using System.Linq;

namespace PathOfCalling.Domain
{
    public static class PersonalityTestService
    {
        /// <summary>
        /// Führt den Persönlichkeitstest durch, sammelt Punkte für Archetypen
        /// und weist dem Spieler am Ende den dominanten Archetyp zu.
        /// </summary>
        public static void RunPersonalityTestAndAssignArchetype(Player player)
        {
            Console.Clear();
            Console.WriteLine("=== Persönlichkeitstest – Die Götter stellen dir 20 Fragen ===\n");
            Console.WriteLine("Antworte ehrlich. Deine Antworten bestimmen deinen Archetypen.\n");
            Console.WriteLine("Antwort-Skala:");
            Console.WriteLine("1) Trifft kaum zu / eher zurückhaltend");
            Console.WriteLine("2) Trifft teilweise zu");
            Console.WriteLine("3) Trifft stark zu / entspricht dir sehr");
            Console.WriteLine("\nDrücke eine Taste, um zu beginnen...");
            Console.ReadKey(true);

            var questions = PersonalityQuestionBank.GetAll();

            // Scores pro Archetyp
            var scores = new Dictionary<string, double>
            {
                { "Knight", 0.0 },
                { "Samurai", 0.0 },
                { "Viking", 0.0 },
                { "Bard", 0.0 }
            };

            foreach (var q in questions)
            {
                AskQuestionAndScore(q, scores);
            }

            // Archetyp mit höchstem Score bestimmen
            var best = scores
                .OrderByDescending(kv => kv.Value)
                .First();

            player.ArchetypeId = best.Key;

            Console.Clear();
            var archetype = ArchetypeRepository.GetById(player.ArchetypeId);
            Console.WriteLine("=== Auswertung des Persönlichkeitstests ===\n");
            Console.WriteLine($"Dominanter Archetyp: {archetype?.Name ?? player.ArchetypeId}");
            Console.WriteLine($"Temperament: {archetype?.Temperament}");
            Console.WriteLine($"Patron / Gott: {archetype?.GodName}");
            Console.WriteLine();

            Console.WriteLine("Punkteverteilung:");
            foreach (var kv in scores)
            {
                Console.WriteLine($"- {kv.Key}: {kv.Value:F1}");
            }

            Console.WriteLine("\nDeine Basiswerte werden nun an deinen Archetyp angepasst.");
            PlayerArchetypeSetup.ApplyBaseStats(player);

            Console.WriteLine("\nDrücke eine Taste, um fortzufahren...");
            Console.ReadKey(true);
        }

        private static void AskQuestionAndScore(
            PersonalityQuestion question,
            Dictionary<string, double> scores)
        {
            Console.Clear();

            // Gott auswählen – erster zugehöriger Archetyp
            string godName = "Die Götter";
            if (question.RelatedArchetypes.Count > 0)
            {
                var archId = question.RelatedArchetypes[0];
                var deity = DeityRepository.GetByArchetype(archId);
                if (deity != null)
                    godName = deity.Name;
            }

            Console.WriteLine($"Frage {question.Id}/20");
            Console.WriteLine($"{godName} stellt dir eine Frage:\n");
            Console.WriteLine(question.Text);
            Console.WriteLine();
            Console.WriteLine("Szenario:");
            Console.WriteLine(question.Scenario);
            Console.WriteLine();

            int answer = AskAnswerScale();

            // XP-Logik übernehmen: 1.0 / 2.5 / 4.0
            double weight = answer switch
            {
                1 => 1.0,
                2 => 2.5,
                3 => 4.0,
                _ => 0.0
            };

            foreach (var archId in question.RelatedArchetypes)
            {
                if (!scores.ContainsKey(archId))
                    scores[archId] = 0.0;

                scores[archId] += weight;
            }
        }

        private static int AskAnswerScale()
        {
            while (true)
            {
                Console.WriteLine("Wie stark trifft das auf dich zu?");
                Console.WriteLine("1) Kaum / eher nein");
                Console.WriteLine("2) Teils / kommt vor");
                Console.WriteLine("3) Stark / eindeutig ja");
                Console.Write("> ");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out int value)
                    && value >= 1 && value <= 3)
                {
                    return value;
                }

                Console.WriteLine("Ungültige Eingabe, bitte 1, 2 oder 3 eingeben.\n");
            }
        }
    }
}
