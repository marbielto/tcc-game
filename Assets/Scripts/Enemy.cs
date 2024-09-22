using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{   
    private Transform playerPosition;
    public SpriteRenderer sr;
    
    public Transform currentTarget;
    public Transform targetA;
    public Transform targetB;

    public Animator animEnemy;
    
    public float enemySpeed;

    void Start()
    {
        currentTarget = targetA;
    }
    

    // Update is called once per frame
    void Update()
    {
        if(currentTarget == targetA && transform.position == targetA.position)
        {
            currentTarget = targetB;
        }

        if(currentTarget == targetB && transform.position == targetB.position)
        {
            currentTarget = targetA;
        }

        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, 5 * Time.deltaTime);
        if (transform.position.x > currentTarget.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }

    /*private void followPlayer()
    {
        if(playerPosition.gameObject != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition.position, enemySpeed * Time.deltaTime);
        }


        float inputAxis = Input.GetAxis("Horizontal");

        if(inputAxis > 0)
        {
            transform.eulerAngles = new Vector2(0f, 180f);
        }

        if(inputAxis < 0)
        {
            transform.eulerAngles = new Vector2(0f, 0f);
        }

        if(Input.GetAxis("Horizontal") != 0)
        {      
            animEnemy.SetBool("enemyRun", true);
        }
        else
        {      
            animEnemy.SetBool("enemyRun", false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        /*if(collision.gameObject.tag == "Player")
        {
            //collision.gameObject.GetComponent<Animator>().SetTrigger("Dead");
            //collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.GetComponent<BoxCollider2D>().enabled = false;
            collision.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            collision.gameObject.GetComponent<Animator>().SetBool("Jump", false);
            Invoke("LoadScene", 1f);
        }*/

        

    void LoadScene()
    {
        SceneManager.LoadScene("Jogo");
    }
}
