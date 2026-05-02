using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
    public int pontos = 0;
    Placar placar;

    void Start()
    {

        placar = GameObject.Find("Placar").GetComponent<Placar>(); //procura o objeto Placar e pega o script nele

    }

    private void OnTriggerEnter(Collider other)
    {

        if(other.CompareTag("AnimalD"))
        {
            
            placar.AddPontos(1); //adiciona mais 1 ponto no  placar
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
        
    }
}
