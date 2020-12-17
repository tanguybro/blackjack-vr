
using Assets.Script.BlackjackPackage;
using UnityEngine;

namespace Assets.Script
{
    public class Application
    {
        private static Blackjack blackjack;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        static void OnBeforeSceneLoadRuntimeMethod()
        {
            Debug.Log("********** Starting application **********");
            blackjack = new Blackjack();
            Debug.Log("Player Hand : " + blackjack.GetPlayerHandString());
            Debug.Log("Bank Hand : " + blackjack.GetBankHandString());
        }
    }
}
