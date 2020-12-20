using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        GameObject playerCard1 = GameObject.Find("PlayerCard1");
        Sprite image1 = Resources.Load<Sprite>(Assets.Script.Application.GetImageNamePlayerCard1());
        playerCard1.GetComponent<Image>().sprite = image1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
