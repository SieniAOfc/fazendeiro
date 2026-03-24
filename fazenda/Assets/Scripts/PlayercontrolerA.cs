using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;


public class PlayerControlerA : MonoBehaviour
{

    public float speed = 20f;
    public float xRange = 15;
    public GameObject projectilePrefab;

    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction pauseActionPlayer;
    private InputAction pauseActionUI;
    private InputAction ghostAction;
    public GameObject Pausado;
    public GameObject ghost;

    void Start()
    {

        ghost = GameObject.Find("/Player/SF_Character_FarmersWife");

    }

    private void OnEnable()
    {

        InputActions.FindActionMap("Player").Enable();

    }

    private void OnDisable()
    {

        InputActions.FindActionMap("Player").Disable();

    }

    private void Awake()
    {

        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        ghostAction = InputSystem.actions.FindAction("ghost");
        pauseActionPlayer = InputSystem.actions.FindAction("Player/Pause");
        pauseActionUI = InputSystem.actions.FindAction("UI/Pause");

    }

    void Update()
    {
        
        float horizontalInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        
        if (transform.position.x < -xRange)
        {

            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);

        }

        if (transform.position.x > xRange)
        {

            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);

        }

        if(fireAction.WasPressedThisFrame())
        {

            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

        }

        
        if(ghostAction.WasPressedThisFrame())
        {

            ghost.SetActive(false);
            StartCoroutine(Ghost(2));

        }

        PauseGame();

    }

    private IEnumerator Ghost(float waitTime)
    {

        
        yield return new WaitForSeconds(waitTime);
        ghost.SetActive(true);

    }

    private void PauseGame()
    {

        if(pauseActionPlayer.WasPressedThisFrame())
        {

            InputActions.FindActionMap("Player").Disable();
            InputActions.FindActionMap("UI").Enable();
            Pausado.SetActive(true);
    
        } else if(pauseActionUI.WasPressedThisFrame())
        {

            InputActions.FindActionMap("Player").Enable();
            InputActions.FindActionMap("UI").Disable();
            Pausado.SetActive(false);

        }

    }

}
   
