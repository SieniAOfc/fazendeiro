using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;
using TMPro;


public class PlayerControlA : MonoBehaviour
{

    public float speed = 20f;
    public float xRange = 15;
    public GameObject projectilePrefab;

    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;
    private InputAction pauseAction;
    private InputAction ghostAction;
    private bool Pause = false;
    public GameObject Pausado;
    public GameObject ghost;

    void Start()
    {

        Pause = false;
        Pausado.SetActive(false);
        ghost = GameObject.Find("/Player/SF_Character_FarmersWife");

    }

    private void OnEnable()
    {

        InputActions.FindActionMap("Player").Enable();
        InputActions.FindActionMap("UI").Disable();
        Pause = false;
        pauseAction = InputSystem.actions.FindAction("Pause");
        Pausado.SetActive(false);

    }

    private void OnDisable()
    {

        InputActions.FindActionMap("Player").Disable();
        InputActions.FindActionMap("UI").Enable();
        Pause = true;
        pauseAction = InputSystem.actions.FindAction("Pause");
        Pausado.SetActive(true);

    }

    private void Awake()
    {

        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        ghostAction = InputSystem.actions.FindAction("ghost");

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

        if(pauseAction.WasPressedThisFrame())
        {

            if(Pause == false)
            {

                OnDisable();

            } else
            {

                OnEnable();

            }
    
        }

        if(ghostAction.WasPressedThisFrame())
        {

            ghost.SetActive(false);

        }

    }

}
   
