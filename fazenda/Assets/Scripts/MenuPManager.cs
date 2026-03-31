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

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif

    }

}
