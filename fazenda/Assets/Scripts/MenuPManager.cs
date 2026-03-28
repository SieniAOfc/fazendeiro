using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class MenuPManager : MonoBehaviour
{
    
    [SerializeField] private string nomeLvGame;

    public void Play()
    {
        
        SceneManager.LoadScene(nomeLvGame);
        
    }

    public void ExitGame()
    {

        Application.Quit();


    }

}
