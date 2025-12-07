using System.Collections.Generic;

namespace PathOfCalling.Domain
{
    public class PersonalityQuestion
    {
        public int Id { get; set; }
        public string Text { get; set; } = "";
        public string TraitCode { get; set; } = ""; // "E", "I", "L", "N"
        public List<string> RelatedArchetypes { get; set; } = new(); // "Knight","Samurai"...
        public string Scenario { get; set; } = "";
    }

    public static class PersonalityQuestionBank
    {
        public static List<PersonalityQuestion> GetAll()
        {
            return new List<PersonalityQuestion>
            {
                new PersonalityQuestion
                {
                    Id = 1,
                    Text = "Haben Sie oft das Bedürfnis nach neuen Eindrücken, nach Abwechslung und Aufregung?",
                    TraitCode = "E", // Sensation Seeking
                    RelatedArchetypes = new List<string> { "Viking", "Bard" },
                    Scenario = "Dein Charakter steht vor einem Fest in der Stadt. Du kannst entweder bleiben und trainieren (Disziplin) oder dich ins Getümmel stürzen, um neue Kontakte zu knüpfen und Abenteuer zu erleben."
                },
                new PersonalityQuestion
                {
                    Id = 2,
                    Text = "Denken Sie nach, bevor Sie etwas unternehmen?",
                    TraitCode = "I", // Überlegtheit
                    RelatedArchetypes = new List<string> { "Samurai", "Knight" },
                    Scenario = "Vor einer Schlacht musst du entscheiden: sofort angreifen oder zuerst die Lage analysieren. Samurai und Ritter gewinnen XP für Geduld und Strategie."
                },
                new PersonalityQuestion
                {
                    Id = 3,
                    Text = "Wenn Sie etwas versprechen, halten Sie Ihr Versprechen immer ein?",
                    TraitCode = "L", // Gewissenhaftigkeit
                    RelatedArchetypes = new List<string> { "Samurai", "Knight" },
                    Scenario = "Ein Dorfbewohner bittet um Hilfe. Du hast andere Pläne, aber deine Ehre steht auf dem Spiel. Halte dein Versprechen für XP in Pflichtbewusstsein."
                },
                new PersonalityQuestion
                {
                    Id = 4,
                    Text = "Haben Sie oft Stimmungsschwankungen?",
                    TraitCode = "N", // Emotionale Instabilität
                    RelatedArchetypes = new List<string> { "Bard", "Viking" },
                    Scenario = "Dein Charakter erlebt eine Niederlage. Du kannst entweder deine Emotionen in ein Lied verwandeln (Bard) oder in einen Kampfkanal (Viking)."
                },
                new PersonalityQuestion
                {
                    Id = 5,
                    Text = "Handeln und sprechen Sie immer schnell, ohne nachzudenken?",
                    TraitCode = "E", // Impulsivität
                    RelatedArchetypes = new List<string> { "Viking" },
                    Scenario = "Ein Feind provoziert dich. Du kannst sofort angreifen oder eine Falle stellen. Viking erhält XP für schnelle Reaktion."
                },
                new PersonalityQuestion
                {
                    Id = 6,
                    Text = "Fühlen Sie sich oft ohne Grund unglücklich?",
                    TraitCode = "N", // Angst
                    RelatedArchetypes = new List<string> { "Samurai", "Bard" },
                    Scenario = "Dein Charakter ist niedergeschlagen. Du kannst meditieren (Samurai) oder Trost bei Freunden suchen (Bard)."
                },
                new PersonalityQuestion
                {
                    Id = 7,
                    Text = "Interessieren Sie sich für Wetten oder Herausforderungen?",
                    TraitCode = "E", // Risikofreude
                    RelatedArchetypes = new List<string> { "Viking", "Bard" },
                    Scenario = "Ein Glücksspiel im Gasthaus. Du kannst teilnehmen oder ablehnen. Viking und Bard erhalten XP für Mut und soziale Interaktion."
                },
                new PersonalityQuestion
                {
                    Id = 8,
                    Text = "Waren Sie jemals wütend, wenn jemand Sie übertroffen hat?",
                    TraitCode = "N", // Aggression
                    RelatedArchetypes = new List<string> { "Viking", "Samurai" },
                    Scenario = "Ein Krieger übertrifft dich im Wettkampf. Du kannst trainieren (Samurai) oder ihn herausfordern (Viking)."
                },
                new PersonalityQuestion
                {
                    Id = 9,
                    Text = "Machen Sie sich oft Sorgen über Dinge, die Sie gesagt oder getan haben?",
                    TraitCode = "N", // Schuld/Angst
                    RelatedArchetypes = new List<string> { "Knight" },
                    Scenario = "Du hast einen Fehler im Kampf gemacht. Du kannst Buße tun (Knight) oder ignorieren. XP für Ehre und Pflicht."
                },
                new PersonalityQuestion
                {
                    Id = 10,
                    Text = "Bevorzugen Sie Bücher gegenüber Treffen mit Menschen?",
                    TraitCode = "I", // Introversion
                    RelatedArchetypes = new List<string> { "Samurai" },
                    Scenario = "Du hast Freizeit. Du kannst meditieren oder eine Feier besuchen. Samurai erhält XP für Fokus."
                },
                new PersonalityQuestion
                {
                    Id = 11,
                    Text = "Sind Sie gerne in Gesellschaft?",
                    TraitCode = "E", // Geselligkeit
                    RelatedArchetypes = new List<string> { "Bard" },
                    Scenario = "Ein Fest beginnt. Du kannst auftreten (Bard) oder allein bleiben. XP für soziale Interaktion."
                },
                new PersonalityQuestion
                {
                    Id = 12,
                    Text = "Haben Sie manchmal Gedanken, die Sie verbergen möchten?",
                    TraitCode = "L", // Unvollkommenheit
                    RelatedArchetypes = new List<string> { "Bard" },
                    Scenario = "Du kannst deine Geheimnisse in ein Lied verwandeln oder sie für Intrigen nutzen. XP für Kreativität."
                },
                new PersonalityQuestion
                {
                    Id = 13,
                    Text = "Bevorzugen Sie beim Reisen Landschaften gegenüber Gesprächen?",
                    TraitCode = "I", // Kontemplation
                    RelatedArchetypes = new List<string> { "Samurai" },
                    Scenario = "Du reist durch ein fremdes Land. Du kannst meditieren oder neue Freunde finden. Samurai erhält XP für Fokus."
                },
                new PersonalityQuestion
                {
                    Id = 14,
                    Text = "Sind Sie immer bereit, einem Bedürftigen zu helfen?",
                    TraitCode = "L", // Altruismus
                    RelatedArchetypes = new List<string> { "Knight" },
                    Scenario = "Ein Dorfbewohner bittet um Hilfe. Du kannst helfen oder ablehnen. XP für Pflichtbewusstsein."
                },
                new PersonalityQuestion
                {
                    Id = 15,
                    Text = "Können Sie Ihre Gefühle in Gesellschaft frei zeigen und ausgelassen feiern?",
                    TraitCode = "E", // Enthemmung
                    RelatedArchetypes = new List<string> { "Bard", "Viking" },
                    Scenario = "Ein Fest beginnt. Du kannst tanzen (Bard) oder kämpfen (Viking). XP für Ausdruckskraft."
                },
                new PersonalityQuestion
                {
                    Id = 16,
                    Text = "Sind Sie in Gesellschaft eher still?",
                    TraitCode = "I", // Zurückhaltung
                    RelatedArchetypes = new List<string> { "Samurai", "Knight" },
                    Scenario = "Du bist in einer Versammlung. Du kannst zuhören oder sprechen. Samurai und Knight erhalten XP für Ruhe."
                },
                new PersonalityQuestion
                {
                    Id = 17,
                    Text = "Klatschen Sie manchmal?",
                    TraitCode = "L", // niedrige Gewissenhaftigkeit / Gossip
                    RelatedArchetypes = new List<string> { "Bard" },
                    Scenario = "Du kannst Gerüchte verbreiten oder sie in ein Lied verwandeln. XP für Kreativität."
                },
                new PersonalityQuestion
                {
                    Id = 18,
                    Text = "Gehen Sie langsam und bedächtig?",
                    TraitCode = "I", // niedrige Aktivität / Ruhe
                    RelatedArchetypes = new List<string> { "Samurai" },
                    Scenario = "Du kannst langsam gehen (Fokus) oder rennen (Viking). XP für Ruhe."
                },
                new PersonalityQuestion
                {
                    Id = 19,
                    Text = "Wären Sie sehr unglücklich, wenn Sie lange Zeit ohne soziale Kontakte wären?",
                    TraitCode = "E", // soziale Bedürftigkeit
                    RelatedArchetypes = new List<string> { "Bard" },
                    Scenario = "Du bist isoliert. Du kannst ein Lied schreiben oder Freunde suchen. XP für soziale Interaktion."
                },
                new PersonalityQuestion
                {
                    Id = 20,
                    Text = "Können Sie leicht Leben in eine langweilige Gesellschaft bringen?",
                    TraitCode = "E", // Dominanz / soziale Energie
                    RelatedArchetypes = new List<string> { "Bard" },
                    Scenario = "Du kannst eine Rede halten oder Musik spielen. XP für Inspiration."
                }
            };
        }
    }
}
