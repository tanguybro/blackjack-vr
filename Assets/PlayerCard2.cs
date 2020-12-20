using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCard2 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    public void Init()
    {
        GameObject playerCard2 = GameObject.Find("PlayerCard2");
        Sprite image2 = Resources.Load<Sprite>(Assets.Script.Application.GetImageNamePlayerCard2());
        playerCard2.GetComponent<Image>().sprite = image2;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
