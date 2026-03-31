using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class MenuManager : MonoBehaviour
{
    public void ReturnToMainMenu()
    {

        SceneManager.LoadScene("Menu");
        
    }
}
