using System;
using PathOfCalling.Domain;

namespace PathOfCalling
{
    public class Game
    {
        private Player? _currentPlayer;

        public void Run()
        {
            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== PATH OF CALLING ===");
                Console.WriteLine();
                Console.WriteLine("1) Neues Spiel");
                Console.WriteLine("2) Fortsetzen (Letzter Spielstand)");
                Console.WriteLine("3) Einstellungen");
                Console.WriteLine("4) Beenden");
                Console.WriteLine();
                Console.Write("Auswahl: ");

                var input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        StartNewGame();
                        break;
                    case "2":
                        ContinueGame();
                        break;
                    case "3":
                        ShowSettings();
                        break;
                    case "4":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Ungültige Eingabe. Drücke eine Taste...");
                        Console.ReadKey(true);
                        break;
                }
            }

            Console.Clear();
            Console.WriteLine("Danke fürs Spielen. Bis bald auf deinem Path of Calling.");
            Console.WriteLine("Drücke eine Taste zum Beenden...");
            Console.ReadKey(true);
        }

        private void StartNewGame()
        {
            Console.Clear();
            Console.WriteLine("=== Neues Spiel ===\n");
            Console.Write("Gib den Namen deines Charakters ein: ");
            string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
                name = "Wanderer";

            _currentPlayer = new Player
            {
                Name = name,
                Level = 1,
                ArchetypeId = ""
            };

            Console.WriteLine($"\nWillkommen, {name}. Die Götter beobachten dich...");
            Console.WriteLine("Drücke eine Taste, um die Prüfungen zu beginnen.");
            Console.ReadKey(true);

            // 👉 Hier läuft dein 5-Level-Persönlichkeitstest + Schattenkämpfe
            PersonalityTestService.RunTrialsWithLevels(_currentPlayer);

            // Nach dem Test direkt speichern
            SaveService.SavePlayer(_currentPlayer);

            Console.WriteLine("\nDein Fortschritt wurde gespeichert.");
            Console.WriteLine("Drücke eine Taste, um ins Hauptmenü zurückzukehren...");
            Console.ReadKey(true);
        }

        private void ContinueGame()
        {
            Console.Clear();
            Console.WriteLine("=== Spiel fortsetzen ===\n");

            var loaded = SaveService.LoadPlayer();
            if (loaded == null)
            {
                Console.WriteLine("Kein gültiger Spielstand gefunden.");
                Console.WriteLine("Starte zuerst ein neues Spiel.");
                Console.WriteLine("\nDrücke eine Taste, um zurückzukehren...");
                Console.ReadKey(true);
                return;
            }

            _currentPlayer = loaded;

            Console.WriteLine($"Willkommen zurück, {_currentPlayer.Name}.");
            Console.WriteLine($"Archetyp: {_currentPlayer.ArchetypeId}, Level: {_currentPlayer.Level}");
            Console.WriteLine("\n(An dieser Stelle kannst du später entscheiden: weiterer Test, Kampagne, Final God Trial usw.)");
            Console.WriteLine("Drücke eine Taste, um ins Hauptmenü zurückzukehren...");
            Console.ReadKey(true);
        }

        private void ShowSettings()
        {
            Console.Clear();
            Console.WriteLine("=== Einstellungen ===\n");
            Console.WriteLine("(Für das MVP nur Platzhalter.)");
            Console.WriteLine("- Später: Textgeschwindigkeit, Farben, Sprache etc.");
            Console.WriteLine("\nDrücke eine Taste, um zurückzukehren...");
            Console.ReadKey(true);
        }
    }
}
