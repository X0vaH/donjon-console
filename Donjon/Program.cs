{
    Donjon jeu = new(
        Taille._50x17,
        new()
        {
            new Objet(false, Item.Carotte, (1, 20)),
            new Objet(false, Item.Carotte, (2, 35)),
            new Objet(false, Item.Carotte, (3, 50)),
            new Objet(false, Item.Carotte, (5, 8)),
            new Objet(false, Item.Carotte, (5, 32)),
            new Objet(false, Item.Carotte, (10, 33)),
            new Objet(false, Item.Carotte, (11, 33)),
            new Objet(false, Item.Carotte, (11, 38)),
            new Objet(false, Item.Carotte, (14, 21)),
            new Objet(false, Item.Carotte, (16, 12)),

            new Objet(true, Item.Bloc, (1, 34)),
            new Objet(true, Item.Bloc, (2, 30)),
            new Objet(true, Item.Bloc, (2, 18)),
            new Objet(true, Item.Bloc, (3, 49)),
            new Objet(true, Item.Bloc, (4, 49)),
            new Objet(true, Item.Bloc, (4, 16)),
            new Objet(true, Item.Bloc, (5, 6)),
            new Objet(true, Item.Bloc, (5, 14)),
            new Objet(true, Item.Bloc, (5, 20)),
            new Objet(true, Item.Bloc, (5, 36)),
            new Objet(true, Item.Bloc, (8, 31)),
            new Objet(true, Item.Bloc, (8, 49)),
            new Objet(true, Item.Bloc, (9, 22)),
            new Objet(true, Item.Bloc, (9, 36)),
            new Objet(true, Item.Bloc, (10, 18)),
            new Objet(true, Item.Bloc, (10, 20)),
            new Objet(true, Item.Bloc, (11, 7)),
            new Objet(true, Item.Bloc, (11, 26)),
            new Objet(true, Item.Bloc, (12, 10)),
            new Objet(true, Item.Bloc, (13, 10)),
            new Objet(true, Item.Bloc, (14, 21)),
            new Objet(true, Item.Bloc, (14, 26)),
            new Objet(true, Item.Bloc, (15, 9)),
            new Objet(true, Item.Bloc, (15, 10)),
            new Objet(true, Item.Bloc, (15, 27)),
            new Objet(true, Item.Bloc, (16, 38)),
            new Objet(true, Item.Bloc, (17, 6)),
            new Objet(true, Item.Bloc, (17, 11)),
            new Objet(true, Item.Bloc, (17, 18)),

            new Objet(false, Item.Tortue, (9, 25)),
        });
}

record Donjon(Taille taille, List<Objet> objet);
record Objet(bool blocBlanc, Item item, (int largeur, int longueur) Position);
enum Taille { _50x17, _75x25, _80x20 }
enum Item { Carotte, Tortue, Bloc }

