using UnityEngine;
using System.Collections;
/// <summary>
/// The weapon of player
/// </summary>
public class LapTop : MonoBehaviour
{

    public GameController gameController;
    
    // Time of laptop will exist after collide with objects other than enemy
    public float life = 5f;
    // Time stamp of colliding with objects other than enemy
    private float startTime = 0f;
    // If laptop has been collide with something
    private bool hasCollide = false;

    public void Update()
    {
        // Destroy laptop after certain time passed after collision
        if(hasCollide && (Time.timeSinceLevelLoad - startTime) >= life)
        {
            Destroy(this.gameObject);
        }
    }

    /// <summary>
    /// Destroy enemy and laptop if laptop collide with enemy
    /// </summary>
    /// <param name="col">object collide with</param>
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