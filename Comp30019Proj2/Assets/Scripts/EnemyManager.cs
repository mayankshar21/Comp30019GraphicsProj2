using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// For main game logic
public class EnemyManager : MonoBehaviour {

    private ChangeShader changeShader;
    public GameObject playerObject;

    public GameObject enemy;

    public Player player;

    // Time between spawn
    public float spawnTime = 10f;

    public Vector3[] spawnPoints;

    public float spawnRangeMax = 40f;
    public float spawnRangeMin = 8f;

    public float attackRate = 3f;

    public Material shaderUnity;
    public Material shaderEclipse;
    public Material shaderChrome;
    public Material shaderGit;
    private Material[] shaders;

    // Use this for initialization
    void Start () {
        InitializeSpawnPoints();
        shaders = new Material[] { shaderUnity, shaderEclipse, shaderChrome, shaderGit };
        Debug.Log(shaders[0].name);
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Spawn an enemy
    /// </summary>
    private void Spawn()
    {
        if(player.GetCurrHP() <= 0)
        {
            return;
        }
        Vector3 spawnPoint = FindSpawnPoint();
        GameObject newEnemy = Instantiate(enemy, spawnPoint, Quaternion.identity);
        newEnemy.GetComponent<EnemyController>().player = playerObject;
        newEnemy.GetComponent<EnemyController>().SetAttackRate(this.attackRate);
        newEnemy.GetComponent<Renderer>().material = shaders[UnityEngine.Random.Range(0, 3)];
    }

    /// <summary>
    /// Initialize spawn points
    /// </summary>
    private void InitializeSpawnPoints()
    {
        float y = 1.5f;
        GameObject[] points = GameObject.FindGameObjectsWithTag("WayPoint");
        spawnPoints = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            spawnPoints[i].x = points[i].transform.position.x;
            spawnPoints[i].y = y;
            spawnPoints[i].z = points[i].transform.position.z;
        }
    }

    /// <summary>
    /// Find a spawn which the distance from player is within spawn range
    /// If not such point found, return a random point
    /// </summary>
    /// <returns>A Vector3 spawn point</returns>
    private Vector3 FindSpawnPoint()
    {
        Vector3 playerLocation = playerObject.transform.position;
        Vector3[] points = new Vector3[spawnPoints.Length];
        int numPoint = 0;
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            float distance = Mathf.Sqrt(Mathf.Pow((playerLocation.x - spawnPoints[i].x), 2) + Mathf.Pow((playerLocation.z - spawnPoints[i].z), 2));
            if (distance <= spawnRangeMax && distance >= spawnRangeMin)
            {
                points[numPoint] = spawnPoints[i];
                numPoint++;
            }
        }
        if (numPoint > 0)
        {
            return points[UnityEngine.Random.Range(0, numPoint)];
        }
        return spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Length)];
    }
}
