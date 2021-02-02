using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowdBehaviour : MonoBehaviour
{
    Rigidbody2D rb;

    public GameObject ray;
    public GameObject bomb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rb.velocity = transform.right * -10;
        RayCast();
    }
    void RayCast()
    {
        RaycastHit2D hit;

        if (hit = Physics2D.Raycast(ray.transform.position,ray.transform.right, 10f))
        {
            if(hit.collider.tag =="Platform")
            {
                Destroy(gameObject);
            }
        }
    }
}
