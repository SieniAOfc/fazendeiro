using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //

public class PlayerController : MonoBehaviour
{
    public float speed = 20f;
    public float xRange = 15f;
    public GameObject projectilePrefab;
    public float horizontalInput;

    // Update is called once per frame
    void Update()
    {
        // float horizontalInput = Input.GetAxis("Horizontal");
        // movimenta o player para esquerda e direita a partir da entrada do usu�rio
        transform.Translate(Vector3.right * speed * Time.deltaTime * horizontalInput);
        // mant�m o player dentro dos limites do jogo (eixo x)
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.y);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.y);
        }
        
    }

    public void MoveEvent(InputAction.CallbackContext context)
    {

        horizontalInput = context.ReadValue<Vector2>().x;

    }

    public void FireEnvent(InputAction.CallbackContext context)
    {

        Debug.Log("Disparou pizza");
        Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

    }
}
