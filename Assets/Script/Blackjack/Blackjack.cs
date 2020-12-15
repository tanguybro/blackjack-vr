
using Assets.Script.CardPackage;
using Assets.Script.DeckPackage;
using System.Collections.Generic;

namespace Assets.Script.Blackjack
{
    public class Blackjack
    {
		private Deck deck;
		private Hand playerHand;
		private Hand bankHand;
		private bool gameFinished;
		private float playerCash;
		private int bet;

		/**
		 * Constructor without parameters
		 */
		public Blackjack()
		{
			deck = new Deck(4);
			playerHand = new Hand();
			bankHand = new Hand();
			playerCash = 0;
			try
			{
				reset(0);
			}
			catch (EmptyDeckException e)
			{
				System.err.println(e.getMessage());
				System.exit(-1);
			}
		}

		/**
		 * Constructor with parameters
		 * @param cash
		 * @param bet
		 */
		public Blackjack(int cash, int bet)
		{
			deck = new Deck(4);
			playerHand = new Hand();
			bankHand = new Hand();
			playerCash = cash;
			try
			{
				reset(bet);
			}
			catch (EmptyDeckException e)
			{
				System.err.println(e.getMessage());
				System.exit(-1);
			}
		}

		/**
		 * Reset the game
		 * @throws EmptyDeckException
		 */
		public void reset(int bet) throws EmptyDeckException
		{
			gameFinished = false;
			this.bet = bet;
			playerCash -= bet;
			playerHand.clear();
			bankHand.clear();
			playerHand.add(deck.draw());
			playerHand.add(deck.draw());
			bankHand.add(deck.draw());
		}

		/**
		 * @return the hand of the player
		 */
		public List<Card> getPlayerCardList()
		{
			return new LinkedList<Card>(playerHand.getCardList());
		}

		/**
		 * @return the hand of the bank
		 */
		public List<Card> getBankCardList()
		{
			return new LinkedList<Card>(bankHand.getCardList());
		}

		/**
		 * @return Displays the hand of the player
		 */
		public String getPlayerHandString()
		{
			return playerHand.toString();
		}

		/**
		 * @return Displays the hand of the bank
		 */
		public String getBankHandString()
		{
			return bankHand.toString();
		}

		/**
		 * @return the best score of the player's hand
		 */
		public int getPlayerBest()
		{
			return playerHand.best();
		}

		/**
		 * @return the best score of the bank's hand
		 */
		public int getBankBest()
		{
			return bankHand.best();
		}

		/**
		 * @return the cash of the player
		 */
		public float getPlayerCash()
		{
			return playerCash;
		}

		/**
		 * @return true if the game is finished | false if not
		 */
		public boolean isGameFinished()
		{
			return gameFinished;
		}

		/**
		 * @return true if the player is the winner | false if not
		 */
		public boolean isPlayerWinner()
		{
			return (isGameFinished() && getPlayerBest() <= 21 // Si le score est inférieur à 21 
				   && (getPlayerBest() > getBankBest() || getBankBest() > 21)); // et supérieur à celui de la banque ou la banque dépasse 21
		}

		/**
		 * @return true if the bank is the winner | false if not
		 */
		public boolean isBankWinner()
		{
			return (isGameFinished() && getBankBest() <= 21 // Si le score est inférieur à 21
				   && (getBankBest() > getPlayerBest() || getPlayerBest() > 21)); // mais supérieur à celui du joueur ou le joueur dépasse 21
		}

		/**
		 * Add a card to the player's hand
		 * @throws EmptyDeckException
		 */
		public void playerDrawAnotherCard() throws EmptyDeckException
		{
			playerHand.add(deck.draw());
			gameFinished = (getPlayerBest() > 21);
			}

		/**
		 * The bank draws a card until it gets a score higher than 16
		 * @throws EmptyDeckException
		 */
		public void bankLastTurn() throws EmptyDeckException
		{
			while(!gameFinished && getBankBest() < 17) {
				bankHand.add(deck.draw());
			}
			gameFinished = true;
		}

		/**
		 * @return true if the player has blackjack | false if not
		 */
		public boolean playerHasBlackJack()
		{
			return getPlayerBest() == 21 && getPlayerCardList().size() == 2; // Si les 2 premières cartes font 21
		}

		/**
		 * Increase player's cash if he's winner
		 */
		public void playerWins()
		{
			playerCash += bet * 2;
			if (playerHasBlackJack())
				playerCash += (bet / 2); // En cas de blackjack, le joueur gagne la moitié de la mise en plus
		}

		/**
		 * Decrease player's cash if he's looser
		 */
		public void draw()
		{
			playerCash += bet;
		}

		/**
		 * @return the bet amount
		 */
		public float getBet()
		{
			return bet;
		}

}
}
