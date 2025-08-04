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
    public float velocidade = 4f; // Variável para ajustar a velocidade

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

        // Usa a variável de velocidade para controlar o deslocamento
        transform.position = Vector2.MoveTowards(transform.position, currentTarget.position, velocidade * Time.deltaTime);

        // Ajusta a direção do inimigo
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
