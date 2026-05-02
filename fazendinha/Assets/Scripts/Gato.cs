using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Gato : MonoBehaviour
{

    public float vel = 50f;
    public float tempVida = 50f;
    private Rigidbody rb;

    void Start()
    {

        rb = GetComponent<Rigidbody>();
        transform.rotation = Quaternion.Euler(90, 0, 0); //ajusta a posição inicial para ele sempre nascer em x=90 e ficar visivel na tela

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            // Pega o colisor do gato e o do player e desliga a interação entre eles
            Physics.IgnoreCollision(GetComponent<Collider>(), player.GetComponent<Collider>());
        }

        rb.linearVelocity = new Vector3(1, 0, 1).normalized * vel; // serve pra ele se mover

        Destroy(gameObject, tempVida);
        
    }

    void Update()
    {

        transform.Rotate (0, 0, 1000 * Time.deltaTime, Space.Self); //se tiver capotando muda de 0,1000,0 para 0,0,1000 e usa o Space.Self pra nao bugar com o x=90
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.CompareTag("AnimalD")) //se bater no animal, destroi o animal e soma pontos no placar;
        {
            
            GameObject.Find("Placar").GetComponent<Placar>().AddPontos(1);
            Destroy(other.gameObject);

        }

    }
}
