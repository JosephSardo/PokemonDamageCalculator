using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

//This mainwindow file contains code for EV selection
public partial class MainWindow
{
    //Pokemon 1 functions

    //Change EVs
    private void HpEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || HpEVTextBox1.Text == "") //ensure a pokemon is selected
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
            HpEVTextBox1.Text = Pokemon1.EVs.HP.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon1.calcEVTotal() - Pokemon1.EVs.HP + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon1.calcEVTotal() - Pokemon1.EVs.HP); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            HpEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        HpEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeHPEV(correctedEV);
        EVDisplay1.Text = Pokemon1.calcEVTotal() + "/510";
    }

    private void AtkEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || AtkEVTextBox1.Text == "") //ensure a pokemon is selected
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
            AtkEVTextBox1.Text = Pokemon1.EVs.Atk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon1.calcEVTotal() - Pokemon1.EVs.Atk + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon1.calcEVTotal() - Pokemon1.EVs.Atk); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            AtkEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        AtkEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeAtkEV(correctedEV);
        EVDisplay1.Text = Pokemon1.calcEVTotal() + "/510";
    }

    private void DefEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || DefEVTextBox1.Text == "") //ensure a pokemon is selected
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
            DefEVTextBox1.Text = Pokemon1.EVs.Def.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon1.calcEVTotal() - Pokemon1.EVs.Def + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon1.calcEVTotal() - Pokemon1.EVs.Def); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            DefEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        DefEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeDefEV(correctedEV);
        EVDisplay1.Text = Pokemon1.calcEVTotal() + "/510";
    }

    private void SpAtkEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
       if(Pokemon1 == null || SpAtkEVTextBox1.Text == "") //ensure a pokemon is selected
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
            SpAtkEVTextBox1.Text = Pokemon1.EVs.SpAtk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon1.calcEVTotal() - Pokemon1.EVs.SpAtk + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon1.calcEVTotal() - Pokemon1.EVs.SpAtk); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            SpAtkEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        SpAtkEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeSpAtkEV(correctedEV);
        EVDisplay1.Text = Pokemon1.calcEVTotal() + "/510";
    }

    private void SpDefEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || SpDefEVTextBox1.Text == "") //ensure a pokemon is selected
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
            SpDefEVTextBox1.Text = Pokemon1.EVs.SpDef.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon1.calcEVTotal() - Pokemon1.EVs.SpDef + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon1.calcEVTotal() - Pokemon1.EVs.SpDef); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            SpDefEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        SpDefEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeSpDefEV(correctedEV);
        EVDisplay1.Text = Pokemon1.calcEVTotal() + "/510";
    }

    private void SpeedEVTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon1 == null || SpeedEVTextBox1.Text == "") //ensure a pokemon is selected
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
            SpeedEVTextBox1.Text = Pokemon1.EVs.Speed.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon1.calcEVTotal() - Pokemon1.EVs.Speed + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon1.calcEVTotal() - Pokemon1.EVs.Speed); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            SpeedEVTextBox1.Text = correctedEV.ToString();
            return;
        }

        SpeedEVTextBox1.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon1.changeSpeedEV(correctedEV);
        EVDisplay1.Text = Pokemon1.calcEVTotal() + "/510";
    }

    //_________________________________________________________________________________________________________________________________________________________________________________________
    //EV Lost focus events
    private void HpEVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(HpEVTextBox1.Text))
        {
            HpEVTextBox1.Text = Pokemon1.EVs.HP.ToString();
        }
    }

    private void AtkEVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(AtkEVTextBox1.Text))
        {
            AtkEVTextBox1.Text = Pokemon1.EVs.Atk.ToString();
        }
    }

    private void DefEVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(DefEVTextBox1.Text))
        {
            DefEVTextBox1.Text = Pokemon1.EVs.Def.ToString();
        }
    }

    private void SpAtkEVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(SpAtkEVTextBox1.Text))
        {
            SpAtkEVTextBox1.Text = Pokemon1.EVs.SpAtk.ToString();
        }
    }

    private void SpDefEVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(SpDefEVTextBox1.Text))
        {
            SpDefEVTextBox1.Text = Pokemon1.EVs.SpDef.ToString();
        }
    }

    private void SpeedEVTextBox1_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon1 == null) return;
        
        if(string.IsNullOrWhiteSpace(SpeedEVTextBox1.Text))
        {
            SpeedEVTextBox1.Text = Pokemon1.EVs.Speed.ToString();
        }
    }
}