using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{   
    public int maxLives = 3;
    private int currentLives;
    public Text lifeText;

    // Start is called before the first frame update
    void Start()
    {   
        currentLives = maxLives;
        UpdateLifeUI();
        
    }

    public void TakeDamage()
    {
        currentLives--;
        UpdateLifeUI();

        if(currentLives <= 0)
        {
            GameOver();
        }
    }

    // Update is called once per frame
    void UpdateLifeUI()
    {
        if(lifeText != null)
        {
            lifeText.text = "Vidas: " + currentLives;
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}
