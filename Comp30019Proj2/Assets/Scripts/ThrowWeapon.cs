using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowWeapon : MonoBehaviour {

    GameObject prefab;
	// Use this for initialization
	void Start () {
        prefab = Resources.Load("laptop") as GameObject;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0)){
            GameObject laptop = Instantiate(prefab) as GameObject;
            laptop.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody rigidbody = laptop.GetComponent<Rigidbody>();
            rigidbody.velocity = Camera.main.transform.forward * 40;
        }
	}
}
