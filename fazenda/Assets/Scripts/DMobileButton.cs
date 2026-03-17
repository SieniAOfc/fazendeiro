using UnityEngine;
using UnityEngine.InputSystem;

public class DMobileButton : MonoBehaviour
{

    void Start()
    {

        if (Application.platform != RuntimePlatform.Android)
        {

            gameObject.SetActive(false);

        }
        
    }
}
