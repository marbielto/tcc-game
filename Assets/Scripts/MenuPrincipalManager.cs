using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipalManager : MonoBehaviour
{   
    [SerializeField] private string nomeDoLevelDeJogo;
    [SerializeField] private GameObject painelMenuInicial;
    [SerializeField] private GameObject painelOpcoes;
    public string sceneName;

    public void Jogar()
    {
       Time.timeScale = 1f;
       SceneManager.LoadScene(nomeDoLevelDeJogo);
    }

    public void AbreCreditos()
    {
        painelMenuInicial.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    public void SaiCreditos()
    {
        painelMenuInicial.SetActive(true);
        painelOpcoes.SetActive(false);
    }

    public void SairJogo()
    {   
        Debug.Log("fechou o jogo");
        Application.Quit();
    }
    
    public void LoadScene()
    {
        Time.timeScale = 1f; // Garante que o tempo volte ao normal caso esteja pausado
        SceneManager.LoadScene(sceneName); // Carrega a cena específica
    }

    public void OpenURL()
    {
        Application.OpenURL("https://www.linkedin.com/in/marcos-gabriel-barreto-13ab2b164/?originalSubdomain=brhttps://www.linkedin.com/in/marcos-gabriel-barreto-13ab2b164/");
        Debug.Log("abriu o link");
    }
}
