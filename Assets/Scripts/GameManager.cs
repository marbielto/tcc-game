using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public GameObject gameOverUI;
    public GameObject YouWin;
    public GameObject Credits;
    public GameObject MainMenu;
    



    public void startGame()
    {
        SceneManager.LoadScene("Jogo");

    }

    public void OpenURL()
    {
        Application.OpenURL("https://www.linkedin.com/in/marcos-gabriel-barreto-13ab2b164/?originalSubdomain=brhttps://www.linkedin.com/in/marcos-gabriel-barreto-13ab2b164/");
        Debug.Log("abriu o link");
    }

    public void returnMenu()
    {
        Credits.SetActive(false);
        MainMenu.SetActive(true);
    }

    public void credits()
    {
        Credits.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void gameOver()
    {
        gameOverUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {   
            
            YouWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
    
    public void quit()
    {   
        Debug.Log("Saiu do jogo");
        Application.Quit();
        
    }

    
}
