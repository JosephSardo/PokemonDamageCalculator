using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Metadata;
using PokemonDamageCalculator.Models;
using System;
using System.Collections.Generic;

namespace PokemonDamageCalculator.Views;

//This mainwindow file contains code for move selection
public partial class PokemonPanel : UserControl
{
    //Move selection
    private void Move1Acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Move1Acb.SelectedItem == null)
        {
            Move1Button.Content = "- Move 1 -";
            Move1Info.Text = "Move Info...";
        }

        if(Move1Acb.SelectedItem is Move selectedMove)
        {
            Move1 = selectedMove;
            Move1Button.Content = Move1.Name;
            Move1Info.Text = "BP = " + Move1.Power + " / " + Move1.typeAsString() + " / " + Move1.catAsString();
        }
    }

    private void Move2Acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Move2Acb.SelectedItem == null)
        {
            Move2Button.Content = "- Move 2 -";
            Move2Info.Text = "Move Info...";
        }

        if(Move2Acb.SelectedItem is Move selectedMove)
        {
            Move2 = selectedMove;
            Move2Button.Content = Move2.Name;
            Move2Info.Text = "BP = " + Move2.Power + " / " + Move2.typeAsString() + " / " + Move2.catAsString();
        }
    }

    private void Move3Acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Move3Acb.SelectedItem == null)
        {
            Move3Button.Content = "- Move 3 -";
            Move3Info.Text = "Move Info";
        }

        if(Move3Acb.SelectedItem is Move selectedMove)
        {
            Move3 = selectedMove;
            Move3Button.Content = Move3.Name;
            Move3Info.Text = "BP = " + Move3.Power + " / " + Move3.typeAsString() + " / " + Move3.catAsString();
        }
    }

    private void Move4Acb_SelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(Move4Acb.SelectedItem == null)
        {
            Move4Button.Content = "- Move 4 -";
            Move4Info.Text = "Move Info";
        }

        if(Move4Acb.SelectedItem is Move selectedMove)
        {
            Move4 = selectedMove;
            Move4Button.Content = Move4.Name;
            Move4Info.Text = "BP = " + Move4.Power + " / " + Move4.typeAsString() + " / " + Move4.catAsString();
        }
    }
}