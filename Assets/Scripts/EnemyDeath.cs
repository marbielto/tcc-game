using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    private int vidaAtual = 100;

    public void DanoNoInimigo(int dano)
    {   
        vidaAtual -= dano;

        if(vidaAtual <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
