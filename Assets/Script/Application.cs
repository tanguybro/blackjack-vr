
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
        }

        public static string GetImageNamePlayerCard1()
        {
            return GetSourceImageName(blackjack.GetPlayerCardList()[0]);
        }

        public static string GetImageNamePlayerCard2()
        {
            return GetSourceImageName(blackjack.GetPlayerCardList()[1]);
        }

        public static string GetImageNameLastPlayerCard()
        {
            return GetSourceImageName(blackjack.GetPlayerCardList()[blackjack.GetPlayerCardList().Count - 1]);
        }
        public static string GetImageNameBankCard()
        {
            return GetSourceImageName(blackjack.GetBankCardList()[0]);
        }

        public static string GetImageNameLastBankCard()
        {
            return GetSourceImageName(blackjack.GetBankCardList()[blackjack.GetBankCardList().Count - 1]);
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
                val = "0" + (int)value;
            }

            return color + val;
        }
    }
}
