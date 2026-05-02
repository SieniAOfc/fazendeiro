using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBound = 30f;
    private float lowerBound = -10f;
 
    void Update()
    {
        if (transform.position.z > topBound)
        {

            Destroy(gameObject);
            
        }
        if (transform.position.z < lowerBound)
        {

            Destroy(gameObject);

        }
    }

}
