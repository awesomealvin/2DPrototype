using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSelector : MonoBehaviour
{
    // public List<Level> levels;
    public LevelSet levelSet;
    public RectTransform contentTransform;
    public GameObject buttonPrefab;

    void Start()
    {
        InitialiseButtons();
    }

    private void InitialiseButtons()
    {
        if (levelSet == null || buttonPrefab == null)
        {
            return;
        }

        for (int i = 0; i < levelSet.levels.Count; ++i)
        {
            GameObject obj = Instantiate(buttonPrefab, contentTransform, false);
            LevelButton button = obj.GetComponent<LevelButton>();
            if (button != null)
            {
                button.Initialise(i);
            }
        }
    }
}

