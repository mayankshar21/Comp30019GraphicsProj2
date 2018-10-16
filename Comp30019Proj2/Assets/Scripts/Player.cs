using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int maxHP = 20;
    public int currentHP = 20;
    public Text gameOverText;
    public Text hpText;


	// Use this for initialization
	void Start () {
        currentHP = maxHP;
	}
	
	// Update is called once per frame
	void Update () {
        hpText.text = currentHP.ToString();
		if (currentHP <= 0)
        {
            gameOverText.gameObject.SetActive(true);
        }
	}
}
