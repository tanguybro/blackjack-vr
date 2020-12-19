using Assets.Script.BlackjackPackage;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ButtonHandler : MonoBehaviour
{
    public void DrawCard()
    {
        Blackjack blackjack = Assets.Script.Application.blackjack;
        Debug.Log("Draw card");
        blackjack.PlayerDrawAnotherCard();
        if(blackjack.IsGameFinished())
        {
            if (EditorUtility.DisplayDialog("Perdu", "Vous avez perdu ! Voulez-vous rejouer ?", "Oui", "Non"))
            {
                blackjack.Reset(0);
            }
        }
    }

    public void Stop()
    {
        Debug.Log("Stop");
        Assets.Script.Application.blackjack.BankLastTurn();
    }
}
