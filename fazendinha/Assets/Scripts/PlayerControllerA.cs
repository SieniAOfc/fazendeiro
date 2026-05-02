using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;


public class PlayerControllerA : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15;
    public GameObject projectilePrefab;

    public InputActionAsset InputActions;
    private InputAction moveAction;
    private InputAction fireAction;

    private InputAction pauseActionPlayer;
    private InputAction pauseActionUI;
    public GameObject Pausado;

    private InputAction ghostAction;
    public GameObject ghost;
    public bool BGhost;
    
    private int vida;
    private int vidaM = 3;
    [SerializeField] Image vidaOn1;
    [SerializeField] Image vidaOff1;

    [SerializeField] Image vidaOn2;
    [SerializeField] Image vidaOff2;

    [SerializeField] Image vidaOn3;
    [SerializeField] Image vidaOff3;


    //mecanica gato
    public GameObject gato;
    private InputAction gatoAction;
    private bool podeUGato = false;
    public Slider Stamina;
    public Button bGM;
    

    void Start()
    {

        vida = vidaM;

        ghost = GameObject.Find("/Player/SF_Character_FarmersWife"); // variavel ghost é igual ao gameobject do player

        if(bGM != null) //desativa a interacao com o botao gato
        {
            
            bGM.interactable = false;

        }

    }

    private void OnEnable()
    {
        InputActions.FindActionMap("Player").Disable();
        InputActions.FindActionMap("UI").Disable();
        InputActions.FindActionMap("Player").Enable();
        Time.timeScale = 1f;
        
    }

    private void OnDisable()
    {
        InputActions.FindActionMap("Player").Disable();
        InputActions.FindActionMap("UI").Disable();
    }

    private void Awake()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        fireAction = InputSystem.actions.FindAction("Jump");
        ghostAction = InputSystem.actions.FindAction("ghost");
        gatoAction = InputSystem.actions.FindAction("gato");
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

        if (podeUGato && gatoAction.WasPressedThisFrame())
        {
            GameObject.Find("Placar").GetComponent<Placar>().PontosGatito(20);
            Stamina.gameObject.SetActive(true); //ativa a barra de stamina
            float tempoGato = gato.GetComponent<Gato>().tempVida; //tempo do gato é igual ao tempo vida no script do gato
            Stamina.maxValue = tempoGato; //define o maximo
            Stamina.value = tempoGato;    //enche a barra no maximo
            Instantiate(gato, transform.position, Quaternion.Euler(90,0,0)); //instancia o gato na transform.position e evita que ele nasca deitado
            podeUGato = false; //so pode usar 1 vez por ativacao
            if(bGM != null) //se o botao do gato nao for nulo, desativa a interacao
            {
                
                bGM.interactable = false;

            }

        }

        if (Stamina != null && Stamina.gameObject.activeSelf) 
        {
            Stamina.value -= Time.deltaTime;

            if (Stamina.value <= 0) 
            {

                Stamina.gameObject.SetActive(false);
                
            }
        }

        
        if(ghostAction.WasPressedThisFrame())
        {

            ghost.SetActive(false); //
            BGhost = true;
            StartCoroutine(Ghost(2));

        }

        PauseGame();
        

    }

    private IEnumerator Ghost(float waitTime)
    {

        
        yield return new WaitForSeconds(waitTime);
        ghost.SetActive(true);
        BGhost = false;

    }

    private void PauseGame()
    {

        if(pauseActionPlayer.WasPressedThisFrame())
        {

            InputActions.FindActionMap("Player").Disable();
            InputActions.FindActionMap("UI").Enable();
            Pausado.SetActive(true);
            Time.timeScale = 0f;
            
    
        } else if(pauseActionUI.WasPressedThisFrame())
        {

            InputActions.FindActionMap("UI").Disable();
            InputActions.FindActionMap("Player").Enable();
            Pausado.SetActive(false);
            Time.timeScale = 1f;

        }

    }

    private void OnTriggerEnter(Collider col)
    {

        if(col.gameObject.CompareTag("AnimalD"))
        {

            if(BGhost == true) //se o fantasma estiver ativo, retorna 0;
            {
                return;
            }
            else
            {
                Dano();
            }
            

        }
        
    }

    private void Dano()
    {
        
        vida -= 1; //tira vida do player de um em um

        if(vida == 2)
        {
            
            vidaOn3.enabled = true;  //manter o 3 coracao vazio habilitado
            vidaOff3.enabled = false;  //e desabilita o 3 coracao cheio

        }

        if(vida == 1)
        {

            vidaOn2.enabled = true;  //manter 2 o coracao vazio habilitado
            vidaOff2.enabled = false; //e desabilita o 2 coracao cheio

        }

        if (vida <= 0)
        {   

            vidaOn1.enabled = true; //manter 1 o coracao vazio habilitado
            vidaOff1.enabled = false; //e desabilita o 1 coracao cheio

            GameObject.Find("MenuManager").GetComponent<MenuManager>().GameOver();

        }

    }

    public void LiberarGato() //chamdo pelo Placar
    {
        
        if(podeUGato || Stamina.gameObject.activeSelf) //se pode ir gato e a stamina estiverem ativa, retorna zero
        {

            return;

        }

        podeUGato = true; //pode ativar 1 vez

        if(bGM != null) //ativa a interacao com o botao gato
        {
            
            bGM.interactable = true;

        }

    }


}
