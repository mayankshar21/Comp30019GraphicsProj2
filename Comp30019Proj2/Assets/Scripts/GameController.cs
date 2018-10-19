using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public UIController UIController;
    public EnemyManager enemyManager;
    public GameObject mainCamera;
    public Shader nightMareShader;

    // spawn time to be decreased as wave increases
    private float spawnTimeInterval = 0.5f;
    // attack time to be decreased as wave increases
    private float attackRateInterval = 0.2f;
    // total wave of the game
    private const int TOTAL_WAVE = 12;
    // current wave
    private int currWave = 1;
    // number of enemy to kill to enter next wave
    private int NumEnemyToKill = 5;
    // current number of enemies killed
    private int currKillNum = 0;

	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        this.ActiveNightMare(false);
	}
	
	// Update is called once per frame
	void Update () {

		
	}

    /// <summary>
    /// Player died
    /// </summary>
    public void EndGame()
    {
        Time.timeScale = 0;
        UIController.EndGame();
    }

    /// <summary>
    /// Enter next wave, if in wave 6 or 12, active nightmare mode
    /// </summary>
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

    /// <summary>
    /// Update number of enemy killed
    /// when 5 enemy were killed in a wave,enter next wave
    /// show game clear when wave 12 is completed
    /// </summary>
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

    /// <summary>
    /// Update hp
    /// </summary>
    /// <param name="hp">new hp</param>
    public void UpdateHP(int hp)
    {
        UIController.UpdateCurrHP(hp);
    }

    /// <summary>
    /// Active nightmare mode
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
