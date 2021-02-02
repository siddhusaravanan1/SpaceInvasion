using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehaviour : MonoBehaviour
{
    Rigidbody2D rb;

    public BoxCollider2D bombBoxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(5,5);
        StartCoroutine(Activate());
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D cd)
    {
        if(cd.gameObject.tag=="Crowd")
        {
            Destroy(cd.gameObject);
        }
    }
    IEnumerator Activate()
    {
        yield return new WaitForSeconds(1.5f);
        bombBoxCollider.enabled = true;
        yield return new WaitForSeconds(0.25f);
        Destroy(gameObject);
    }
}
