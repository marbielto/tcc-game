using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private bool atacando;
    public Animator animator;

    public Transform ataquePoint;
    public float ataqueRanger = 0.5f;
    public LayerMask enemyLayers;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        atacando = Input.GetKeyDown("z");

        if(atacando == true)
        {
            Ataque();
        }

        void Ataque()
        {
            // vai ser a animação de ataque
            animator.SetTrigger("Attacking");

            // vai ser a ranger de ataque de acertar o nosso inimigo;
            Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(ataquePoint.position, ataqueRanger, enemyLayers);

            foreach(Collider2D enemy in hitEnemies)
            {
                enemy.GetComponent<EnemyDeath>().DanoNoInimigo(100);
            }

            // vai ser o dano no inimigo;


        
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(ataquePoint.position, ataqueRanger);
    }
}
