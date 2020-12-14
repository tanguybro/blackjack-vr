
using Assets.Script.CardPackage;
using System.Collections.Generic;

namespace Assets.Script.DeckPackage
{
    public class Hand
    {

		private List<Card> cardList;

		/**
		 * Constructor
		 */
		public Hand()
		{
			cardList = new LinkedList<Card>();
		}

		/**
		 * Display the hand and the different scores
		 */
		public string toString()
		{
			return cardList.toString() + " : " + count();
		}

		/**
		 * Add a card to the hand
		 * @param card
		 */
		public void add(Card card)
		{
			cardList.Add(card);
		}

		/**
		 * Clear the list of cards
		 */
		public void clear()
		{
			cardList.Clear();
		}

		/**
		 * @return the list of the hand's cards
		 */
		public List<Card> getCardList()
		{
			return cardList;
		}

		/**
		 * Calculate the differents scores
		 * @return the list of the different scores 
		 */
		public List<int> count()
		{
			List<int> values = new LinkedList<int>();
			values.add(0);
			int sizeResult = values.size();
			for (Card c : cardList)
			{
				for (int i = 0; i < sizeResult; i++)
				{
					int val = values.get(i);
					values.set(i, val + c.getPoints());
					if (c.getPoints() == 1)
						values.add(val + 11); // Ajouter une possibilité si il y a un as
				}
				sizeResult = values.size();
			}
			return values;
		}

		/**
		 * Find the best score under 21 or by default the best score
		 * @return the best score
		 */
		public int best()
		{
			List<int> values = count();
			int best = 0;
			for (int v : values)
			{
				if (v > best && v <= 21)
					best = v;
			}
			if (values.size() == 1 || best == 0)
				return values.get(0);
			return best;
		}
	}
}
