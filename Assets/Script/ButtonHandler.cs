using Assets.Script.BlackjackPackage;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHandler : MonoBehaviour
{
    public void DrawCard()
    {
        Blackjack blackjack = Assets.Script.Application.blackjack;
        Debug.Log("Draw card");
        blackjack.PlayerDrawAnotherCard();

        AddPlayerCard();

        if (blackjack.IsGameFinished())
        {
            new OnClickListener(null).ShowAlert("Perdu", "Vous avez perdu !");
        }
    }

    public void Stop()
    {
        Blackjack blackjack = Assets.Script.Application.blackjack;
        Debug.Log("Stop");
        blackjack.BankLastTurn();

        int nbCards = Assets.Script.Application.blackjack.NbBankCards();
        for(int i = 0; i < nbCards - 1; i++)
        {
            AddBankCard();
        }

        if (blackjack.IsPlayerWinner())
        {
            new OnClickListener(null).ShowAlert("Victoire", "Vous avez gagné !");
        }
        else if (blackjack.IsBankWinner())
        {
            new OnClickListener(null).ShowAlert("Perdu", "Vous avez perdu !");
        }
        else
        {
            new OnClickListener(null).ShowAlert("Egalité", "Il y a égalité !");
        }
    }
    public void Reset()
    {
        SceneManager.LoadScene("SampleScene");
        Assets.Script.Application.blackjack.Reset(0);

        GameObject playerCard1 = GameObject.Find("PlayerCard1"); ;
        playerCard1.GetComponent<PlayerCard1>().Init();

        GameObject playerCard2 = GameObject.Find("PlayerCard2"); ;
        playerCard2.GetComponent<PlayerCard2>().Init();

        GameObject bankCard1 = GameObject.Find("BankCard1"); ;
        bankCard1.GetComponent<BankCard1>().Init();
    }

    private void AddPlayerCard()
    {
        int nbCards = Assets.Script.Application.blackjack.NbPlayerCards();
        float y;
        if (nbCards == 3)
            y = (float)-0.4;
        else if (nbCards == 4)
            y = (float)-0.6;
        else if (nbCards == 4)
            y = (float)-0.8;
        else
            y = (float)-1;

        GameObject playerCard1 = GameObject.Find("PlayerCard1"); ;
        GameObject newCard = GameObject.Instantiate(playerCard1);
        newCard.transform.position = new Vector3(0, y, 1);
        newCard.GetComponent<PlayerCard1>().Init();

        Sprite image = Resources.Load<Sprite>(Assets.Script.Application.GetImageNameLastPlayerCard());
        newCard.GetComponent<Image>().sprite = image;
    }

    private void AddBankCard()
    {
        int nbCards = Assets.Script.Application.blackjack.NbBankCards();
        float y;
        if (nbCards == 2)
            y = (float)-0.2;
        if (nbCards == 3)
            y = (float)-0.4;
        else if (nbCards == 4)
            y = (float)-0.6;
        else if (nbCards == 4)
            y = (float)-0.8;
        else
            y = (float)-1;

        GameObject bankCard1 = GameObject.Find("BankCard1"); ;
        GameObject newCard = GameObject.Instantiate(bankCard1);
        newCard.transform.position = new Vector3((float)0.4, y, 1);

        Sprite image = Resources.Load<Sprite>(Assets.Script.Application.GetImageNameLastBankCard());
        newCard.GetComponent<Image>().sprite = image;
    }

    private class OnClickListener : AndroidJavaProxy
    {
        public readonly Action Callback;
        public OnClickListener(Action callback) : base("android.content.DialogInterface$OnClickListener")
        {
            Callback = callback;
        }
        public void onClick(AndroidJavaObject dialog, int id)
        {
            Callback();
        }  

        public void ShowAlert(string title, string content)
        {
            AndroidJavaObject activity = null;
            using (var unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
            {
                activity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");
            }
            activity.Call("runOnUiThread", new AndroidJavaRunnable(() => {
                AndroidJavaObject dialog = null;
                using (AndroidJavaObject builder = new AndroidJavaObject("android.app.AlertDialog$Builder", activity))
                {
                    builder.Call<AndroidJavaObject>("setTitle", title).Dispose();
                    builder.Call<AndroidJavaObject>("setMessage", content).Dispose();
                    builder.Call<AndroidJavaObject>("setPositiveButton", "OK", new OnClickListener(() => {
                        Debug.Log("Button pressed");
                    })).Dispose();
                    dialog = builder.Call<AndroidJavaObject>("create");
                }
                dialog.Call("show");
                dialog.Dispose();
                activity.Dispose();
            }));
        }
    }
}

