using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Placar : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI TXT_PN;
    [SerializeField] private TextMeshProUGUI TXT_PNG;
    public PlayerControllerA player;
    
    private int pontos = 0;
    private int pontosGato = 0;

    public void AddPontos(int valor)
    {
        pontos += valor;
        pontosGato += valor;
        if (TXT_PN != null)
        {

            TXT_PN.text = "" + pontos;
        
        }

        /*if(pontos >= 20)
        {
            
            player.LiberarGato();

        }*/
    }

    public void PontosGatito(int catValor)
    {
        pontosGato -= catValor;
    }

    void Update()
    {

        if(pontosGato >= 20)
        {
            
            player.LiberarGato();
            
        }
        if (TXT_PNG != null)
        {

            TXT_PNG.text = "" + pontosGato;
        
        }
    }
}
