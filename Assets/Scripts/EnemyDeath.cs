using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private int vidaAtual = 200; // Começa com 200

    private void Start()
    {
        // Diminui a vida do inimigo com base nas mortes do jogador
        ReduzirVidaSeNecessario();

        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy(this);
        }
    }

    public void DanoNoInimigo(int dano)
    {   
        vidaAtual -= dano;

        if (vidaAtual <= 0)
        {
            if (EnemyManager.Instance != null)
            {
                EnemyManager.Instance.EnemyDefeated(this);
            }
            Destroy(gameObject);
        }
    }

    private void ReduzirVidaSeNecessario()
    {
        if (Character.deathCount >= 3)
        {
            int reducao = (Character.deathCount / 3) * 100;
            vidaAtual = Mathf.Max(100, 200 - reducao); // Vida mínima de 100
            Debug.Log("Vida do inimigo ajustada para: " + vidaAtual);
        }
    }
}
