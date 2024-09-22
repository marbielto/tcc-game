using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{   
    private Transform playerPosition;
    public Animator animEnemy;
    
    public float enemySpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerPosition = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    private void followPlayer()
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
}
