using System;
using System.Collections.Generic;
using System.Linq;
using Assets.Script.CardPackage;

namespace Assets.Script.DeckPackage
{
    public class Deck
    {
        private List<Card> cardList;
        private const int NB_CARD = 52;
        int cpt;

        /**
		 * Constructor
		 * @param nbBox
		 */
        public Deck(int nbBox)
        {
            cardList = new List<Card>();
            Value[] values = (Value[])Enum.GetValues(typeof(Value));
            Color[] colors = (Color[])Enum.GetValues(typeof(Color));
            for (int i = 0; i < nbBox * NB_CARD; i++)
            {
                Card card = new Card(values[i % 13], colors[i % 4]); // With modulo, we can create all the different cards and avoid multiple loops
                cardList.Add(card);
            }
            cardList = cardList.OrderBy(x => Guid.NewGuid()).ToList();
            cpt = 0;
        }

        /**
		 * Display the list of the deck's cards
		 */
        public override string ToString()
        {
            return cardList.ToString();
        }

        /**
		 * Draw a card
		 * @return the next card of the deck
		 * @throws EmptyDeckException
		 */
        public Card Draw()
        {
            Card c = cardList[cpt++];
			if(c == null)
				throw new Exception();
			return c;
		}
}
}
