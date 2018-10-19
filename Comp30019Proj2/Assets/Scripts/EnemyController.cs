using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
/// <summary>
/// Enemy script
/// </summary>
public class EnemyController : MonoBehaviour {

    // target player
    public GameObject player;
    // nav mesh agent
    private NavMeshAgent agent;
    // initial attack rate
    private float attackRate = 3f;
    // time since last attack
    private float attackTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
    }

    private void Update()
    {
        // update player position
        agent.destination = player.transform.position;
        // if player still alive and within range 3.5, try attack player
        if (agent.remainingDistance <= 3.5f && player.GetComponent<Player>().GetCurrHP() > 0 && agent.remainingDistance > 0)
        {
            if (Time.timeSinceLevelLoad >= attackTimer)
            {
                attackTimer = Time.timeSinceLevelLoad + attackRate;
                player.GetComponent<Player>().UpdateCurrHP(-1);
            }
        }

    }

    /// <summary>
    /// Update attack rate
    /// </summary>
    /// <param name="rate">new rate</param>
    public void SetAttackRate(float rate)
    {
        this.attackRate = rate;
    }
}
