using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{   
    public GameObject victoryCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        if(victoryCanvas != null)
        {
            victoryCanvas.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {   
        Debug.Log("Algo entrou no checkpoint: " + other.gameObject.name); // Exibe no console

        if(other.CompareTag("Player"))
        {   
            Debug.Log("Checkpoint ativado!"); // Mensagem de depuração
            if(victoryCanvas != null)
            {
                victoryCanvas.SetActive(true);
                Time.timeScale = 0f;
            }
        }
    }
}
