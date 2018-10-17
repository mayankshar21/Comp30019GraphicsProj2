using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

    public GameObject player;
    private NavMeshAgent agent;
    private float attackRate = 2.4f;
    private float attackTimer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = player.transform.position;
    }

    private void Update()
    {
        agent.destination = player.transform.position;
        if (agent.remainingDistance <= 3.5f && player.GetComponent<Player>().GetCurrHP() > 0 && agent.remainingDistance > 0)
        {
            if (Time.timeSinceLevelLoad >= attackTimer)
            {
                attackTimer = Time.timeSinceLevelLoad + attackRate;
                player.GetComponent<Player>().UpdateCurrHP(-1);
            }
        }
        //else
        //{
        //    attackTimer = Time.timeSinceLevelLoad + attackRate;
        //}

    }

    public void SetAttackRate(float rate)
    {
        this.attackRate = rate;
    }
}
