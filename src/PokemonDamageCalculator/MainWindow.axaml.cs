using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

//TODO: Implement everything for pokemon 2
//TODO: Implement UI for field condition selection

//This mainwindow file contains declarations for all objects necessary for UI to function
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
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