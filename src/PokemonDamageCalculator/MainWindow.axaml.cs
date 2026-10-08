using Avalonia.Controls;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

public partial class MainWindow : Window
{
    private Pokemon? pokemon1;
    private Pokemon? pokemon2;
    private Move? selectedMove;
    private BattleState? battleState;

    public MainWindow()
    {
        InitializeComponent();

        Pokemon Garchomp = new("Garchomp", new Stats(108, 130, 95, 80, 85, 102), PokemonType.Dragon, PokemonType.Ground);
        Pokemon Aggron = new("Aggron", new Stats(70, 110, 180, 60, 60, 50), PokemonType.Steel, PokemonType.Rock);

        Pokemon1acb.ItemsSource = new List<Pokemon>
        {
            Garchomp,
            Aggron
        };

        //Listen for items being changed
        //Pokemon 1
        Pokemon1acb.SelectionChanged += Pokemon1acb_SelectionChanged;

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
            pokemon1 = selectedPokemon;

            BaseHPText1.Text = selectedPokemon.BaseStats.HP.ToString();
            BaseAtkText1.Text = selectedPokemon.BaseStats.Atk.ToString();
            BaseDefText1.Text = selectedPokemon.BaseStats.Def.ToString();
            BaseSpAtkText1.Text = selectedPokemon.BaseStats.SpAtk.ToString();
            BaseSpDefText1.Text = selectedPokemon.BaseStats.SpDef.ToString();
            BaseSpeedText1.Text = selectedPokemon.BaseStats.Speed.ToString();

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
        }
    }

    //_________________________________________________________________________________________________________________________________________________________________________________________
    //Change IVs
    private void HpIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || HpIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(HpIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(HpIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                HpIVTextBox1.Text = "";
                return;
            }
            HpIVTextBox1.Text = pokemon1.IVs.HP.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            HpIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        HpIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeHPIV(correctedIV);
    }

    private void AtkIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || AtkIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(AtkIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(AtkIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                AtkIVTextBox1.Text = "";
                return;
            }
            AtkIVTextBox1.Text = pokemon1.IVs.Atk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            AtkIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        AtkIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeAtkIV(correctedIV);
    }

    private void DefIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || DefIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(DefIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(DefIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                DefIVTextBox1.Text = "";
                return;
            }
            DefIVTextBox1.Text = pokemon1.IVs.Def.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            DefIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        DefIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeDefIV(correctedIV);
    }

    private void SpAtkIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || SpAtkIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpAtkIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(SpAtkIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpAtkIVTextBox1.Text = "";
                return;
            }
            SpAtkIVTextBox1.Text = pokemon1.IVs.SpAtk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            SpAtkIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        SpAtkIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeSpAtkIV(correctedIV);
    }

    private void SpDefIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || SpDefIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpDefIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(SpDefIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpDefIVTextBox1.Text = "";
                return;
            }
            SpDefIVTextBox1.Text = pokemon1.IVs.SpDef.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            SpDefIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        SpDefIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeSpDefIV(correctedIV);
    }

    private void SpeedIVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || SpeedIVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpeedIVTextBox1.Text, out int IV)) //ensure input is an integer
        {
            if(SpeedIVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpeedIVTextBox1.Text = "";
                return;
            }
            SpeedIVTextBox1.Text = pokemon1.IVs.Speed.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same IV remains displayed
            return;
        }

        int correctedIV = Math.Clamp(IV, 0, 31); //ensure input is within valid range

        if(IV != correctedIV) //if input wasn't in valid range, correct the textbox
        {
            SpeedIVTextBox1.Text = correctedIV.ToString();
            return;
        }

        SpeedIVTextBox1.Text = correctedIV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeSpeedIV(correctedIV);
    }

    //_________________________________________________________________________________________________________________________________________________________________________________________
    //Change EVs
    private void HpEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || HpEVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(HpEVTextBox1.Text, out int EV)) //ensure input is an integer
        {
            if(HpEVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                HpEVTextBox1.Text = "";
                return;
            }
            HpEVTextBox1.Text = pokemon1.EVs.HP.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(pokemon1.calcEVTotal() - pokemon1.EVs.HP + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (pokemon1.calcEVTotal() - pokemon1.EVs.HP); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            HpEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        HpEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeHPEV(correctedEV);
        EVDisplay1.Text = pokemon1.calcEVTotal() + "/510";
    }

    private void AtkEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || AtkEVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(AtkEVTextBox1.Text, out int EV)) //ensure input is an integer
        {
            if(AtkEVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                AtkEVTextBox1.Text = "";
                return;
            }
            AtkEVTextBox1.Text = pokemon1.EVs.Atk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(pokemon1.calcEVTotal() - pokemon1.EVs.Atk + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (pokemon1.calcEVTotal() - pokemon1.EVs.Atk); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            AtkEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        AtkEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeAtkEV(correctedEV);
        EVDisplay1.Text = pokemon1.calcEVTotal() + "/510";
    }

    private void DefEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || DefEVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(DefEVTextBox1.Text, out int EV)) //ensure input is an integer
        {
            if(DefEVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                DefEVTextBox1.Text = "";
                return;
            }
            DefEVTextBox1.Text = pokemon1.EVs.Def.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(pokemon1.calcEVTotal() - pokemon1.EVs.Def + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (pokemon1.calcEVTotal() - pokemon1.EVs.Def); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            DefEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        DefEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeDefEV(correctedEV);
        EVDisplay1.Text = pokemon1.calcEVTotal() + "/510";
    }

    private void SpAtkEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
       if(pokemon1 == null || SpAtkEVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpAtkEVTextBox1.Text, out int EV)) //ensure input is an integer
        {
            if(SpAtkEVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpAtkEVTextBox1.Text = "";
                return;
            }
            SpAtkEVTextBox1.Text = pokemon1.EVs.SpAtk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(pokemon1.calcEVTotal() - pokemon1.EVs.SpAtk + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (pokemon1.calcEVTotal() - pokemon1.EVs.SpAtk); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            SpAtkEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        SpAtkEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeSpAtkEV(correctedEV);
        EVDisplay1.Text = pokemon1.calcEVTotal() + "/510";
    }

    private void SpDefEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || SpDefEVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpDefEVTextBox1.Text, out int EV)) //ensure input is an integer
        {
            if(SpDefEVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpDefEVTextBox1.Text = "";
                return;
            }
            SpDefEVTextBox1.Text = pokemon1.EVs.SpDef.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(pokemon1.calcEVTotal() - pokemon1.EVs.SpDef + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (pokemon1.calcEVTotal() - pokemon1.EVs.SpDef); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            SpDefEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        SpDefEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeSpDefEV(correctedEV);
        EVDisplay1.Text = pokemon1.calcEVTotal() + "/510";
    }

    private void SpeedEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(pokemon1 == null || SpeedEVTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpeedEVTextBox1.Text, out int EV)) //ensure input is an integer
        {
            if(SpeedEVTextBox1.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpeedEVTextBox1.Text = "";
                return;
            }
            SpeedEVTextBox1.Text = pokemon1.EVs.Speed.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(pokemon1.calcEVTotal() - pokemon1.EVs.Speed + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (pokemon1.calcEVTotal() - pokemon1.EVs.Speed); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            SpeedEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        SpeedEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        pokemon1.changeSpeedEV(correctedEV);
        EVDisplay1.Text = pokemon1.calcEVTotal() + "/510";
    }

    //Pokemon 2 Function
    /*private void Pokemon2acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Pokemon2acb.SelectedItem is Pokemon selectedPokemon)
        {
            pokemon2 = selectedPokemon;

            BaseHPText2.Text = selectedPokemon.BaseStats.HP.ToString();
            BaseAtkText2.Text = selectedPokemon.BaseStats.Atk.ToString();
            BaseDefText2.Text = selectedPokemon.BaseStats.Def.ToString();
            BaseSpAtkText2.Text = selectedPokemon.BaseStats.SpAtk.ToString();
            BaseSpDefText2.Text = selectedPokemon.BaseStats.SpDef.ToString();
            BaseSpeedText2.Text = selectedPokemon.BaseStats.Speed.ToString();
        }
    }*/

        //Commented code below is for testing. Will be removed later

        /*Pokemon Garchomp = new("Garchomp", new Stats(108, 130, 95, 80, 85, 102), PokemonType.Dragon, PokemonType.Ground);
        //Console.WriteLine("Made Garchomp");
        Garchomp.changeAtkEV(252);
        Garchomp.changeSpeedEV(252);
        Garchomp.changeHPEV(6);
        Garchomp.changeNature(Nature.Adamant);
        //Console.WriteLine("Made Garchomp EV Spread");

        Pokemon Aggron = new("Aggron", new Stats(70, 110, 180, 60, 60, 50), PokemonType.Steel, PokemonType.Rock);
        //Console.WriteLine("Made Aggron");
        Aggron.changeDefEV(252);
        Aggron.changeHPEV(252);
        Aggron.changeAtkEV(6);
        Aggron.changeNature(Nature.Impish);
        //Console.WriteLine("Made Aggron EV Spread");

        Console.WriteLine("Garchomp Stats: ");
        Console.WriteLine("Name: " + Garchomp.Name);
        Console.WriteLine("Level: " + Garchomp.Level);
        Garchomp.printFinalStats();

        Console.WriteLine("");

        Console.WriteLine("Aggron Stats: ");
        Console.WriteLine("Name: " + Aggron.Name);
        Console.WriteLine("Level: " + Aggron.Level);
        Aggron.printFinalStats();

        //testing attack calculation
        //assume garchomp is attacker

        BattleState BattleState = new();

        //Test: no stab, neutral type matchup
        Move FireFang = new("Fire Fang", 65, PokemonType.Fire, MoveCategory.Physical);
        int ffdmg = DamageCalculator.calcDamage(Garchomp, Aggron, FireFang, BattleState);
        Console.WriteLine("Fire Fang Damage: " + ffdmg);

        //Test: no stab, supereffective
        Move BrickBreak = new("Brick Break", 75, PokemonType.Fighting, MoveCategory.Physical);
        int bbdmg = DamageCalculator.calcDamage(Garchomp, Aggron, BrickBreak, BattleState);
        Console.WriteLine("Brick Break Damage: " + bbdmg);

        //Test: stab, ineffective
        Move DragonClaw = new("Dragon Claw", 80, PokemonType.Dragon, MoveCategory.Physical);
        int dcdmg = DamageCalculator.calcDamage(Garchomp, Aggron, DragonClaw, BattleState);
        Console.WriteLine("Dragon Claw Damage: " + dcdmg);

        //Test: stab, supereffective
        Move Quake = new("Earthquake", 100, PokemonType.Ground, MoveCategory.Physical);
        int eqdmg = DamageCalculator.calcDamage(Garchomp, Aggron, Quake, BattleState);
        Console.WriteLine("Earthquake Damage: " + eqdmg);

        //Now test with stat changes
        Console.WriteLine("\nDamage after stat change: \n");
        Garchomp.changeAtkBoost(2);

        //Test: no stab, neutral type matchup
        FireFang = new("Fire Fang", 65, PokemonType.Fire, MoveCategory.Physical);
        ffdmg = DamageCalculator.calcDamage(Garchomp, Aggron, FireFang, BattleState);
        Console.WriteLine("Fire Fang Damage: " + ffdmg);

        //Test: no stab, supereffective
        BrickBreak = new("Brick Break", 75, PokemonType.Fighting, MoveCategory.Physical);
        bbdmg = DamageCalculator.calcDamage(Garchomp, Aggron, BrickBreak, BattleState);
        Console.WriteLine("Brick Break Damage: " + bbdmg);

        //Test: stab, ineffective
        DragonClaw = new("Dragon Claw", 80, PokemonType.Dragon, MoveCategory.Physical);
        dcdmg = DamageCalculator.calcDamage(Garchomp, Aggron, DragonClaw, BattleState);
        Console.WriteLine("Dragon Claw Damage: " + dcdmg);

        //Test: stab, supereffective
        Quake = new("Earthquake", 100, PokemonType.Ground, MoveCategory.Physical);
        eqdmg = DamageCalculator.calcDamage(Garchomp, Aggron, Quake, BattleState);
        Console.WriteLine("Earthquake Damage: " + eqdmg);
        */
    
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