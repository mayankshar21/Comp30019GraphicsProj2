using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public UIController UIController;
    public EnemyManager enemyManager;
    public GameObject mainCamera;
    public Shader nightMareShader;

    private float spawnTimeInterval = 0.5f;
    private float attackRateInterval = 0.2f;
    private const int TOTAL_WAVE = 12;
    private int currWave = 1;
    private int NumEnemyToKill = 5;
    private int currKillNum = 0;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        this.ActiveNightMare(false);
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
        if ((currWave % 6) == 0)
        {
            this.ActiveNightMare(true);
        }
        else
        {
            this.ActiveNightMare(false);
        }
    }

    public void UpdateNumKilled()
    {
        currKillNum++;
        UIController.numKilled.text = currKillNum.ToString();
        if (currKillNum >= currWave * NumEnemyToKill)
        {
            if (currWave == TOTAL_WAVE)
            {
                Time.timeScale = 0;
                UIController.ClearGame();
            }
            else
            {
                this.NextWave();
            }          
        }
    }

    public void UpdateHP(int hp)
    {
        UIController.UpdateCurrHP(hp);
    }

    /// <summary>
    /// Code learnt from https://www.youtube.com/watch?v=Tjl8jP5Nuvc&t=256s
    /// </summary>
    public void ActiveNightMare(bool isActive)
    {
        if (isActive)
        {
            mainCamera.GetComponent<Camera>().SetReplacementShader(nightMareShader, "RenderType");
        }
        else
        {
            mainCamera.GetComponent<Camera>().ResetReplacementShader();
        }
        
    }



}
