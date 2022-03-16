using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BloqueBase : MonoBehaviour
{
    //Variables a heredar
    public int          resistance;
    public int         pointsScore;
    public string         material;
    public PuntajeAlto    pointsSO;
    

    //Asignación de valores individuales
    public  virtual void Start()
    {
        resistance  =                    1;
        material    =               "Base";
        pointsScore =                   10;
    }

    //Metodos a heredar
    public void Update()
    {
        if (resistance <= 0)
        {
            pointsSO.puntaje += pointsScore;
            Destroy(this.gameObject);
        }
    }

    //En contacto con la bola(Heredado)
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            BallCollision(collision);
        }        
    }
    public virtual void BallCollision(Collision collision)
    {
        GameObject ball = GameObject.FindGameObjectWithTag("ball");
        Ball force = ball.GetComponent<Ball>();
        resistance -= force.ballForce;
        Vector3 direction = collision.contacts[0].point - transform.position;
        direction = direction.normalized;
        if      (material == "Base")     force.ballSpeed = 20;
        else if (material == "Wood")     force.ballSpeed = 30;
        else if (material == "Rock")     force.ballSpeed = 15;
        else if (material == "SpecialA") force.ballSpeed = 35;
        else if (material == "SpecialB") force.ballSpeed = 35;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().ballSpeed * direction;       
    }

}
