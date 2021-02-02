using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rb;

    public int speed = 0;
    public int health = 3;

    public float jumpHeight;

    public bool playerCanJump;
    public bool playerCanMove;

    public GameObject bullet;
    public GameObject bulletSpawner;
    public GameObject bomb;
    public GameObject knife;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if(playerCanMove)
        {
            Movement();
        }
        if(playerCanJump)
        {
            Jump();
        }
        if(health==0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        Shoot();
    }
    void Movement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5 * speed, 0);
            transform.Rotate(new Vector3(0, 180, 0));
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5 * speed, 0);
            transform.Rotate(new Vector3(0, 180, 0));
        }
        if ((Input.GetKeyUp(KeyCode.D)) || (Input.GetKeyUp(KeyCode.A)))
        {
            rb.velocity = Vector2.zero;
        }
    }
    void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = transform.up * jumpHeight;
        }
    }
    void Shoot()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Instantiate(bullet,bulletSpawner.transform.position, bulletSpawner.transform.rotation);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(knife, bulletSpawner.transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            Instantiate(bomb, bulletSpawner.transform.position, transform.rotation);
        }
    }
    private void OnCollisionEnter2D(Collision2D cd)
    {
        if(cd.gameObject.tag=="Platform")
        {
            playerCanJump = true;
            playerCanMove = true;
        }
        if (cd.gameObject.tag == "Crowd")
        {
            health = 0;
        }
        if (cd.gameObject.tag == "Enemy")
        {
            health -= 1;
        }
    }
    private void OnCollisionStay2D(Collision2D cd)
    {
        if (cd.gameObject.tag == "Platform")
        {
            playerCanJump = true;
            playerCanMove = true;
        }
    }
    private void OnCollisionExit2D(Collision2D cd)
    {
        if (cd.gameObject.tag == "Platform")
        {
            playerCanJump = false;
            StartCoroutine(CanMove());
        }
    }
    IEnumerator CanMove()
    {
        yield return new WaitForSeconds(0.5f);
        playerCanMove = false;
    }
    private void OnTriggerEnter2D(Collider2D cd)
    {
        if(cd.gameObject.tag == "EnemyBullet")
        {
            health -= 1;
            Destroy(cd.gameObject);
        }
    }
}
