using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{   
    Character Player;
    public Animator anim2;



    // Start is called before the first frame update
    void Start()
    {
        Player = gameObject.transform.parent.gameObject.GetComponent<Character>();
    }

    void OnCollisionEnter2D(Collision2D collisor)
    {
        if(collisor.gameObject.layer == 8)
        {   
            anim2.SetBool("Jumping", false);
            Player.isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collisor)
    {   
        if(collisor.gameObject.layer == 8)
        {   
            anim2.SetBool("Jumping", true);
            Player.isJumping = true;
        }

    }

}
