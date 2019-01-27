using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public TMP_Text text;

    public int level;

    public void Initialise(int levelNumber)
    {
        this.level = levelNumber;
        text.text = level.ToString();
    }


}
