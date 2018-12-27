using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Debugger : MonoBehaviour
{

    static Debugger instance;

    [SerializeField]
    TMP_Text[] debugText;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
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
