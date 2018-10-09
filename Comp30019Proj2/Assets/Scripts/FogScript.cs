using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Code learnt from https://www.youtube.com/watch?v=Tjl8jP5Nuvc&t=256s
/// 
/// </summary>
public class FogScript : MonoBehaviour {

    public Shader fogShader;

	// Use this for initialization
	void Start () {
        GetComponent<Camera>().SetReplacementShader(fogShader, "");
	}
}
