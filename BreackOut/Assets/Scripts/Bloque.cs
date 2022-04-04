using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bloque : MonoBehaviour
{
    public int recistencia=1;
    public GameManager gameGM;
    public GameObject bolaPF;
    private Bola bolaSC;
    public int punto;
    public Puntaje_Alto puntos;
    public string material = "Base";
    public int ball_force;
    public GameObject pad;
    public Opciones opcion;


    void Start()
    {
        pad = GameObject.Find("Pad");
        gameGM = GameObject.FindObjectOfType<GameManager>();
        punto = 10;
    }

    
    public void Update()
    {

        if (opcion.nivelDificultad == Opciones.dificultad.facil)
        {
            ball_force = 3;
        }
        else if (opcion.nivelDificultad == Opciones.dificultad.normal)
        {
            ball_force = 2;
        }
        else if (opcion.nivelDificultad == Opciones.dificultad.dificil)
        {
            ball_force = 1;
        }

        if (recistencia <= 0)
        {
            puntos.puntaje += punto;
            Destroy(this.gameObject);
        }
        if (recistencia <= 0 && material == "SpecialA")
        {
            var bola = Instantiate(bolaPF) as GameObject;
            bolaSC = bolaPF.GetComponent<Bola>();
            bola.transform.position = this.transform.position;
            gameGM.n_bolas += 1;
           
        }
        if (recistencia <= 0 && material == "SpecialB")
        {
            pad.GetComponent<Jugador>().StartCoroutine("PowerUp");

        }

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            RebotarBola(collision);
        }
    }

    public virtual void RebotarBola(Collision collision)
    {
        Vector3 direction = collision.contacts[0].point - transform.position;
        direction = direction.normalized;
        collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().bola_Speed * direction;
        recistencia -=ball_force;
    }

    
}
