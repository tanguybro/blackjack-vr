
using Assets.Script.CardPackage;
using System.Collections.Generic;
using System.Linq;

namespace Assets.Script.DeckPackage
{
    public class Hand
    {

        private List<Card> cardlist;

        /**
		 * constructor
		 */
        public Hand()
        {
            cardlist = new List<Card>();
        }

        /**
		 * display the hand and the different scores
		 */
        public string Tostring()
        {
            return cardlist.ToString() + " : " + Count();
        }

        /**
		 * add a card to the hand
		 * @param card
		 */
        public void Add(Card card)
        {
            cardlist.Add(card);
        }

        /**
		 * clear the list of cards
		 */
        public void Clear()
        {
            cardlist.Clear();
        }

        /**
		 * @return the list of the hand's cards
		 */
        public List<Card> GetCardList()
        {
            return cardlist;
        }

        /**
		 * calculate the differents scores
		 * @return the list of the different scores 
		 */
        public List<int> Count()
        {
            List<int> values = new List<int> { 0 };
            int sizeresult = values.Count();
            foreach (Card c in cardlist)
            {
                for (int i = 0; i < sizeresult; i++)
                {
                    int val = values[i];
                    values[i] = val + (int)c.GetValue();
                    if ((int)c.GetValue() == 1)
                        values.Add(val + 11); // ajouter une possibilité si il y a un as
                }
                sizeresult = values.Count();
            }
            return values;
        }

        /**
		 * find the best score under 21 or by default the best score
		 * @return the best score
		 */
        public int Best()
        {
            List<int> values = Count();
            int best = 0;
            foreach (int v in values)
            {
                if (v > best && v <= 21)
                    best = v;
            }
            if (values.Count() == 1 || best == 0)
                return values[0];
            return best;
        }
    }
}
