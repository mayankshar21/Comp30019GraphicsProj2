using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://docs.unity3d.com/ScriptReference/Material-shader.html
public class ChangeShader : MonoBehaviour {

    private Shader shaderUnity;
    private Shader shaderEclipse;
    private Shader shaderChrome;
    private Shader shaderGit;
    private Renderer renderer;
    private int shaderSelectionValue;

    // Use this for initialization
    void Start () {
        shaderSelectionValue = Random.Range(1, 4);
        shaderUnity = Shader.Find("Unlit/UnityShader");
        shaderChrome = Shader.Find("Unlit/ChromeShader");
        shaderGit = Shader.Find("Unlit/GitShader");
        shaderEclipse = Shader.Find("Unlit/EclipseShader");
        renderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	public void Change () {
        if(shaderSelectionValue == 1)
        {
            renderer.material.shader = shaderUnity;
        }
        else if(shaderSelectionValue == 2)
        {
            renderer.material.shader = shaderEclipse;
        }
        else if (shaderSelectionValue == 3)
        {
            renderer.material.shader = shaderChrome;
        }
        else if (shaderSelectionValue == 4)
        {
            renderer.material.shader = shaderGit;
        }
		
	}
}
