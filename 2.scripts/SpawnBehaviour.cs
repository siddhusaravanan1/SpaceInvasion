using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBehaviour : MonoBehaviour
{
    public GameObject enemy;

    public int enemyCount = 0;
    public int enemyOriCount = 0;
    public int totalCount = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if(enemyCount< 1 && totalCount<5)
        {
            StartCoroutine(SpawnDistance());
        }

        if(enemyOriCount<3)
        {
            StartCoroutine(Spawn());
        }
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(5f);
        enemyOriCount = 0;
    }
    IEnumerator SpawnDistance()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
        enemyCount += 1;
        enemyOriCount += 1;
        totalCount += 1;
        yield return new WaitForSeconds(2f);
        enemyCount = 0;
    }
}
