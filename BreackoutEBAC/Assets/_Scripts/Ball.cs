using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    //Variables de base
    public int ballForce;
    public float ballSpeed = 20f;
    Transform transform_P;

   
    void Start()
    {
        //Fuerza base (Normal)
        ballForce = 2;

        //Posición inicial 
        transform_P = GameObject.FindGameObjectWithTag("Player").transform;
        Vector3 inicial = transform_P.position;
        inicial.y += 1.6f;
        transform.position = inicial;
        transform.SetParent(transform_P);
    }

}
