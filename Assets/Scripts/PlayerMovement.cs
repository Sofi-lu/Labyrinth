using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public float velocidad = 8.0f, rotacion = 200.0f, a, b;

    void Start()
    {
        
    }

     void Update()
    {
        a=Input.GetAxis("Vertical");
        b=Input.GetAxis("Horizontal");

        transform.Rotate(0,b* Time.deltaTime * rotacion,0);
        transform.Translate(0,0,a* Time.deltaTime * velocidad);


    }

}
