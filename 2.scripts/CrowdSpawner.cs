using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdSpawner : MonoBehaviour
{
    public GameObject crowd;

    public int crowdCount = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if(crowdCount<1)
        {
            StartCoroutine(CrownSpawner());
        }
    }
    IEnumerator CrownSpawner()
    {
        Instantiate(crowd, transform.position, Quaternion.identity);
        crowdCount += 1;
        yield return new WaitForSeconds(0.25f);
        crowdCount = 0;
    }
}
