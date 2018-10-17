using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    public Text waveText;

    public GameObject gameEndPanel;

    public Text hpText;

    public GameObject pausePanel;

    public Text numKilled;

    public GameObject clearPanel;

	// Use this for initialization
	void Start () {
        gameEndPanel.SetActive(false);
        pausePanel.SetActive(false);
        clearPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndGame()
    {
        gameEndPanel.SetActive(true);
    }

    public void ClearGame()
    {
        clearPanel.SetActive(true);
    }

    public void UpdateCurrHP(int hp)
    {
        hpText.text = hp.ToString();
    }

    public void ShowPause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void HidePause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    } 

    public void RestartGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
