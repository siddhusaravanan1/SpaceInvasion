using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleporterBehaviour : MonoBehaviour
{
    public int health = 3;
    void Start()
    {
        
    }

    void Update()
    {
        if(health<1)
        {
            SceneManager.LoadScene("Level-1");
        }
    }
    private void OnTriggerEnter2D(Collider2D cd)
    {
        if(cd.gameObject.tag=="EnemyBullet")
        {
            health -= 1;
            Destroy(cd.gameObject);
        }
    }
}
