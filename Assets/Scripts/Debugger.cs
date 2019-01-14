using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debugger : MonoBehaviour
{

    static Debugger instance;

    [SerializeField]
    Movement playerMovement;

    [SerializeField]
    TMP_Text[] debugText;

    [SerializeField]
    GlobalStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }


    void Update()
    {
        debugText[0].text = "Player Health: " + playerStats.health.ToString();
    }

    public static Debugger GetInstance()
    {
        return instance;
    }

    public void SetDebugText(int index, string text)
    {
        debugText[index].SetText(text);
    }



  
}
