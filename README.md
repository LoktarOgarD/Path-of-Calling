# Path of Calling – Konsolen-RPG mit psychologischem Test

**Path of Calling** ist eine C#-Konsolenanwendung, die einen psychologischen Persönlichkeitstest
mit Archetypen, Göttern und realen Aufgaben aus dem echten Leben verbindet.

Der Spieler beantwortet 20 Fragen, durchläuft 5 Prüfungslevel mit inneren Schattengegnern
und erhält am Ende einen Archetyp (Knight, Samurai, Viking, Bard) mit passendem Kampfstil.
Erst wenn der Spieler seine realen Aufgaben erfüllt, kann er seine Ultimate-Fähigkeit freischalten.

## Überblick
Ein interaktives Selbstentwicklungs-Spiel, bei dem reale Aufgaben die Stärke deines Charakters bestimmen.
<img width="1536" height="1024" alt="Path Of Calling DIagrams" src="https://github.com/user-attachments/assets/c1c9e5ff-abe2-405d-b041-36cbc626d015" />## Überblick

**Kurz gesagt:**  
Path of Calling ist ein kleines Selbstentwicklungs-Spiel.  
Du spielst einen Charakter, aber deine echte Arbeit im realen Leben
macht deinen Charakter stärker.

**Kern-Idee:**

- Du machst einen **Persönlichkeitstest** → bekommst einen **Archetyp**
- Jeder Archetyp gehört zu einem **Gott** (St. Michael, Hachiman, Thor, Hermes)
- Du kämpfst in der Konsole gegen **innere Schatten**
- Du kannst **echte Aufgaben im Alltag** benutzen, um Boni im Kampf zu bekommen
- Nur wer seine Aufgaben wirklich macht, bekommt am Ende seine **Ultimate-Fähigkeit**

  ## Gameplay-Loop (Ablauf des Spiels)

1. **Neues Spiel starten**
   - Im Hauptmenü kannst du ein neues Spiel starten.
   - Du gibst deinen Namen ein.
   - Dein Charakter startet mit Basiswerten:
     - Strength
     - Discipline
     - Courage
     - Wisdom
     - Creativity

2. **5 Prüfungslevel mit je 4 Fragen (insgesamt 20 Fragen)**  
   - Die Fragen sind in 5 Level aufgeteilt (Level 1–5, jeweils 4 Fragen).
   - Jede Frage wird im Namen einer Gottheit gestellt (z. B. Thor, Hachiman, Hermes, St. Michael).
   - Deine Antworten geben im Hintergrund Punkte auf die Archetypen:
     - Knight
     - Samurai
     - Viking
     - Bard

3. **Nach jedem Level: Kampf gegen einen inneren Schatten**
   - Nach 4 Fragen kommt ein kleiner Schatten-Kampf.
   - Das Kampfsystem ist würfelbasiert (W6).
   - In jeder Runde wählst du eine **Haltung**:
     - Aggressiv → mehr Angriffswürfel
     - Ausgeglichen → gleiche Anzahl Angriff / Verteidigung
     - Defensiv → mehr Verteidigungswürfel
   - Der Schaden wird berechnet aus:
     - deinem Würfelwurf,
     - deinen Stats (Strength / Discipline),
     - möglichen Bonuspunkten.

   - Einmal pro Kampf kannst du sagen:  
     **„Ich habe heute eine reale Aufgabe erledigt.“**
     - Dann bekommst du **+2 permanente Bonuspunkte** für diesen Kampf.
     - Du kannst wählen:
       - +2 Angriff  
       - oder +2 Verteidigung  
       - oder +1 Angriff und +1 Verteidigung

4. **Nach 20 Fragen: Archetyp-Bestimmung**
   - Alle Antworten werden ausgewertet.
   - Der Archetyp mit den meisten Punkten wird dein Weg:
     - **Knight**, **Samurai**, **Viking** oder **Bard**
   - `PlayerArchetypeSetup` setzt deine Startwerte so,
     dass sie zu deinem Archetyp passen
     (z. B. Ritter mehr Verteidigung, Wikinger mehr Angriff).

5. **Finaler Schattenkampf (großer Schatten deines Archetyps)**
   - Du kämpfst jetzt gegen den großen Schatten deines Archetyps:
     - Knight → The Sloth  
     - Samurai → The Chaos  
     - Viking → The Weakling  
     - Bard → The Judge
   - In diesem Kampf kannst du deine **Archetypen-Angriffe** benutzen:
     - Light
     - Heavy
     - Skill
   - Wenn du gewinnst, fragt das Spiel dich:
     > „Hast du deine reale Prüfungsaufgabe (Deep Quest) heute wirklich erfüllt?“

   - Deine Antwort:
     - **Ja** → `UltimateUnlocked = true`  
       → du schaltest deine Ultimate-Fähigkeit frei (für spätere Kämpfe, z. B. Gott-Kampf)
     - **Nein** → keine Ultimate, der Weg ist noch nicht zu Ende

6. **(Ausblick) Gott-Prüfung**
   - In einer späteren Version soll ein **Final God Trial** kommen.
   - Dort kämpfst du mit deiner Ultimate-Fähigkeit gegen den Gott deines Archetyps.
  
     ## Psychologischer Test: 20 Fragen (Kurzbeschreibung)

Der Test besteht aus 20 Fragen. Jede Frage gibt im Hintergrund Punkte
für einen oder mehrere Archetypen (Knight, Samurai, Viking, Bard).

Die Fragen bauen auf einfachen psychologischen Dimensionen auf:

- **E** – Extraversion / Sensation Seeking / Risikofreude  
- **I** – Introversion / Nachdenken / Ruhe  
- **L** – Gewissenhaftigkeit / Pflicht / Moral  
- **N** – emotionale Reaktion (Stimmung, Angst, Schuld)

Zu jeder Frage gibt es:

- eine kurze Beschreibung,
- ein Fantasy-Szenario (z. B. Fest, Schlacht, Dorfbewohner, Reise),
- eine XP-Logik, z. B.:
  - Antwort 1 = 1.0 Punkt
  - Antwort 2 = 2.5 Punkte
  - Antwort 3 = 4.0 Punkte

Im Code sind die Fragen in **5 Level à 4 Fragen** organisiert.
Die Logik steckt in `PersonalityTestService`.

> **Hinweis:**  
> Die vollständige Liste der 20 Fragen liegt in:
> - `docs/Fragenkatalog.md` (optional)
> - oder direkt im Code in `PersonalityTestService` / `PersonalityQuestion`.

## Technische Struktur

- **Sprache/Runtime:** C# (.NET)  
- **Typ:** Konsolen-Anwendung

### Wichtige Klassen und Dateien

- `Program` / `Game`
  - Einstiegspunkt ins Spiel.
  - Hauptmenü: Neues Spiel, (später) Fortsetzen, Beenden.

- `Player`, `StatType`, `PlayerArchetypeSetup`
  - `Player`: Name, ArchetypeId, Level, Stats, UltimateUnlocked.
  - Stats:
    - Strength
    - Discipline
    - Courage
    - Wisdom
    - Creativity
  - `PlayerArchetypeSetup`: verteilt die Startpunkte je nach Archetyp.

- `PersonalityQuestion`, `Question`, `PersonalityTestService`
  - Logik des Persönlichkeitstests.
  - 20 Fragen in 5 Leveln.
  - Nach jedem Level: Schattenkampf.
  - Am Ende: Archetyp wird bestimmt.

- `Archetype`, `ArchetypeRepository`
  - Daten zu Knight, Samurai, Viking, Bard.

- `Deity`, `DeityRepository`
  - Verknüpft jeden Archetyp mit seinem Gott.

- `ShadowEnemy`, `ShadowEnemyRepository`
  - Kleine Schatten (für Level 1–4) und großer Archetyp-Schatten.
  - Beispiel:  
    - Knight → Sloth (Lähmung)  
    - Samurai → Chaos  
    - Viking → Weakling (Angst, Schwäche)  
    - Bard → Judge (Urteil, Scham)

- `ShadowCombatService`
  - Kampfsystem mit W6-Würfeln gegen Schatten.
  - Pro Runde Haltung wählen (angriffslastig, ausgeglichen, defensiv).
  - Einmal pro Kampf: echte Aufgabe einlösen → +2 Punkte.

- `CombatMove`, `ArchetypeCombatRepository`
  - Attacken pro Archetyp:
    - Light, Heavy, Skill, (Ultimate).
  - Im finalen Schattenkampf werden diese Moves genutzt
    (Ultimate nur freigeschaltet, wenn `UltimateUnlocked == true` – für späteren Gott-Kampf).

- `SaveService` (wenn vorhanden)
  - Einfaches Speichern und Laden von Spielstand-Daten
    (z. B. Name, Archetyp, Stats, Fortschritt).

---

## Entwicklung & Herausforderungen (Tag 1–6)

### Tag 1 – Idee & Grundstruktur

- Ich habe die Grund-Idee entwickelt:
  - psychologischer Test → Archetyp → Gott → Schatten → reale Aufgaben.
- Entscheidung:
  - C# Konsolen-App,
  - Fokus auf Logik statt Grafik.
- Schwierigkeit:
  - Viele Ideen (Hades, Inuyasha, South Park, Psychologie, Self-Improvement)
    auf ein kleines, machbares Projekt herunterbrechen.

---

### Tag 2 – Menü & Game-Flow

- Ich habe die `Game`-Klasse erstellt und ein Hauptmenü gebaut.
- Funktionen:
  - Neues Spiel starten,
  - Beenden,
  - Platz für später: Fortsetzen, Einstellungen.
- Schwierigkeit:
  - Den Code so zu strukturieren, dass später neue Module (Test, Kämpfe, Save-System)
    leicht eingebaut werden können.

---

### Tag 3 – Persönlichkeitstest

- Ich habe die 20 Fragen geschrieben, mit psychologischen Dimensionen (E/I/L/N).
- Im Code:
  - `PersonalityQuestion`, `Question`, `PersonalityTestService`.
  - Die Fragen sind in 5 Leveln organisiert.
- Nach jedem Level gibt es einen kleinen Schattenkampf.
- Schwierigkeit:
  - Die Fragen so zu bauen, dass sie **logisch** zu Knight/Samurai/Viking/Bard passen,
    aber trotzdem leicht verständlich sind.

---

### Tag 4 – Archetypen, Götter und Schatten

- Ich habe die 4 Archetypen als eigene Daten angelegt:
  - Knight, Samurai, Viking, Bard.
- Dazu passende Götter:
  - St. Michael, Hachiman, Thor, Hermes.
- Ich habe die Spielerstruktur erweitert:
  - Stats, ArchetypeId, UltimateUnlocked.
- Dazu kam das Schatten-System:
  - Kleine Schatten pro Level,
  - großer Archetyp-Schatten.
- Schwierigkeit:
  - Die Schatten so zu formulieren, dass sie wirklich wie innere Schwächen wirken
    (z. B. Lähmung, Chaos, Angst, Urteil).

---

### Tag 5 – Würfel-Kampfsystem

- Ich habe `ShadowCombatService` geschrieben.
- Pro Runde:
  - Haltung wählen: aggressiv / ausgeglichen / defensiv.
  - Mit einem W6 (oder mehreren Slots) werden Angriff und Verteidigung berechnet.
- Einmal pro Kampf:
  - Der Spieler kann sagen, dass er eine echte Aufgabe erledigt hat.
  - Dafür gibt es +2 Bonuspunkte für den Rest des Kampfes.
- Schwierigkeit:
  - Kampf sollte nicht wie ein Casino wirken,
    sondern mit Entscheidungen + realen Aufgaben verbunden sein.

---

### Tag 6 – Archetypen-Angriffe & Ultimate-Freischaltung

- Ich habe `CombatMove` und `ArchetypeCombatRepository` erstellt:
  - Light, Heavy, Skill, Ultimate pro Archetyp.
- Im finalen Schattenkampf kann der Spieler diese Moves nutzen.
- Nach dem Sieg über den großen Schatten:
  - Das Spiel fragt die „Deep Quest“-Frage.
  - Nur wenn der Spieler ehrlich sagt, dass er seine reale Aufgabe erfüllt hat,
    wird `UltimateUnlocked` auf `true` gesetzt und seine Ultimate benannt.
- Schwierigkeit:
  - Unter Zeitdruck trotzdem ein sauberes System zu bauen,
    das später für einen Gott-Kampf weiterverwendet werden kann.

---

## Installation & Start

1. Projekt herunterladen oder klonen.
2. In einer IDE öffnen:
   - Visual Studio,
   - Rider oder
   - VS Code mit C#-Extension.
3. Projekt bauen und starten:
   - über die IDE oder
   - über die Konsole:

   ```bash
   dotnet run


## Psychologischer Test: 20 Fragen

[Uploading Fragenkatalog_PathOfCalling.pdf…]()

Hans Eysenck persönlichkeitsmodell test
https://personalio.org/email



---
## Pantheon Details 

[Pantheon.docx](https://github.com/user-attachments/files/24071059/Pantheon.docx)

  ## Technische Struktur

- **Sprache/Runtime**: C# (.NET)
- **Projekt-Typ**: Konsolenanwendung

Wichtige Klassen/Module:

- `Program` / `Game`  
  Einstiegspunkt, Hauptmenü (Neues Spiel, ggf. Fortsetzen, Beenden).

- `Player`, `StatType`, `PlayerArchetypeSetup`  
  Repräsentation des Spielers, 5 Kernwerte (Strength, Discipline, Courage, Wisdom, Creativity),
  Zuweisung der Startwerte je nach Archetyp.

- `PersonalityQuestion`, `Question`, `PersonalityTestService`  
  20 Fragen, gruppiert in 5 Level à 4 Fragen.  
  Nach jedem Level: Auswertung + Kampf gegen einen kleinen Schatten.

- `Archetype`, `ArchetypeRepository`  
  Definition der vier Archetypen (Knight, Samurai, Viking, Bard).

- `Deity`, `DeityRepository`  
  Verknüpfung der Archetypen mit den Göttern (St. Michael, Hachiman, Thor, Hermes).

- `ShadowEnemy`, `ShadowEnemyRepository`  
  Kleine Schatten (Level 1–4) und großer Archetyp-Schatten nach der finalen Prüfung.

- `ShadowCombatService`  
  Würfelbasiertes Kampfsystem gegen Schatten:
  - Haltungen (aggressiv, ausgeglichen, defensiv),
  - W6-Würfe für Angriff und Verteidigung,
  - Einmaliger Real-Life-Bonus (+2 Punkte).

- `ArchetypeCombatRepository`, `CombatMove`  
  vordefinierte Angriffe und Fähigkeiten pro Archetyp (Light, Heavy, Skill, Ultimate).
  Werden im finalen Schattenkampf verwendet.

  ## Gameplay-Loop

1. **Neues Spiel starten**
   - Spieler gibt seinen Namen ein.
   - Start mit Basiswerten.

2. **5 Prüfungslevel mit je 4 Fragen**
   - Jede Frage wird im Namen eines Gottes gestellt.
   - Antworten erhöhen die versteckten Scores der Archetypen.

3. **Nach jedem Level: Kampf gegen einen inneren Schatten**
   - Würfel-basiertes System (W6).
   - Spieler verteilt seinen Fokus pro Runde auf Angriff/Verteidigung.
   - Optional: reale Aufgabe melden → +2 permanente Bonuspunkte.

4. **Nach 20 Fragen: Archetyp-Bestimmung**
   - Höchster Score entscheidet zwischen Knight / Samurai / Viking / Bard.
   - `PlayerArchetypeSetup` weist passende Startwerte zu.

5. **Finaler Schattenkampf**
   - Kampf gegen den großen Schatten des Archetyps.
   - Nutzung der Archetypen-Fähigkeiten (Light/Heavy/Skill).
   - Bei Sieg → Abfrage einer realen Deep-Quest.
   - Nur bei bestätigter Aufgabe → `UltimateUnlocked = true`.

6. **(Ausblick) Gott-Prüfung**
   - In einem weiteren Schritt kann ein Final God Trial implementiert werden,
     bei dem der Spieler mit seiner Ultimate-Fähigkeit gegen den Gott kämpft.


## Übersichtstabelle
| Klasse | Temperament | Attribute | Gott | Beispiel-Quests |
|--------|-------------|-----------|------|------------------|
| Knight | Melancholic | Ehre, Pflicht, Ausdauer | St. Michael | Hilf Bedürftigen, Verteidige die Schwachen |
| Samurai | Phlegmatic | Disziplin, Fokus, Reinheit | Hachiman | Meditation, Kampfkunst, tägliche Rituale |
| Viking | Choleric | Stärke, Mut, Entschlossenheit | Thor | Wettkämpfe, Abenteuer, körperliche Herausforderungen |
| Bard | Sanguine | Inspiration, Kreativität, soziale Bindungen | Hermes | Networking, Diplomatie, Reisen |

## Diagramme
![XP Flow]
<img width="2244" height="1050" alt="JSON-Vorschau" src="https://github.com/user-attachments/assets/3e45db28-7277-4df5-aa50-15519587923e" />

![Temperament Wheel](https://github.com/user-attachments/assets/04f6c3a8-525c-490d-beb9-10ead37deea6)



