using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    Rigidbody2D rb;

    public TeleporterBehaviour _tB;
    public PlayerBehaviour _pB;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.velocity = transform.right * -10;
    }
    private void OnTriggerEnter2D(Collider2D cd)
    {
        if(cd.gameObject.tag=="Platform")
        {
            Destroy(gameObject);
        }
    }
}
