using UnityEngine;
using System.Collections;

public class LapTop : MonoBehaviour
{

    public GameController gameController;
    public float life = 5f;
    private float startTime = 0f;
    private bool hasCollide = false;

    public void Update()
    {
        if(hasCollide && (Time.timeSinceLevelLoad - startTime) >= life)
        {
            Destroy(this.gameObject);
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Enemy" && !hasCollide)
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            gameController.UpdateNumKilled();
        }
        hasCollide = true;
        startTime = Time.timeSinceLevelLoad;
    
    }
}