﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using BlackJackGame.ViewModels;

namespace BlackJackGame.Models
{
    public class Player:ObservableObject
    {
        private int playerID;
        private string playerName;
        private int handValue;
        private ICollection<Card> Cards;
        private bool playerTurn = true;
        /// <summary>
        /// Default constructor to initialize a new player
        /// </summary>
        public Player()
        {
            Cards = new ObservableCollection<Card>();
        }

        public string PlayerName
        {
            get
            {
                return playerName;
            }

            set
            {
                playerName = value;
                NotifyPropertyChanged();
            }
        }


        public int ID
        {
            get
            {
                return playerID;
            }

            set
            {
                playerID = value;
                NotifyPropertyChanged();
            }
        }

        public int HandValue
        {
            get
            {
                return handValue;
            }

            set
            {
                handValue += value;
                NotifyPropertyChanged();
            }
        }

        public bool PlayerTurn
        {
            get
            {
                return playerTurn;
            }

            set
            {
                playerTurn = value;
                NotifyPropertyChanged();
            }
        }
        /// <summary>
        /// Add card hit to player hand
        /// </summary>
        /// <param name="newCard"></param>
        public void AddNewCardToPlayerHand(Card newCard)
        {
            HandValue = newCard.CardValue;
            Cards.Add(newCard);
        }

    }
}

