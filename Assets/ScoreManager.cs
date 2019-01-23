#pragma warning disable 0649

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private TMP_Text scoreText;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void UpdateText()
    {
        scoreText.text = "SCORE: " + score;
    }

    public void AddScore(int score)
    {
        this.score += score;
        UpdateText();
    }

    public void AddScore(OnHitData data)
    {
        
        if (data.attacker.type == EntityType.Type.PLAYER)
        {
            int points = data.damageAmount;
            if (data.currentHealth - data.damageAmount < 0)
            {
                points += data.currentHealth - data.damageAmount;
            }
            AddScore(points);
        }
    }

    public void ResetScore()
    {
        AddScore(-score);
    }
}