using BlackJackGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BlackJackGame.Models
{
    public class Game: ObservableObject
    {
        private int cardNum;
        private ICollection<Player> players;
        private ICollection<Card> cardsHistory;
        private GameViewModel viewModel;
        private int numPlayers;
        private int winnerID;
        private int winnerHand;
       // public ICollection<Card> TestCards;
        public Game(GameViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.players = viewModel.Players;
            this.cardsHistory = viewModel.CardHistory;
            this.numPlayers = viewModel.numPlayers;

            CreatePlayers();
        }

        private void CreatePlayers()
        {
            for (int i = 1; i <= numPlayers; i++)
            {
                players.Add(new Player() { ID = i });
            }
        }
        public void GameBegin()
        {
            //deal each players two cards
            for (int i = 0; i < 2; i++)
            {
                foreach (var player in players)
                {                
                    Card newCard = viewModel.DrewNextCard();         
                    newCard.HitNumb = ++cardNum;               
                    player.AddNewCardToPlayerHand(newCard);
                    checkPlayerHand(player);
                }
            }
            //checkGameOver();
        }

        public void NextCardDraw()
        {
            Card newCard = viewModel.DrewNextCard();
            newCard.HitNumb = ++cardNum;//assign the card# played
            GamePlay(newCard);
        }
   
        private void GamePlay(Card card)
        {
            foreach (var player in players)
            {
                if (player.PlayerTurn)
                {
                    player.AddNewCardToPlayerHand(card);
                    checkPlayerHand(player);
                    checkGameOver();
                    return;
                }
            }
        }

        private void checkPlayerHand(Player player)
        {
            if (player.HandValue == 21)
            {
                winnerID = player.ID;
                winnerHand = player.HandValue;   
                gameover();
                return;
           
            }
            else if (player.HandValue >= 17)
            {
                player.PlayerTurn = false;
            }

            determineWinner(player);//determine who has the best hand
        }

        private void checkGameOver()
        {
            bool checkGameIsOver = false;

            foreach (var player in players)
            {
                if (!player.PlayerTurn)//if no players has a turn, game is over

                    checkGameIsOver = true;
                else
                    checkGameIsOver = false;
            }

            if (checkGameIsOver)
            {
                gameover();
            }
        }

        private void determineWinner(Player player)
        {
          
                if (player.HandValue > winnerHand && player.HandValue <= 21)
                {
                    winnerID = player.ID;
                    winnerHand = player.HandValue;
                }
        }

        private void gameover()
        {
            viewModel.GameOver = true;
            string winner = "Player" + winnerID + " has won the game, with " + winnerHand;
            MessageBox.Show(winner);
        }  
    }
}
