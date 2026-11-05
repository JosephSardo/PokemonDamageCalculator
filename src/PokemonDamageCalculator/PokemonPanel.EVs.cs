using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator.Views;

//This mainwindow file contains code for EV selection
public partial class PokemonPanel : UserControl
{
    //Change EVs
    private void HpEVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || HpEVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(HpEVTextBox.Text, out int EV)) //ensure input is an integer
        {
            if(HpEVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                HpEVTextBox.Text = "";
                return;
            }
            HpEVTextBox.Text = Pokemon.EVs.HP.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon.calcEVTotal() - Pokemon.EVs.HP + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon.calcEVTotal() - Pokemon.EVs.HP); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            HpEVTextBox.Text = correctedEV.ToString();
            return;
        }

        HpEVTextBox.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeHPEV(correctedEV);
        EVDisplay.Text = Pokemon.calcEVTotal() + "/510";

        //update current HP based on new max
        CurrentHPTextBox.Text = Pokemon.FinalStats.HP.ToString();
        MaxHPText.Text = "/" + Pokemon.FinalStats.HP.ToString() + "   (";
        HpSlider.Maximum = Pokemon.FinalStats.HP;
        HpSlider.Value = Pokemon.FinalStats.HP;
    }

    private void AtkEVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || AtkEVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(AtkEVTextBox.Text, out int EV)) //ensure input is an integer
        {
            if(AtkEVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                AtkEVTextBox.Text = "";
                return;
            }
            AtkEVTextBox.Text = Pokemon.EVs.Atk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon.calcEVTotal() - Pokemon.EVs.Atk + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon.calcEVTotal() - Pokemon.EVs.Atk); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            AtkEVTextBox.Text = correctedEV.ToString();
            return;
        }

        AtkEVTextBox.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeAtkEV(correctedEV);
        EVDisplay.Text = Pokemon.calcEVTotal() + "/510";
    }

    private void DefEVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || DefEVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(DefEVTextBox.Text, out int EV)) //ensure input is an integer
        {
            if(DefEVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                DefEVTextBox.Text = "";
                return;
            }
            DefEVTextBox.Text = Pokemon.EVs.Def.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon.calcEVTotal() - Pokemon.EVs.Def + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon.calcEVTotal() - Pokemon.EVs.Def); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            DefEVTextBox.Text = correctedEV.ToString();
            return;
        }

        DefEVTextBox.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeDefEV(correctedEV);
        EVDisplay.Text = Pokemon.calcEVTotal() + "/510";
    }

    private void SpAtkEVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
       if(Pokemon == null || SpAtkEVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpAtkEVTextBox.Text, out int EV)) //ensure input is an integer
        {
            if(SpAtkEVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpAtkEVTextBox.Text = "";
                return;
            }
            SpAtkEVTextBox.Text = Pokemon.EVs.SpAtk.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon.calcEVTotal() - Pokemon.EVs.SpAtk + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon.calcEVTotal() - Pokemon.EVs.SpAtk); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            SpAtkEVTextBox.Text = correctedEV.ToString();
            return;
        }

        SpAtkEVTextBox.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeSpAtkEV(correctedEV);
        EVDisplay.Text = Pokemon.calcEVTotal() + "/510";
    }

    private void SpDefEVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || SpDefEVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpDefEVTextBox.Text, out int EV)) //ensure input is an integer
        {
            if(SpDefEVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpDefEVTextBox.Text = "";
                return;
            }
            SpDefEVTextBox.Text = Pokemon.EVs.SpDef.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon.calcEVTotal() - Pokemon.EVs.SpDef + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon.calcEVTotal() - Pokemon.EVs.SpDef); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            SpDefEVTextBox.Text = correctedEV.ToString();
            return;
        }

        SpDefEVTextBox.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeSpDefEV(correctedEV);
        EVDisplay.Text = Pokemon.calcEVTotal() + "/510";
    }

    private void SpeedEVTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if(Pokemon == null || SpeedEVTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(SpeedEVTextBox.Text, out int EV)) //ensure input is an integer
        {
            if(SpeedEVTextBox.Text.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                SpeedEVTextBox.Text = "";
                return;
            }
            SpeedEVTextBox.Text = Pokemon.EVs.Speed.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same EV remains displayed
            return;
        }

        int correctedEV = Math.Clamp(EV, 0, 252); //ensure input is within valid range
        if(Pokemon.calcEVTotal() - Pokemon.EVs.Speed + correctedEV > 510) //check if the change puts the EV total over the 510 limit
        {
            correctedEV = 510 - (Pokemon.calcEVTotal() - Pokemon.EVs.Speed); //cap the input to enforce 510 limit
        }

        if(EV != correctedEV) //if input wasn't in valid range, correct the textbox
        {
            SpeedEVTextBox.Text = correctedEV.ToString();
            return;
        }

        SpeedEVTextBox.Text = correctedEV.ToString(); //one last correction of the textbox to ensure leading zeros eliminated
        Pokemon.changeSpeedEV(correctedEV);
        EVDisplay.Text = Pokemon.calcEVTotal() + "/510";
    }

    //_________________________________________________________________________________________________________________________________________________________________________________________
    //EV Lost focus events
    private void HpEVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(HpEVTextBox.Text))
        {
            HpEVTextBox.Text = Pokemon.EVs.HP.ToString();
        }
    }

    private void AtkEVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(AtkEVTextBox.Text))
        {
            AtkEVTextBox.Text = Pokemon.EVs.Atk.ToString();
        }
    }

    private void DefEVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(DefEVTextBox.Text))
        {
            DefEVTextBox.Text = Pokemon.EVs.Def.ToString();
        }
    }

    private void SpAtkEVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(SpAtkEVTextBox.Text))
        {
            SpAtkEVTextBox.Text = Pokemon.EVs.SpAtk.ToString();
        }
    }

    private void SpDefEVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(SpDefEVTextBox.Text))
        {
            SpDefEVTextBox.Text = Pokemon.EVs.SpDef.ToString();
        }
    }

    private void SpeedEVTextBox_LostFocus(object? sender, RoutedEventArgs e)
    {
        if(Pokemon == null) return;
        
        if(string.IsNullOrWhiteSpace(SpeedEVTextBox.Text))
        {
            SpeedEVTextBox.Text = Pokemon.EVs.Speed.ToString();
        }
    }
}