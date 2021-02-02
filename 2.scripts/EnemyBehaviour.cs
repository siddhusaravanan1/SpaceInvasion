using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public GameObject stop;

    public bool canMove = false;

    public TurnBehaviour _turnBehaviour;
    void Start()
    {
        canMove = true;
    }
    void Update()
    {
        float distance = Vector3.Distance(stop.transform.position, transform.position);

        if(distance<1)
        {
            canMove = false;
            _turnBehaviour.CanAttack();
        }
        if(canMove)
        {
            Movement();
        }
    }
    void Movement()
    {
        transform.Translate(-5 * Time.deltaTime, 0, 0);
    }
}
