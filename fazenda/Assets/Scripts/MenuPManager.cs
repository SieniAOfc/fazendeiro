using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;


public class MenuPManager : MonoBehaviour
{
    
    public void Play()
    {
        
        SceneManager.LoadScene("Game");

    }

    public void ExitGame()
    {

    }

}
