using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackGame.Models
{
    public class BlackJackDeck
    {
        private List<Card> deck;//game deck
        private Random rnd;
        private int index = 1;
        /// <summary>
        /// Initialize a new instance of Black Jack Deck
        /// </summary>
        public BlackJackDeck()
        {
            rnd = new Random();
            Deck = new List<Card>();
            createDeck();

        }

        public List<Card> Deck
        {
            get
            {
                return deck;
            }

            set
            {
                deck = value;
            }
        }


        private void createDeck()
        {
            foreach (var suit in new[] { "Spades", "Hearts", "Clubs", "Diamonds", })
            {
                for (int rank = 1; rank <= 13; rank++)
                {
                    Deck.Add(new Card(rank, rank, suit));
                }
            }
        }

        public Card DrawAndRemoveCardFromDeck()
        {
            if (index < 46)
            {
                var index = rnd.Next(Deck.Count);
                var card = Deck[index];
                Deck.RemoveAt(index);
                return card;
            }

            return null;
        }
    }
}
