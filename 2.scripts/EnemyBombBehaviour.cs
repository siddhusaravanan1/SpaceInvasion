using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBombBehaviour : MonoBehaviour
{
    Rigidbody2D rb;

    public BoxCollider2D bombCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * 10;
    }
    void Update()
    {
        StartCoroutine(ColliderActivator());
    }
    IEnumerator ColliderActivator()
    {
        yield return new WaitForSeconds(1f);
        bombCollider.enabled = true;
        yield return new WaitForSeconds(2.5f);
        gameObject.SetActive(false);
    }
}
