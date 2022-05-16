using System.Text.Json;
using System.Text.Json.Serialization;

const string filename = "donjon.json";
Piloter();

static void Piloter()
{
    Console.Clear();
    JeuDonjon donjon;
    // bloc de code pour initialiser
    {
        Position tailleDonjon = DonjonAléatoire(out Position position_heros, out Position[] position_tresors, out Position[] position_blocs, out Position[] position_pièges);
         donjon = new JeuDonjon(tailleDonjon, position_heros, position_blocs, position_tresors, position_pièges);
    }

    if (File.Exists(filename))
    {
        string json = File.ReadAllText(filename);
        donjon = JsonSerializer.Deserialize<JeuDonjon>(json) ?? donjon;
    }
    for (; ; )
    {
        Console.SetCursorPosition(0, 0);
        AfficherDonjon(donjon);
        donjon = DéplacerHéros(donjon, out bool abandon, out bool exit, out bool piège);
        if (donjon.Trésors.Length == 0)
        {
            Console.WriteLine("[AH] Bravo, vous avez réussi la quête!");
            Console.WriteLine("[AH] Au revoir!");
            File.Delete(filename);
            break;
        }
        if (exit)
        {
            string json = JsonSerializer.Serialize(donjon);
            File.WriteAllText(filename, json);
            Environment.Exit(1);
        }
        if (abandon)
        {
            File.Delete(filename);
            Environment.Exit(1);
        }
        if (piège)
        {
            Console.WriteLine("[AH] Hélas, vous êtes tombé dans un piège...");
            Console.WriteLine("[AH] Au revoir!");
            File.Delete(filename);
            Environment.Exit(1);
        }
    }
}

static Position DonjonAléatoire(out Position position_heros, out Position[] position_tresors, out Position[] position_blocs, out Position[] position_pièges)
{
    int largeur = new Random().Next(20, 40);
    int hauteur = new Random().Next(10, 20);
    position_heros = new Position((largeur / 2), (hauteur / 2));
    PositionAléatoireLibre(largeur, hauteur, out Position[] tresors, out Position[] blocs, out Position[] pièges);
    position_blocs = blocs;
    position_tresors = tresors;
    position_pièges = pièges;
    return new Position(largeur, hauteur);
}

static void PositionAléatoireLibre(int larg, int haut, out Position[] trésors, out Position[] blocs, out Position[] pièges)
{
    blocs = new[] {
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
    };

    trésors = new[] {
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
    };

    for (int i = 0; i > 0;)
    {
        foreach (Position b in blocs)
        {
            foreach (Position t in trésors)
            {
                if (t == b || t == new Position((larg / 2), (haut / 2)) || b == new Position((larg / 2), (haut / 2)))
                {
                    trésors = new[] {
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                    };
                }
                else
                    i++;
            }
        }
    }

    pièges = new[] {
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
        new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
    };

    for (int i = 0; i > 0;)
    {
        foreach (Position b in blocs)
        {
            foreach (Position t in trésors)
            {
                foreach (Position p in pièges)
                {
                    if (p == b || p == t || p == new Position((larg / 2), (haut / 2)) || b == new Position((larg / 2), (haut / 2)))
                    {
                        pièges = new[] {
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                            new Position(new Random().Next(0, larg), new Random().Next(0, haut)),
                        };
                    }
                    else
                        i++;
                }
            }
        }
    }
}

static void AfficherDonjon(JeuDonjon donjon)
{
    var (tailleDonjon, héros, blocs, tresors, pièges) = donjon;
    string strdonjon = $"[AH] {tresors.Length} trésor{(tresors.Length > 1 ? "s" : "")} restant{(tresors.Length > 1 ? "s" : "")}    " + "\n";
    strdonjon += "\n";
    strdonjon += $"[AH] {new String('█', (tailleDonjon.largeur * 2) + 4)}\n";
    for (int i = 0; i < tailleDonjon.hauteur; i++)
    {
        strdonjon += "[AH] ██";
        for (int j = 0; j < tailleDonjon.largeur; j++)
        {
            Position pos = new Position(j, i);
            bool positionSuivante = false;
            foreach (Position b in blocs)
                if (b == pos)
                {
                    strdonjon += "██";
                    positionSuivante = true;
                    break;
                }
            if (!positionSuivante) foreach (Position t in tresors)
            {
                if (t == pos)
                {
                    strdonjon += "TT";
                    positionSuivante = true;
                    break;
                }
            }
            if (!positionSuivante) foreach (Position p in pièges)
            {
                if (p == pos)
                {
                    strdonjon += "XX";
                    positionSuivante = true;
                    break;
                }
            }
            if (!positionSuivante) if (héros == pos)
            {
                strdonjon += "HH";
                positionSuivante = true;
            }
            if (!positionSuivante)
                strdonjon += "  ";
        } 
        strdonjon += "██" + "\n";
    }
    strdonjon += $"[AH] {new String('█', (tailleDonjon.largeur * 2) + 4)}\n";
    Console.WriteLine(strdonjon);
}

static JeuDonjon DéplacerHéros(JeuDonjon donjon, out bool abandon, out bool exit, out bool piège)
{
    var (tailleDonjon, position_heros, position_blocs, position_tresors, position_pièges) = donjon;
    piège = false;
    Position mouv = LireDirection(out abandon, out exit);
    if (PositionEstAccessible(tailleDonjon, mouv, position_blocs, position_heros))
    {
        position_heros = new Position(position_heros.largeur + mouv.largeur, position_heros.hauteur + mouv.hauteur);
    }
    foreach (Position t in position_tresors)
    {
        if (position_heros == t)
        {
            var pos_trésor = new List<Position>(position_tresors);
            pos_trésor.RemoveAt(Array.IndexOf(position_tresors, position_heros));
            position_tresors = pos_trésor.ToArray();
        }
    }
    foreach (Position p in position_pièges)
    {
        if (position_heros == p)
            piège = true;
    }
    return new (tailleDonjon, position_heros, position_blocs, position_tresors, position_pièges);
}

static bool PositionEstAccessible(Position tailleDonjon, Position mouvement, Position[] position_blocs, Position position_heros)
{
    Position newPosition = new Position(position_heros.largeur + mouvement.largeur, position_heros.hauteur + mouvement.hauteur);
    foreach (Position b in position_blocs)
    {
        if (newPosition == b)
            return false;
    }
    if ((newPosition.hauteur + 1) == 0 || (newPosition.largeur + 1) == 0 || newPosition.hauteur == tailleDonjon.hauteur || newPosition.largeur == tailleDonjon.largeur)
        return false;
    return true;
}

static Position LireDirection(out bool abandon, out bool exit)
{
    ConsoleKeyInfo keyInfo;
    abandon = false;
    exit = false;
    Position mouvement = new Position(0, 0);
    do
    {
        keyInfo = Console.ReadKey(true);
        if (keyInfo.Key == ConsoleKey.UpArrow)
            mouvement = new Position(0, -1);
        if (keyInfo.Key == ConsoleKey.DownArrow)
            mouvement = new Position(0, 1);
        if (keyInfo.Key == ConsoleKey.LeftArrow)
            mouvement = new Position(-1, 0);
        if (keyInfo.Key == ConsoleKey.RightArrow)
            mouvement = new Position(1, 0);
        if (keyInfo.Key == ConsoleKey.Escape)
        {
            Console.WriteLine("[AH] Nous continuerons plus tard...\n");
            Console.WriteLine("[AH] Au revoir!");
            exit = true;
        }
        if (keyInfo.Key == ConsoleKey.Q)
        {
            Console.WriteLine("[AH] Quel dommage d'abandonner!");
            Console.WriteLine("[AH] Au revoir!");
            abandon = true;
        }
    }
    while (mouvement == new Position(0, 0));
    return mouvement;
}
record Position(int largeur, int hauteur);
record JeuDonjon(Position Taille, Position Héros, Position[] Obstacles, Position[] Trésors, Position[] Pièges);
