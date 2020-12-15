
using Assets.Script.CardPackage;
using Assets.Script.DeckPackage;
using System;
using System.Collections.Generic;

namespace Assets.Script.BlackjackPackage
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
                Reset(0);
            }
            catch (Exception e)
            {
                //System.err.println(e.getMessage());
               // System.exit(-1);
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
                Reset(bet);
            }
            catch (Exception e)
            {
                //System.err.println(e.getMessage());
                // System.exit(-1);
            }
        }

        /**
		 * Reset the game
		 * @throws EmptyDeckException
		 */
        public void Reset(int bet)
        {
            gameFinished = false;
			this.bet = bet;
            playerCash -= bet;
            playerHand.Clear();
			bankHand.Clear();
			playerHand.Add(deck.Draw());
			playerHand.Add(deck.Draw());
			bankHand.Add(deck.Draw());
		}

        /**
         * @return the hand of the player
         */
        public List<Card> GetPlayerCardList()
        {
            return new List<Card>(playerHand.GetCardList());
        }

        /**
         * @return the hand of the bank
         */
        public List<Card> GetBankCardList()
        {
            return new List<Card>(bankHand.GetCardList());
        }

        /**
         * @return Displays the hand of the player
         */
        public string GetPlayerHandString()
        {
            return playerHand.ToString();
        }

        /**
         * @return Displays the hand of the bank
         */
        public string GetBankHandString()
        {
            return bankHand.ToString();
        }

        /**
         * @return the best score of the player's hand
         */
        public int GetPlayerBest()
        {
            return playerHand.Best();
        }

        /**
         * @return the best score of the bank's hand
         */
        public int GetBankBest()
        {
            return bankHand.Best();
        }

        /**
         * @return the cash of the player
         */
        public float GetPlayerCash()
        {
            return playerCash;
        }

        /**
         * @return true if the game is finished | false if not
         */
        public bool IsGameFinished()
        {
            return gameFinished;
        }

        /**
         * @return true if the player is the winner | false if not
         */
        public bool IsPlayerWinner()
        {
            return (IsGameFinished() && GetPlayerBest() <= 21 // Si le score est inférieur à 21 
                   && (GetPlayerBest() > GetBankBest() || GetBankBest() > 21)); // et supérieur à celui de la banque ou la banque dépasse 21
        }

        /**
         * @return true if the bank is the winner | false if not
         */
        public bool IsBankWinner()
        {
            return (IsGameFinished() && GetBankBest() <= 21 // Si le score est inférieur à 21
                   && (GetBankBest() > GetPlayerBest() || GetPlayerBest() > 21)); // mais supérieur à celui du joueur ou le joueur dépasse 21
        }

        /**
         * Add a card to the player's hand
         * @throws EmptyDeckException
         */
        public void PlayerDrawAnotherCard()
        {
            playerHand.Add(deck.Draw());
            gameFinished = (GetPlayerBest() > 21);
            }

            /**
		     * The bank draws a card until it gets a score higher than 16
		     * @throws EmptyDeckException
		     */
        public void BankLastTurn()
        {
			while(!gameFinished && GetBankBest() < 17) {
                bankHand.Add(deck.Draw());
            }
            gameFinished = true;
        }

        /**
         * @return true if the player has blackjack | false if not
         */
        public bool PlayerHasBlackJack()
        {
            return GetPlayerBest() == 21 && GetPlayerCardList().Count == 2; // Si les 2 premières cartes font 21
        }

        /**
         * Increase player's cash if he's winner
         */
        public void PlayerWins()
        {
            playerCash += bet * 2;
            if (PlayerHasBlackJack())
                playerCash += (bet / 2); // En cas de blackjack, le joueur gagne la moitié de la mise en plus
        }

        /**
         * Decrease player's cash if he's looser
         */
        public void Draw()
        {
            playerCash += bet;
        }

        /**
         * @return the bet amount
         */
        public float GetBet()
        {
            return bet;
        }

    }
}
