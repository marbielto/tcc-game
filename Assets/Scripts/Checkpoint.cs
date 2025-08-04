using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{   
    public GameObject victoryCanvas;
    public GameObject checkpointFlag;
    private bool isActivated = false;

    private void Start()
    {
        if (victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        if (other.CompareTag("Player") && !isActivated)
        {   
            if (EnemyManager.Instance.AllEnemiesDefeated())
            {
                Debug.Log("Checkpoint ativado!");
                isActivated = true;
                if (victoryCanvas != null)
                {
                    victoryCanvas.SetActive(true);
                    checkpointFlag.SetActive(true);
                    Time.timeScale = 0f;
                }
            }
            else
            {
                Debug.Log("Ainda há inimigos vivos!");
            }
        }
    }
}