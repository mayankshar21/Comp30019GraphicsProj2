using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Controller for all UI elements
/// </summary>
public class UIController : MonoBehaviour {

    // Text to show the number of weeks
    public Text waveText;

    // Panel which will be displayed when player died
    public GameObject gameEndPanel;

    // Text for HP display
    public Text hpText;

    // Panel which will be displayed when game paused
    public GameObject pausePanel;

    // Text to show number of enemy killed
    public Text numKilled;

    // Panel which will be displayed when game cleared
    public GameObject clearPanel;

    // Pause Button
    public GameObject pauseButton;

	// Initialise states of all UI elements
	void Start () {
        gameEndPanel.SetActive(false);
        pausePanel.SetActive(false);
        clearPanel.SetActive(false);
        pauseButton.SetActive(true);
    }

    /// <summary>
    /// Player died
    /// </summary>
    public void EndGame()
    {
        pauseButton.SetActive(false);
        gameEndPanel.SetActive(true);
    }

    /// <summary>
    /// Game cleared
    /// </summary>
    public void ClearGame()
    {
        pauseButton.SetActive(false);
        clearPanel.SetActive(true);
    }

    /// <summary>
    /// Update displayed HP
    /// </summary>
    /// <param name="hp">HP to be displayed</param>
    public void UpdateCurrHP(int hp)
    {
        hpText.text = hp.ToString();
    }

    /// <summary>
    /// Pause game
    /// </summary>
    public void ShowPause()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        pauseButton.SetActive(false);
    }

    /// <summary>
    /// Continue game
    /// </summary>
    public void HidePause()
    {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
        pauseButton.SetActive(true);
    } 

    /// <summary>
    /// Restart game
    /// </summary>
    public void RestartGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
