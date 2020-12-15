using System.Collections.Generic;
using Assets.Script.CardPackage;

namespace Assets.Script.DeckPackage
{
    public class Deck
    {
		private LinkedList<Card> cardList;
        private const int NB_CARD = 52;

		/**
		 * Constructor
		 * @param nbBox
		 */
		public Deck(int nbBox)
		{
            cardList = new LinkedList<Card>();
			Value[] values = Value.values();
			Color[] colors = Color.values();
			for (int i = 0; i < nbBox * NB_CARD; i++)
			{
				Card card = new Card(values[i % 13], colors[i % 4]); // With modulo, we can create all the different cards and avoid multiple loops
				cardList.add(card);
			}
			Collections.shuffle(cardList);
		}

		/**
		 * Display the list of the deck's cards
		 */
		public string toString()
		{
			return cardList.toString();
		}

		/**
		 * Draw a card
		 * @return the next card of the deck
		 * @throws EmptyDeckException
		 */
		public Card draw() throws EmptyDeckException
		{
			Card c = cardList.pollFirst();
			if(c == null)
				throw new EmptyDeckException();
			return c;
		}
	}
}
