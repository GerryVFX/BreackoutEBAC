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
    public Vector3       direction;



    //Asignación de valores individuales
    public  virtual void Start()
    {
        resistance  =                    1;
        material    =               "Base";
        pointsScore =                   10;
        direction   = direction.normalized;
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
        direction = collision.contacts[0].point - transform.position;
        direction = direction.normalized;
        if      (material == "Base") force.ballSpeed = 25;
        else if (material == "Wood") force.ballSpeed = 35;
        else if (material == "Rock") force.ballSpeed = 15;
        else if (material == "SpecialA") force.ballSpeed = 40;
        else if (material == "SpecialA") force.ballSpeed = 40;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().ballSpeed * direction;
       

    }

   

    

   

    //public int         recistencia;
    //public int         fuerzaRebote;
    //public UnityEvent aumentarPuntos;

    ////public PuntajeAlto puntajeALtoSO;


    //public void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.tag == "ball")
    //    {
    //        RebotarBola(collision);
    //    }
    //}

    //public virtual void RebotarBola(Collision collision)
    //{
    //    Vector3 direccion = collision.contacts[0].point - transform.position;
    //    direccion = direccion.normalized;
    //    collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().ballSpeed * direccion;
    //    recistencia--;
    //}

    //void Start()
    //{


    //    recistencia = 1;

    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    DestrucionDeBloque();
    //    RebotarBola();
    //}

    //public virtual void RebotarBola()
    //{

    //}

    //public virtual void DestrucionDeBloque()
    //{
    //    if (recistencia <= 0) Destroy(this.gameObject);
    //}

    
}
