using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BloqueBase : MonoBehaviour
{
    public int         recistencia;
    public int         fuerzaRebote;
    public UnityEvent aumentarPuntos;

    //public PuntajeAlto puntajeALtoSO;


    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            RebotarBola(collision);
        }
    }

    public virtual void RebotarBola(Collision collision)
    {
        Vector3 direccion = collision.contacts[0].point - transform.position;
        direccion = direccion.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Ball>().ballSpeed * direccion;
        recistencia--;
    }

    void Start()
    {
        
        
        recistencia = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        DestrucionDeBloque();
        RebotarBola();
    }

    public virtual void RebotarBola()
    {
        
    }

    public virtual void DestrucionDeBloque()
    {
        if (recistencia <= 0) Destroy(this.gameObject);
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.tag == "ball")
    //    {
    //        GameObject mispuntos=GameObject.Find("Display");
    //        puntajeALtoSO.puntaje += 20;
            
    //    }
    //}
}
