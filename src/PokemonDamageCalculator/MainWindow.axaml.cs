using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

//This mainwindow file contains declarations for all objects necessary for UI to function, plus pokemon selection code
public partial class MainWindow : Window
{
    private Pokemon? Pokemon1;
    private Move? P1move1;
    private Move? P1move2;
    private Move? P1move3;
    private Move? P1move4;

    private Pokemon? Pokemon2;
    private Move? P2move1;
    private Move? P2move2;
    private Move? P2move3;
    private Move? P2move4;


    private Move? SelectedMove;
    private BattleState? BattleState;

    public MainWindow()
    {
        InitializeComponent();

        Pokemon Garchomp = new("Garchomp", new Stats(108, 130, 95, 80, 85, 102), PokemonType.Dragon, PokemonType.Ground);
        Pokemon Aggron = new("Aggron", new Stats(70, 110, 180, 60, 60, 50), PokemonType.Steel, PokemonType.Rock);

        Move FireFang = new("Fire Fang", 65, 100, PokemonType.Fire, MoveCategory.Physical);
        Move BrickBreak = new("Brick Break", 75, 100, PokemonType.Fighting, MoveCategory.Physical);
        Move DragonClaw = new("Dragon Claw", 80, 100, PokemonType.Dragon, MoveCategory.Physical);
        Move Quake = new("Earthquake", 100, 100, PokemonType.Ground, MoveCategory.Physical);

        //Temporary: hardcoding list of pokemon/moves for testing
        Pokemon1acb.ItemsSource = new List<Pokemon>
        {
            Garchomp,
            Aggron
        };

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

        //Listen for items being changed
        //Pokemon 1
        Pokemon1acb.SelectionChanged += Pokemon1acb_SelectionChanged;

        P1move1acb.SelectionChanged += P1move1acb_SelectionChanged;
        P1move2acb.SelectionChanged += P1move2acb_SelectionChanged;
        P1move3acb.SelectionChanged += P1move3acb_SelectionChanged;
        P1move4acb.SelectionChanged += P1move4acb_SelectionChanged;

        HpIVTextBox1.TextChanged += HpIVTextBox1_TextChanged;
        AtkIVTextBox1.TextChanged += AtkIVTextBox1_TextChanged;
        DefIVTextBox1.TextChanged += DefIVTextBox1_TextChanged;
        SpAtkIVTextBox1.TextChanged += SpAtkIVTextBox1_TextChanged;
        SpDefIVTextBox1.TextChanged += SpDefIVTextBox1_TextChanged;
        SpeedIVTextBox1.TextChanged += SpeedIVTextBox1_TextChanged;

        HpEVTextBox1.TextChanged += HpEVTextBox1_TextChanged;
        AtkEVTextBox1.TextChanged += AtkEVTextBox1_TextChanged;
        DefEVTextBox1.TextChanged += DefEVTextBox1_TextChanged;
        SpAtkEVTextBox1.TextChanged += SpAtkEVTextBox1_TextChanged;
        SpDefEVTextBox1.TextChanged += SpDefEVTextBox1_TextChanged;
        SpeedEVTextBox1.TextChanged += SpeedEVTextBox1_TextChanged;

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

    //Pokemon 1 Functions

    //Pokemon selection
    private void Pokemon1acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon1acb.SelectedItem is Pokemon selectedPokemon)
        {
            Pokemon1 = selectedPokemon;

            BaseHPText1.Text = selectedPokemon.BaseStats.HP.ToString();
            BaseAtkText1.Text = selectedPokemon.BaseStats.Atk.ToString();
            BaseDefText1.Text = selectedPokemon.BaseStats.Def.ToString();
            BaseSpAtkText1.Text = selectedPokemon.BaseStats.SpAtk.ToString();
            BaseSpDefText1.Text = selectedPokemon.BaseStats.SpDef.ToString();
            BaseSpeedText1.Text = selectedPokemon.BaseStats.Speed.ToString();

            //Reset stats
            HpIVTextBox1.Text = "31";
            AtkIVTextBox1.Text = "31";
            DefIVTextBox1.Text = "31";
            SpAtkIVTextBox1.Text = "31";
            SpDefIVTextBox1.Text = "31";
            SpeedIVTextBox1.Text = "31";

            HpEVTextBox1.Text = "0";
            AtkEVTextBox1.Text = "0";
            DefEVTextBox1.Text = "0";
            SpAtkEVTextBox1.Text = "0";
            SpDefEVTextBox1.Text = "0";
            SpeedEVTextBox1.Text = "0";

            //Reset moves
            P1move1acb.Text = String.Empty;
            P1move1acb.SelectedItem = null;

            P1move2acb.Text = String.Empty;
            P1move2acb.SelectedItem = null;

            P1move3acb.Text = String.Empty;
            P1move3acb.SelectedItem = null;

            P1move4acb.Text = String.Empty;
            P1move4acb.SelectedItem = null;
        }
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