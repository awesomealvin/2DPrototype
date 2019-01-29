using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveUIController : MonoBehaviour
{
    [SerializeField] private LevelDetails levelDetails;

    [SerializeField] private TMP_Text enemyCountText;
    [SerializeField] private TMP_Text waveCountText;
    [SerializeField] private TMP_Text levelText;

    public void UpdateEnemyCountText()
    {
        enemyCountText.text = "ENEMIES: " + levelDetails.enemiesRemaining;
    }

    public void UpdateWaveText()
    {
        waveCountText.text = (levelDetails.currentWave + 1) + "/" + levelDetails.totalWaves;
        levelText.text = "LEVEL " + levelDetails.currentLevel;
    }
}
