using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public float maxEnemyLeft;
    public float maxEnemyRight;
    public float delayTimer = 1f;
    float timer;
    float fuel = 10f;

    // Start is called before the first frame update
    void Start()
    {
        timer = delayTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        fuel = fuel - Time.deltaTime;

        if (fuel <= 0)
        {
            Vector3 spawnpos = new Vector3(Random.Range(maxEnemyLeft, maxEnemyRight), transform.position.y, transform.position.z);
            Instantiate(enemyPrefabs[2], spawnpos, transform.rotation);
            fuel = 10f;
            timer = Random.Range(0.5f,1.1f);
            
        }

        
        else if(timer <= 0)
        {
            Vector3 spawnpos = new Vector3(Random.Range(maxEnemyLeft, maxEnemyRight), transform.position.y, transform.position.z);
            int randomIndex = Random.Range(0, 2);
            Instantiate(enemyPrefabs[randomIndex], spawnpos, transform.rotation);
            timer = delayTimer;
        }

        
    }

}
