Piloter();

static void Piloter()
{
    Console.Clear();
    int nbTrésors = 10;
    Position tailleDonjon = DonjonAléatoire(out Position position_heros, out Position[] position_tresors, out Position[] position_blocs);
    for (; ; )
    {
        Console.SetCursorPosition(0, 0);
        AfficherDonjon(tailleDonjon, position_tresors, position_blocs, position_heros, nbTrésors);
        position_heros = DéplacerHéros(ref position_tresors, position_blocs, tailleDonjon, position_heros, ref nbTrésors);
        if (nbTrésors == 0)
        {
            Console.WriteLine("[AH] Bravo, vous avez réussi la quête!");
            Console.WriteLine("[AH] Au revoir!");
            break;
        }
    }
}

static Position DonjonAléatoire(out Position position_heros, out Position[] position_tresors, out Position[] position_blocs)
{
    int largeur = new Random().Next(20, 40);
    int hauteur = new Random().Next(10, 20);
    position_heros = new Position((largeur / 2), (hauteur / 2));
    PositionAléatoireLibre(largeur, hauteur, out Position[] tresors, out Position[] blocs);
    position_blocs = blocs;
    position_tresors = tresors;
    return new Position(largeur, hauteur);
}

static void PositionAléatoireLibre(int larg, int haut, out Position[] trésors, out Position[] blocs)
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
}

static void AfficherDonjon(Position tailleDonjon, Position[] tresors, Position[] blocs, Position héros, int nombre_tresors)
{
    Console.WriteLine($"[AH] {nombre_tresors} trésor{(nombre_tresors > 1 ? "s" : "")} restant{(nombre_tresors > 1 ? "s" : "")}                ");
    Console.WriteLine();
    Console.WriteLine($"[AH] {new String('█', (tailleDonjon.largeur * 2) + 4)}");
    for (int i = 0; i < tailleDonjon.hauteur; i++)
    {
        Console.Write("[AH] ██");
        for (int j = 0; j < tailleDonjon.largeur; j++)
        {
            Position pos = new Position(j, i);
            bool positionSuivante = false;
            foreach (Position b in blocs)
                if (b == pos)
                {
                    Console.Write("██");
                    positionSuivante = true;
                    break;
                }
            foreach (Position t in tresors)
            {
                if (t == pos)
                {
                    Console.Write("TT");
                    positionSuivante = true;
                    break;
                }
            }
            if (héros == pos)
            {
                Console.Write("HH");
                positionSuivante = true;
            }
            if (!positionSuivante)
                Console.Write("  ");
        }
        Console.Write("██");
        Console.Write("\n");
    }
    Console.WriteLine($"[AH] {new String('█', (tailleDonjon.largeur * 2) + 4)}");
}

static Position DéplacerHéros(ref Position[] position_tresors, Position[] position_blocs, Position tailleDonjon, Position position_heros, ref int nombre_trésors)
{
    Position mouv = LireDirection();
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
            nombre_trésors--;
        }
    }
    return position_heros;
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

static Position LireDirection()
{
    ConsoleKeyInfo keyInfo;
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
            Console.WriteLine("[AH] Au revoir!");
            Environment.Exit(0);
        }
    }
    while (mouvement == new Position(0, 0));
    return mouvement;
}
record Position(int largeur, int hauteur);