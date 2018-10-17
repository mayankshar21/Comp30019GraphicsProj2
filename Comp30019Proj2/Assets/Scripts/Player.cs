using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int maxHP = 20;
    private int currentHP = 20;
    public GameController gameController;


	// Use this for initialization
	void Start () {
        currentHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {

	}

    /// <summary>
    /// Substract hp based on val given
    /// call gameController to end game when hp reaches zero
    /// </summary>
    /// <param name="val">attack player received</param>
    public void UpdateCurrHP(int val)
    {
        currentHP += val;
        gameController.UpdateHP(currentHP);
        if (this.currentHP <= 0)
        {
            gameController.EndGame();
        }
    }

    public int GetCurrHP()
    {
        return this.currentHP;
    }
}
