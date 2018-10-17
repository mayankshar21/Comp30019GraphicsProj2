using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public UIController UIController;
    public EnemyManager enemyManager;

    private float spawnTimeInterval = 0.5f;
    private float attackRateInterval = 0.2f;
    private const int TOTAL_WAVE = 12;
    private int currWave = 1;
    private int NumEnemyToKill = 5;
    private int currKillNum = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    public void EndGame()
    {
        Time.timeScale = 0;
        UIController.EndGame();
    }

    public void NextWave()
    {
        currWave += 1;
        enemyManager.spawnTime -= spawnTimeInterval;
        enemyManager.attackRate -= attackRateInterval;
        UIController.waveText.text = "Week: "+currWave;
    }

    public void UpdateNumKilled()
    {
        currKillNum++;
        UIController.numKilled.text = currKillNum.ToString();
        if (currKillNum >= currWave * NumEnemyToKill)
        {
            this.NextWave();
        }
    }

    public void UpdateHP(int hp)
    {
        UIController.UpdateCurrHP(hp);
    }



}
