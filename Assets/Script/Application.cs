
using Assets.Script.BlackjackPackage;
using Assets.Script.CardPackage;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Script
{
    public class Application
    {
        public static Blackjack blackjack;

        static void test()
        {

        }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            Debug.Log("********** Starting application **********");
            blackjack = new Blackjack();
            Debug.Log("Player Hand : " + blackjack.GetPlayerHandString());
            Debug.Log("Bank Hand : " + blackjack.GetBankHandString());

            UpdatePlayerCards(blackjack.GetPlayerCardList());
            UpdatePlayerCards(blackjack.GetBankCardList());
        }

        static void UpdatePlayerCards(List<Card> cards)
        {
            string sourceImage1 = GetSourceImageName(cards[0]);
            string sourceImage2 = GetSourceImageName(cards[1]);

            // Doesn't work
            GameObject playerCard1 = GameObject.Find("PlayerCard1");
            Sprite image1 = Resources.Load<Sprite>(sourceImage1);
            playerCard1.GetComponent<Image>().sprite = image1;
        }

        static void UpdateBankCard(List<Card> cards)
        {
            string sourceImage = GetSourceImageName(cards[0]);
        }

        private static string GetSourceImageName(Card card)
        {
            string color = card.GetColor().ToString();
            color = char.ToUpper(color[0]) + color.Substring(1).ToLower();
            Value value = card.GetValue();
            string val = "";

            if (value == Value.TEN)
            {
                val = "10";
            }
            if (value == Value.JACK)
            {
                val = "11";
            }
            else if (value == Value.QUEEN)
            {
                val = "12";
            }
            else if (value == Value.KING)
            {
                val = "13";
            }
            else
            {
                val = "0" + value;
            }

            return color + val;
        }
    }
}
