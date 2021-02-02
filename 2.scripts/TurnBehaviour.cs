using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnBehaviour : MonoBehaviour
{
    public GameObject teleporter;
    public GameObject bullet;
    public GameObject spawnPoint;

    public int bulletCount;

    public bool canshoot = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(bulletCount <1 && canshoot)
        {
            StartCoroutine(CanShoot());
        }
    }
    public void CanAttack()
    {
        //transform.LookAt(teleporter.transform.position);
        Vector3 difference = teleporter.transform.localEulerAngles - transform.localEulerAngles;
        float dif = Mathf.Atan2(difference.x, difference.y) - Mathf.Rad2Deg;
        transform.localEulerAngles = new Vector3(0, 0, -dif);
        canshoot = true;
    }
    IEnumerator CanShoot()
    {
        Instantiate(bullet, spawnPoint.transform.position, spawnPoint.transform.rotation);
        bulletCount += 1;
        yield return new WaitForSeconds(1f);
        bulletCount = 0;
    }
}
