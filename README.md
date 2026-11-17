# 🗝️ Donjon — Jeu d'exploration en console (C#)

Petit jeu d'exploration de type *roguelike* qui se joue dans le terminal : le héros doit ramasser **tous les trésors** d'un donjon généré aléatoirement, en évitant les **pièges** et un **monstre** qui le poursuit à chaque tour.

> Projet réalisé au cégep (printemps 2022) en C# / .NET 6.

```
[AH] 3 trésors restants

[AH] ████████████████████████████████████████████
[AH] ██                                        ██
[AH] ██    TT          ██            XX        ██
[AH] ██          ██          MM                ██
[AH] ██                  HH                    ██
[AH] ██    XX                      TT    ██    ██
[AH] ██                ██                      ██
[AH] ████████████████████████████████████████████
```

| Symbole | Signification |
| --- | --- |
| `HH` | le héros (vous) |
| `TT` | un trésor à ramasser |
| `XX` | un piège : partie perdue |
| `MM` | le monstre : il se rapproche du héros à chaque tour |
| `██` | un mur / bloc infranchissable |

## ✨ Fonctionnalités

- **Donjon généré aléatoirement** à chaque partie : taille variable (20 à 40 × 10 à 20 cases), murs, trésors, pièges et monstre placés sur des cases libres.
- **Monstre poursuivant** : il se déplace d'une case vers le héros après chacun de vos mouvements.
- **Sauvegarde et reprise** : quitter avec `Échap` enregistre la partie dans `donjon.json`, qui est rechargée automatiquement au prochain lancement.
- Conditions de fin : victoire quand tous les trésors sont ramassés, défaite sur un piège ou au contact du monstre, ou abandon.
- Rendu en place dans la console (sans défilement).

## 🎮 Commandes

| Touche | Action |
| --- | --- |
| `↑` `↓` `←` `→` | déplacer le héros |
| `Espace` | passer son tour (le monstre avance quand même) |
| `Échap` | sauvegarder et quitter |
| `Q` | abandonner la partie (la sauvegarde est effacée) |

## 🧱 Aspects techniques

- C# 10 / .NET 6, programme à **instructions de niveau supérieur** (*top-level statements*).
- **`record`** `Position` et `JeuDonjon`, avec **déconstruction** et égalité par valeur pour les collisions.
- Paramètres **`out`** pour retourner plusieurs résultats (positions générées, état de fin de tour).
- Sérialisation **`System.Text.Json`** pour la sauvegarde.
- Lecture du clavier sans écho avec `Console.ReadKey(true)`.

## 🚀 Installation et lancement

### Prérequis

- [SDK .NET 6 ou plus récent](https://dotnet.microsoft.com/download)
- Un terminal qui affiche les caractères Unicode (`█`) : Windows Terminal, PowerShell, ou n'importe quel terminal Linux / macOS.

### Lancer le jeu

```bash
git clone https://github.com/X0vaH/donjon-console.git
cd donjon-console
dotnet run --project Donjon
```

> Si seul un runtime plus récent que .NET 6 est installé (ex. .NET 8), définir la variable d'environnement `DOTNET_ROLL_FORWARD=Major` avant `dotnet run` (PowerShell : `$env:DOTNET_ROLL_FORWARD="Major"`).

Agrandir la fenêtre du terminal si le donjon est coupé. Vous pouvez aussi ouvrir `Donjon.sln` dans **Visual Studio** ou **Rider** et lancer le projet `Donjon`.

## 👤 Auteur

**Alex Héroux** ([@X0vaH](https://github.com/X0vaH))
