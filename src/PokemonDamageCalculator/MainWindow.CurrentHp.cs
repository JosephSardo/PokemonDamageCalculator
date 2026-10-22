using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator;

//This mainwindow file contains functions to allow for alteration of CURRENT hp (NOT the hp stat)
public partial class MainWindow
{
    //prevents a change in one textbox from creating a loop where they both repeatedly change each other
    private bool _updatingHPUI = false;

    private string? _programmaticCurrentHPText;
    private string? _programmaticPercentageText;

    //Change exact current HP
    private void CurrentHPTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if (_programmaticCurrentHPText != null)
        {
            if (CurrentHPTextBox1.Text == _programmaticCurrentHPText)
            {
                _programmaticCurrentHPText = null;
                return;
            }

            _programmaticCurrentHPText = null;
        }

        if(_updatingHPUI || Pokemon1 == null || CurrentHPTextBox1.Text == "") //ensure a pokemon is selected
        {
            return;
        }

        if(!int.TryParse(CurrentHPTextBox1.Text, out int HP)) //ensure input is an integer
        {
            if(CurrentHPTextBox1.Text!.Length == 1) //if we try and put a non-integer into an empty textbox, keep the textbox empty
            {
                CurrentHPTextBox1.Text = "";
                return;
            }
            CurrentHPTextBox1.Text = Pokemon1.currentHP.ToString(); //if we try and put a non-integer into a non-empty textbox, make it so nothing changes and the same HP remains displayed
            return;
        }

        int correctedHP = Math.Clamp(HP, 0, Pokemon1.FinalStats.HP); //ensure input is within valid range

        _updatingHPUI = true;

        try
        {
            //update percentage textbox
            int currentPerc = (int)Math.Round((double)correctedHP / Pokemon1.FinalStats.HP * 100.0);
            string percentageText = currentPerc.ToString();

            if (PercHPTextBox1.Text != percentageText)
            {
                _programmaticPercentageText = percentageText;
                PercHPTextBox1.Text = percentageText;
            }

            //update exact hp textbox
            CurrentHPTextBox1.Text = correctedHP.ToString();
            Pokemon1.currentHP = correctedHP;

            //update slider
            HpSlider1.Value = correctedHP;
        }
        finally
        {
            _updatingHPUI = false;
        }
    }

    //Change percent current HP
    private void PercHPTextBox1_TextChanged(object? sender, TextChangedEventArgs e)
    {
        if (_programmaticPercentageText != null)
        {
            if (PercHPTextBox1.Text == _programmaticPercentageText)
            {
                _programmaticPercentageText = null;
                return;
            }

            _programmaticPercentageText = null;
        }

        if (_updatingHPUI || Pokemon1 == null || string.IsNullOrEmpty(PercHPTextBox1.Text))
        {
            return;
        }

        if (!int.TryParse(PercHPTextBox1.Text, out int percentage))
        {
            if (PercHPTextBox1.Text.Length == 1)
            {
                PercHPTextBox1.Text = "";
                return;
            }

            PercHPTextBox1.Text = ((int)Math.Round((double)Pokemon1.currentHP / Pokemon1.FinalStats.HP * 100.0)).ToString();

            return;
        }

        int correctedPercentage = Math.Clamp(percentage, 0, 100);

        int correctedHP = (int)Math.Round(Pokemon1.FinalStats.HP * correctedPercentage / 100.0);

        _updatingHPUI = true;

        try
        {
            //update percentage textbox
            PercHPTextBox1.Text = correctedPercentage.ToString();
            Pokemon1.currentHP = correctedHP;

            //update exact hp textbox
            string hpText = correctedHP.ToString();

            if (CurrentHPTextBox1.Text != hpText)
            {
                _programmaticCurrentHPText = hpText;
                CurrentHPTextBox1.Text = hpText;
            }

            //update slider
            HpSlider1.Value = correctedHP;
        }
        finally
        {
            _updatingHPUI = false;
        }
    }
}