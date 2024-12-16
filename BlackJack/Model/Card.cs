﻿using Avalonia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack.Model
{
    class Card : INotifyPropertyChanged
    {
        public char Suit { get; set; }
        List<char> suits = new List<char>() { '\ue1ec', '\ue2a8', '\ue448', '\ue1ba' };
        // List<string> suits = new List<string>() { "Karo", "Herz", "Pik", "Kreuz" };
        List<string> Values = new List<string>() { "A", "B", "D", "K" };

        public event PropertyChangedEventHandler? PropertyChanged;

        public string Color { get; }
        public string Value { get; }
        public int Point { get; set; }
        public Card(int suit, int value)
        {
            if (value == 1)
            {
                Value = Values[0];
                Point = 11;
            }
            else if (value > 10)
            {
                Value = Values[value - 10];
                Point = 10;
            }
            else
            {
                Value = value.ToString();
                Point = value;

            }
            if (suit < 2)
            {
                Color = "Red";
            }
            else
            {
                Color = "Black";
            }
            Suit = suits[suit];
        }
    }
}