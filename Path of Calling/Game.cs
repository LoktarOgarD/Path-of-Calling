using System;
using PathOfCalling.Domain;

namespace PathOfCalling
{
    public class Game
    {
        private Player _player;

        private bool _running = true;

        public void Run()
        {
            // Zentrale Spielschleife (Tag 2 Fokus: Menü)
            while (_running)
            {
                ShowMainMenu();
            }
        }

        private void ShowMainMenu()
        {
            Console.Clear();
            Console.WriteLine("=== Path of Calling ===\n");
            Console.WriteLine("1) Neues Spiel");
            Console.WriteLine("2) Spiel laden (später)");
            Console.WriteLine("3) Beenden");
            Console.Write("\nAuswahl: ");

            string? input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    StartNewGame();
                    break;
                case "2":
                    // Platzhalter für Tag 4/5 (Save/Load)
                    Console.WriteLine("Ladefunktion wird später implementiert.");
                    Pause();
                    break;
                case "3":
                    _running = false;
                    Console.WriteLine("Spiel wird beendet. Auf Wiedersehen.");
                    Pause();
                    break;
                default:
                    Console.WriteLine("Ungültige Eingabe, bitte erneut versuchen.");
                    Pause();
                    break;
            }
        }

        private void StartNewGame()
        {
            Console.Clear();
            Console.WriteLine("=== Neues Spiel ===\n");

            Console.Write("Gib den Namen deines Charakters ein: ");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
                name = "Wanderer";

            // Archetyp wählen
            var archetypes = ArchetypeRepository.GetAll();
            Console.Clear();
            Console.WriteLine("Wähle deinen Archetypen:\n");

            for (int i = 0; i < archetypes.Count; i++)
            {
                var a = archetypes[i];
                Console.WriteLine(
                    $"{i + 1}) {a.Name} ({a.Temperament}) - {a.ShortDescription}");
            }

            Console.Write("\nAuswahl (Zahl): ");
            string? choice = Console.ReadLine();
            if (!int.TryParse(choice, out int index) ||
                index < 1 || index > archetypes.Count)
            {
                Console.WriteLine("Ungültige Auswahl. Zurück zum Hauptmenü.");
                Pause();
                return;
            }

            var selected = archetypes[index - 1];

            _player = new Player
            {
                Name = name,
                ArchetypeId = selected.Id,
                Level = 1
            };

            PlayerArchetypeSetup.ApplyBaseStats(_player);

            Console.Clear();
            Console.WriteLine($"Du bist nun ein(e) {selected.Name}.");
            Console.WriteLine($"Gott / Patron: {selected.GodName}");
            Console.WriteLine($"Temperament: {selected.Temperament}");
            Console.WriteLine("\nStartwerte:");
            foreach (var kv in _player.Stats)
            {
                Console.WriteLine($"- {kv.Key}: {kv.Value}");
            }

            Console.WriteLine("\nDas eigentliche Abenteuer (Persönlichkeitstest, Level, Finalkampf) ");
            Console.WriteLine("wird an den folgenden Projekttagen implementiert.");
            Pause();

            // Hier später:
            // ShowInGameMenu();
        }

        private void Pause()
        {
            Console.WriteLine("\nDrücke eine Taste, um fortzufahren...");
            Console.ReadKey(true);
        }
    }
}
