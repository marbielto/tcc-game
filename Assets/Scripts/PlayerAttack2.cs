using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack2 : MonoBehaviour
{   
    private bool atacando = false;
    public Animator animator;
    public Transform ataquePoint;
    public float ataqueRanger = 0.5f;
    public LayerMask enemyLayers;
    private float tempoDeAtaque = 0.01f;
    private float tempoAtualDeAtaque = 0f;

    public Transform checadorDeChao; // Ponto abaixo do personagem para verificar o chão
    public float raioChao = 0.2f; // Raio do detector de chão
    public LayerMask camadaChao; // Camada que representa o chão

    void Update()
    {
        tempoAtualDeAtaque -= Time.deltaTime;

        if (Input.GetKeyDown("z") && tempoAtualDeAtaque <= 0 && !atacando && EstaNoChao())
        {
            Ataque();
            tempoAtualDeAtaque = tempoDeAtaque;
        }
    }

    void Ataque()
    {
        atacando = true;
        animator.SetTrigger("Attacking");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(ataquePoint.position, ataqueRanger, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyDeath>().DanoNoInimigo(100);
        }

        StartCoroutine(ResetarAtaque());
    }

    IEnumerator ResetarAtaque()
    {
        yield return new WaitForSeconds(0.01f);
        atacando = false;
    }

    private bool EstaNoChao()
    {
        return Physics2D.OverlapCircle(checadorDeChao.position, raioChao, camadaChao);
    }

    private void OnDrawGizmosSelected()
    {
        if (ataquePoint != null)
        {
            Gizmos.DrawWireSphere(ataquePoint.position, ataqueRanger);
        }
        if (checadorDeChao != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(checadorDeChao.position, raioChao);
        }
    }
}
