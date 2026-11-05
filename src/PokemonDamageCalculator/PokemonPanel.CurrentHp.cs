using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator.Views;

//This mainwindow file contains functions to allow for alteration of CURRENT hp (NOT the hp stat)
public partial class PokemonPanel : UserControl
{
    //prevents a change in one textbox from creating a loop where they both repeatedly change each other
    private bool _updatingHPUI = false;

    //allows us to determine whether a text change was performed by the code or by the user
    private string? _programmaticCurrentHPText;
    private string? _programmaticPercentageText;

    //Change exact current HP
    private void CurrentHPTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if (_programmaticCurrentHPText != null)
        {
            if (CurrentHPTextBox.Text == _programmaticCurrentHPText) //if the text was changed by the code, return early
            {
                _programmaticCurrentHPText = null;
                return;
            }

            _programmaticCurrentHPText = null;
        }

        if(_updatingHPUI || Pokemon == null || CurrentHPTextBox.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(CurrentHPTextBox.Text, out int HP)) //ensure input is an integer
        {
            if(CurrentHPTextBox.Text!.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                CurrentHPTextBox.Text = "";
                return;
            }
            CurrentHPTextBox.Text = Pokemon.currentHP.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same HP remains displayed
            return;
        }

        int correctedHP = Math.Clamp(HP, 0, Pokemon.FinalStats.HP); //ensure input is within valid range

        _updatingHPUI = true;

        try
        {
            //update percentage textbox
            int currentPerc = (int)Math.Round((double)correctedHP / Pokemon.FinalStats.HP * 100.0);
            string percentageText = currentPerc.ToString();

            if (PercHPTextBox.Text != percentageText)
            {
                _programmaticPercentageText = percentageText;
                PercHPTextBox.Text = percentageText;
            }

            //update exact hp textbox
            CurrentHPTextBox.Text = correctedHP.ToString();
            Pokemon.currentHP = correctedHP;

            //update slider
            HpSlider.Value = correctedHP;
        }
        finally
        {
            _updatingHPUI = false;
        }
    }

    //Change percent current HP
    private void PercHPTextBox_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if (_programmaticPercentageText != null)
        {
            if (PercHPTextBox.Text == _programmaticPercentageText) //if the text was changed by the code, return early
            {
                _programmaticPercentageText = null;
                return;
            }

            _programmaticPercentageText = null;
        }

        if (_updatingHPUI || Pokemon == null || string.IsNullOrEmpty(PercHPTextBox.Text))
        {
            return;
        }

        if (!int.TryParse(PercHPTextBox.Text, out int percentage))
        {
            if (PercHPTextBox.Text.Length == 1)
            {
                PercHPTextBox.Text = "";
                return;
            }

            PercHPTextBox.Text = ((int)Math.Round((double)Pokemon.currentHP / Pokemon.FinalStats.HP * 100.0)).ToString();

            return;
        }

        int correctedPercentage = Math.Clamp(percentage, 0, 100);

        int correctedHP = (int)Math.Round(Pokemon.FinalStats.HP * correctedPercentage / 100.0);

        _updatingHPUI = true;

        try
        {
            //update percentage textbox
            PercHPTextBox.Text = correctedPercentage.ToString();
            Pokemon.currentHP = correctedHP;

            //update exact hp textbox
            string hpText = correctedHP.ToString();

            if (CurrentHPTextBox.Text != hpText)
            {
                _programmaticCurrentHPText = hpText;
                CurrentHPTextBox.Text = hpText;
            }

            //update slider
            HpSlider.Value = correctedHP;
        }
        finally
        {
            _updatingHPUI = false;
        }
    }
}