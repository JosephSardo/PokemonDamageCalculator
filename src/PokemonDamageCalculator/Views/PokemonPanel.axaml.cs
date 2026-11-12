using Avalonia.Controls;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;
using PokemonDamageCalculator.Services;

namespace PokemonDamageCalculator.Views;

public partial class PokemonPanel : UserControl
{
    private Pokemon? Pokemon;
    private Move? Move1;
    private Move? Move2;
    private Move? Move3;
    private Move? Move4;

    /*
    private Move? SelectedMove;
    private BattleState? BattleState;
    */

    public PokemonPanel()
    {
        InitializeComponent();

        Move FireFang = new("Fire Fang", 65, 100, PokemonType.Fire, MoveCategory.Physical);
        Move BrickBreak = new("Brick Break", 75, 100, PokemonType.Fighting, MoveCategory.Physical);
        Move DragonClaw = new("Dragon Claw", 80, 100, PokemonType.Dragon, MoveCategory.Physical);
        Move Quake = new("Earthquake", 100, 100, PokemonType.Ground, MoveCategory.Physical);

        //load list of pokemon from local database
        PokemonAcb.ItemsSource = PokemonLoader.LoadPokemon("Data/pokemon.json");

        //Temporary: hardcoding list of moves for testing
        Move1Acb.ItemsSource = new List<Move>
        {
            FireFang,
            BrickBreak,
            DragonClaw,
            Quake
        };

        Move2Acb.ItemsSource = Move1Acb.ItemsSource;
        Move3Acb.ItemsSource = Move1Acb.ItemsSource;
        Move4Acb.ItemsSource = Move1Acb.ItemsSource;

        //Create list of natures for the autocompletebox
        NatureAcb.ItemsSource = new List<Nature>
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
        AbilityAcb.ItemsSource = new List<String>
        {
            "Rough Skin"
        };

        //Temporary: hardcoding list of held items for the autocompletebox
        ItemAcb.ItemsSource = new List<String>
        {
            "None",
            "Life Orb"
        };

        //Listen for items being changed

        //Pokemon 1
        //Pokemon selection
        PokemonAcb.SelectionChanged += PokemonAcb_SelectionChanged;

        //Move selection
        Move1Acb.SelectionChanged += Move1Acb_SelectionChanged;
        Move2Acb.SelectionChanged += Move2Acb_SelectionChanged;
        Move3Acb.SelectionChanged += Move3Acb_SelectionChanged;
        Move4Acb.SelectionChanged += Move4Acb_SelectionChanged;

        //Level selection
        LevelTextBox.TextChanged += LevelTextBox_TextChanged;

        //IV selection
        HpIVTextBox.TextChanged += HpIVTextBox_TextChanged;
        AtkIVTextBox.TextChanged += AtkIVTextBox_TextChanged;
        DefIVTextBox.TextChanged += DefIVTextBox_TextChanged;
        SpAtkIVTextBox.TextChanged += SpAtkIVTextBox_TextChanged;
        SpDefIVTextBox.TextChanged += SpDefIVTextBox_TextChanged;
        SpeedIVTextBox.TextChanged += SpeedIVTextBox_TextChanged;

        //EV selection
        HpEVTextBox.TextChanged += HpEVTextBox_TextChanged;
        AtkEVTextBox.TextChanged += AtkEVTextBox_TextChanged;
        DefEVTextBox.TextChanged += DefEVTextBox_TextChanged;
        SpAtkEVTextBox.TextChanged += SpAtkEVTextBox_TextChanged;
        SpDefEVTextBox.TextChanged += SpDefEVTextBox_TextChanged;
        SpeedEVTextBox.TextChanged += SpeedEVTextBox_TextChanged;

        //Misc selection
        NatureAcb.SelectionChanged += NatureAcb_SelectionChanged;
        AbilityAcb.SelectionChanged += AbilityAcb_SelectionChanged;
        ItemAcb.SelectionChanged += ItemAcb_SelectionChanged;
        StatusCb.SelectionChanged += StatusCb_SelectionChanged;
        GenderCb.SelectionChanged += GenderCb_SelectionChanged;

        //Current HP changes
        CurrentHPTextBox.TextChanged += CurrentHPTextBox_TextChanged;
        PercHPTextBox.TextChanged += PercHPTextBox_TextChanged;
    }
}