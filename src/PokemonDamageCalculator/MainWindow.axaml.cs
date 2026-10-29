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
    private Pokemon? Pokemon1;
    private Move? P1move1;
    private Move? P1move2;
    private Move? P1move3;
    private Move? P1move4;

    //Will be uncommented when pokemon2 is implemented
    /*private Pokemon? Pokemon2;
    private Move? P2move1;
    private Move? P2move2;
    private Move? P2move3;
    private Move? P2move4;

    private Move? SelectedMove;
    private BattleState? BattleState;*/

    public MainWindow()
    {
        InitializeComponent();

        Pokemon Garchomp = new("Garchomp", new Stats(108, 130, 95, 80, 85, 102), PokemonType.Dragon, PokemonType.Ground);
        Pokemon Aggron = new("Aggron", new Stats(70, 110, 180, 60, 60, 50), PokemonType.Steel, PokemonType.Rock);

        Move FireFang = new("Fire Fang", 65, 100, PokemonType.Fire, MoveCategory.Physical);
        Move BrickBreak = new("Brick Break", 75, 100, PokemonType.Fighting, MoveCategory.Physical);
        Move DragonClaw = new("Dragon Claw", 80, 100, PokemonType.Dragon, MoveCategory.Physical);
        Move Quake = new("Earthquake", 100, 100, PokemonType.Ground, MoveCategory.Physical);

        //Temporary: hardcoding list of pokemon for testing
        Pokemon1acb.ItemsSource = new List<Pokemon>
        {
            Garchomp,
            Aggron
        };

        //Temporary: hardcoding list of moves for testing
        P1move1acb.ItemsSource = new List<Move>
        {
            FireFang,
            BrickBreak,
            DragonClaw,
            Quake
        };

        P1move2acb.ItemsSource = P1move1acb.ItemsSource;
        P1move3acb.ItemsSource = P1move1acb.ItemsSource;
        P1move4acb.ItemsSource = P1move1acb.ItemsSource;

        //Create list of natures for the autocompletebox
        Nature1acb.ItemsSource = new List<Nature>
        {
            Nature.Hardy,      //-atk
            Nature.Lonely,     //-def
            Nature.Adamant,    //-spatk
            Nature.Naughty,    //-spdef
            Nature.Brave,      //-speed
            //+def
            Nature.Bold,
            Nature.Docile,
            Nature.Impish,
            Nature.Lax,
            Nature.Relaxed,
            //+spatk
            Nature.Modest,
            Nature.Mild,
            Nature.Bashful,
            Nature.Rash,
            Nature.Quiet,
            //+spdef
            Nature.Calm,
            Nature.Gentle,
            Nature.Careful,
            Nature.Quirky,
            Nature.Sassy,
            //+speed
            Nature.Timid,
            Nature.Hasty,
            Nature.Jolly,
            Nature.Naive,
            Nature.Serious
        };

        //Temporary: hardcoding list of abilities for the autocompletebox
        Ability1acb.ItemsSource = new List<String>
        {
            "Rough Skin"
        };

        //Temporary: hardcoding list of held items for the autocompletebox
        Item1acb.ItemsSource = new List<String>
        {
            "None",
            "Life Orb"
        };

        //Listen for items being changed

        //Pokemon 1
        //Pokemon selection
        Pokemon1acb.SelectionChanged += Pokemon1acb_SelectionChanged;

        //Move selection
        P1move1acb.SelectionChanged += P1move1acb_SelectionChanged;
        P1move2acb.SelectionChanged += P1move2acb_SelectionChanged;
        P1move3acb.SelectionChanged += P1move3acb_SelectionChanged;
        P1move4acb.SelectionChanged += P1move4acb_SelectionChanged;

        //Level selection
        LevelTextBox1.TextChanged += LevelTextBox1_TextChanged;

        //IV selection
        HpIVTextBox1.TextChanged += HpIVTextBox1_TextChanged;
        AtkIVTextBox1.TextChanged += AtkIVTextBox1_TextChanged;
        DefIVTextBox1.TextChanged += DefIVTextBox1_TextChanged;
        SpAtkIVTextBox1.TextChanged += SpAtkIVTextBox1_TextChanged;
        SpDefIVTextBox1.TextChanged += SpDefIVTextBox1_TextChanged;
        SpeedIVTextBox1.TextChanged += SpeedIVTextBox1_TextChanged;

        //EV selection
        HpEVTextBox1.TextChanged += HpEVTextBox1_TextChanged;
        AtkEVTextBox1.TextChanged += AtkEVTextBox1_TextChanged;
        DefEVTextBox1.TextChanged += DefEVTextBox1_TextChanged;
        SpAtkEVTextBox1.TextChanged += SpAtkEVTextBox1_TextChanged;
        SpDefEVTextBox1.TextChanged += SpDefEVTextBox1_TextChanged;
        SpeedEVTextBox1.TextChanged += SpeedEVTextBox1_TextChanged;

        //Misc selection
        Nature1acb.SelectionChanged += Nature1acb_SelectionChanged;
        Ability1acb.SelectionChanged += Ability1acb_SelectionChanged;
        Item1acb.SelectionChanged += Item1acb_SelectionChanged;
        Status1cb.SelectionChanged += Status1cb_SelectionChanged;
        Gender1cb.SelectionChanged += Gender1cb_SelectionChanged;

        //Current HP changes
        CurrentHPTextBox1.TextChanged += CurrentHPTextBox1_TextChanged;
        PercHPTextBox1.TextChanged += PercHPTextBox1_TextChanged;

        //Pokemon 2
        /*Pokemon2acb.SelectionChanged += Pokemon2acb_SelectionChanged;

        HpIVTextBox2.TextChanged += HPIVTextBox2_TextChanged;
        AtkIVTextBox2.TextChanged += AtkIVTextBox2_TextChanged;
        DefIVTextBox2.TextChanged += DefIVTextBox2_TextChanged;
        SpAtkIVTextBox2.TextChanged += SpAtkIVTextBox2_TextChanged;
        SpDefIVTextBox2.TextChanged += SpDefIVTextBox2_TextChanged;
        SpeedIVTextBox2.TextChanged += SpeedIVTextBox2_TextChanged;

        HpEVTextBox2.TextChanged += HPEVTextBox2_TextChanged;
        AtkEVTextBox2.TextChanged += AtkEVTextBox2_TextChanged;
        DefEVTextBox2.TextChanged += DefEVTextBox2_TextChanged;
        SpAtkEVTextBox2.TextChanged += SpAtkEVTextBox2_TextChanged;
        SpDefEVTextBox2.TextChanged += SpDefEVTextBox2_TextChanged;
        SpeedEVTextBox2.TextChanged += SpeedEVTextBox2_TextChanged;*/
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