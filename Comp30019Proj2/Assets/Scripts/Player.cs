using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

    public int maxHP = 20;
    private int currentHP = 20;
    public GameController gameController;

    private GameObject laptop;


    // Use this for initialization
    void Start () {
        currentHP = maxHP;
        laptop = Resources.Load("laptop") as GameObject;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            this.Attack();
        }

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

    private void Attack()
    {
        GameObject laptop = Instantiate(this.laptop) as GameObject;
        Vector3 laptopPosition = transform.position;
        laptopPosition += new Vector3(0.0f, 0.25f, 0.0f);
        laptop.transform.position = laptopPosition + Camera.main.transform.forward * 2;

        Rigidbody rigidbody = laptop.GetComponent<Rigidbody>();
        rigidbody.velocity = Camera.main.transform.forward * 40;

        laptop.GetComponent<LapTop>().gameController = this.gameController;
    }
}
