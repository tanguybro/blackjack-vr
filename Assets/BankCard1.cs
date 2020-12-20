using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BankCard1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        GameObject bankcard1 = GameObject.Find("BankCard1");
        Sprite image = Resources.Load<Sprite>(Assets.Script.Application.GetImageNameBankCard());
        bankcard1.GetComponent<Image>().sprite = image;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
