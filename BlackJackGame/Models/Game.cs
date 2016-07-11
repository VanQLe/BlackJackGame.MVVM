using BlackJackGame.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class Game: ObservableObject
    {
        private int hitNumb;
        private ICollection<Player> players;
        private ICollection<Card> cardsHistory;
        private GameViewModel viewModel;
        private int numPlayers;
        public ICollection<Card> TestCards;
        public Game(GameViewModel viewModel,ICollection<Player> players, ICollection<Card> cardsHistory, int numPlayers)
        {
            this.viewModel = viewModel;
            this.players = players;
            this.cardsHistory = cardsHistory;
            this.numPlayers = numPlayers;
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
                    //hitNumb++;
                    newCard.HitNumb = ++hitNumb;               
                    player.AddNewCardToPlayerHand(newCard);
                }
            }
        }

        public void NextCardDraw()
        {
            Card newCard = viewModel.DrewNextCard();
            newCard.HitNumb = ++hitNumb;
        }
 
    }
}
