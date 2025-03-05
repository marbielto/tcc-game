using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{   
    public Transform currentTarget;
    public SpriteRenderer sr;
    public Transform targetA;
    public Transform targetB;
    
    void Start()
    {
        currentTarget = targetA;
    }

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

        if(transform.position.x > currentTarget.position.x)
        {
            sr.flipX = false;
        }
        else
        {
            sr.flipX = true;
        }
    }
}
