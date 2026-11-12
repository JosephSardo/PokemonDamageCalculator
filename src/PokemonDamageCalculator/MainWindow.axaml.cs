using Avalonia.Controls;
using PokemonDamageCalculator.Models;
using System.Collections.Generic;
using PokemonDamageCalculator.Services;

namespace PokemonDamageCalculator;

//TODO: Implement UI for field condition selection

//This mainwindow file contains declarations for all objects necessary for UI to function
public partial class MainWindow : Window
{
    public List<Pokemon> Pokedex { get; private set; }
    public MainWindow()
    {
        InitializeComponent();
        Pokedex = PokemonLoader.LoadPokemon("Data/pokemon.json");

        Pokemon1Panel.Pokedex = Pokedex;
        Pokemon2Panel.Pokedex = Pokedex;
    }
}

/*
Sets: (for testing)

Garchomp @ Loaded Dice
Ability: Rough Skin
Level: 50
Tera Type: Fire
EVs: 6 HP / 252 Atk / 252 Spe
Adamant Nature
- Fire Fang
- Brick Break
- Dragon Claw
- Earthquake

Aggron @ Aggronite
Ability: Strong Jaw
Level: 50
EVs: 252 HP / 6 Atk / 252 Def
Impish Nature
- Body Press
- Toxic
- Heavy Slam
- Stealth Rock
*/