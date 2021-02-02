using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombSpawnBehaviour : MonoBehaviour
{
    public List<GameObject> spawnPoints = new List<GameObject>();

    public GameObject bomb;

    public bool enter = false;

    public int bombCount = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if (bombCount < 1)
        {
            Vector2 position = spawnPoints[Random.Range(0, spawnPoints.Count)].transform.position;
            Instantiate(bomb, position, Quaternion.identity);
            bombCount += 1;
            StartCoroutine(Count());
        }
    }
    IEnumerator Count()
    {
        yield return new WaitForSeconds(2f);
        bombCount = 0;
    }
}
