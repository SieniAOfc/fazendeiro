using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{

    public GameObject MenuP;
    public GameObject Confirm;

    public void ReturnToMainMenu()
    {

        SceneManager.LoadScene("Menu");
        
    }

    [SerializeField] private string nomeLvGame;

    public void Play()
    {
        
        SceneManager.LoadScene(nomeLvGame);
        
    }

    public void Exit()
    {
       
        MenuP.SetActive(false);
        Confirm.SetActive(true);

    }

    public void ExitNo()
    {
        
        MenuP.SetActive(true);
        Confirm.SetActive(false);

    }

    public void GameOver()
    {
    
        SceneManager.LoadScene("GameOver");

    }

    public void ExitYes()
    {

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }

}
