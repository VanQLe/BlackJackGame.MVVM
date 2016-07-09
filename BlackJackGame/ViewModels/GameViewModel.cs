using BlackJackGame.Commands;
using BlackJackGame.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BlackJackGame.ViewModels
{
    public class GameViewModel:ObservableObject
    {
        //private int numPlayers;
        public BlackJackDeck gameDeck;//deck for the game
        public bool GameOver;
        public Game currentGame;
        public ICollection<Card> CardsHistory { get; set; }
        public ICollection<Player> Players { get; set; }
        public int numPlayers = 3;
        /// <summary>
        /// Instantiate a new GameViewModel instance
        /// </summary>
        public GameViewModel(MainWindow mainWindow)
        {
            Players = new ObservableCollection<Player>();
            GameDeck = new BlackJackDeck();//create game deck
            GameOver = true;
            StartCommand = new StartGameCommand(this);
            NextCommand = new NextCardCommand(this);        
            CardsHistory = new ObservableCollection<Card>();
            CurrentGame = new Game(this, Players, CardsHistory, numPlayers);
        }
        public ICommand StartCommand { get; private set; }
        public ICommand NextCommand { get; private set; }
        public BlackJackDeck GameDeck
        {
            get
            {
                return gameDeck;
            }

            set
            {
                gameDeck = value;
            }
        }
        public Game CurrentGame
        {
            get
            {
                return currentGame;
            }

            set
            {
                currentGame = value;
            }
        }

        public void StartGame()
        {   
            GameOver = false;
            CurrentGame.GameBegin();




            MessageBox.Show("Start Button Pressed");
        }
        public Card NextCard()
        {   
            Card newCard = GameDeck.DrawAndRemoveCardFromDeck();
            MessageBox.Show("Next Card Button Pressed");
            return newCard;
        }


       
    }

}
