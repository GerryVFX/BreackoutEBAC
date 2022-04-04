using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bola : MonoBehaviour
{
    //Variables para mover bola
    public bool juego_Comenzo;
    public int bola_Speed;
    Rigidbody bola_Rig;
   
    //Variables para control de numero de bolas
    public GameManager gameMG;
    //Variables modificar dificultad
    public Opciones opcion;

    //Variables para control de limites
    Vector3 ultimaPos = Vector3.zero;
    Vector3 direction = Vector3.zero;
    private ControlBordes control;
      
    public void Awake()
    {
        //Declaración variables
        gameMG = GameObject.FindObjectOfType<GameManager>();
        control = GetComponent<ControlBordes>();
        bola_Rig = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Primera Bola
        if (!juego_Comenzo && gameMG.n_bolas <= 1)
            PosInicial();    
        //Bpola adicional
        else 
            bola_Rig.velocity = bola_Speed * Vector3.down;
    }
 
    void Update()
    {
        //Checar bordes y dificultad
        Limites();
        Dificultad();

        //Condición para lanzar bola
        if (!juego_Comenzo && gameMG.n_bolas <= 1)
        {
            LanzarBola();
        }             
    }

    //Funciona con limites
    public void FixedUpdate()
    {
        ultimaPos = transform.position;
    }

    public void LateUpdate()
    {
        if (direction != Vector3.zero) direction = Vector3.zero;
    }

    //Posicionamiento inicial
    void PosInicial()
    {
        Vector3 posInicial = FindObjectOfType<Jugador>().transform.position;
        posInicial.y += 2;
        this.transform.position = posInicial;
        this.transform.SetParent(FindObjectOfType<Jugador>().transform);
    }

    void LanzarBola()
    {
        if (Input.GetButton("Submit")||Input.GetMouseButtonDown(1))
        {
            juego_Comenzo = true;
            this.transform.SetParent(null);
            BolaMove();
        }
    }

    //Solo movimiento
    public virtual void BolaMove()
    {

        bola_Rig.velocity = bola_Speed *  Vector3.up;
    }

    //Para limites en pantalla
    public void Limites()
    {
        if (this.control.salioAbajo)
        {
            gameMG.n_bolas -= 1;
            Destroy(this.gameObject);
        }
        if (this.control.salioArriba)
        {
            direction = transform.position - ultimaPos;
            print("Salio por arriba");
            direction.y *= -1;
            direction = direction.normalized;
            bola_Rig.velocity = bola_Speed * direction;
            this.control.salioArriba = false;
            this.control.enabled = false;
            Invoke("HabilitarControl", 0.05f);
        }
        if (this.control.salioDerecha)
        {
            direction = transform.position - ultimaPos;
            print("Salio por derecha");
            direction.x *= -1;
            direction = direction.normalized;
            bola_Rig.velocity = bola_Speed * direction;
            this.control.salioDerecha = false;
            this.control.enabled = false;
            Invoke("HabilitarControl", 0.05f);
        }
        if (this.control.salioIzquierda)
        {
            direction = transform.position - ultimaPos;
            print("Salio por izquierda");
            direction.x *= -1;
            direction = direction.normalized;
            bola_Rig.velocity = bola_Speed * direction;
            this.control.salioIzquierda = false;
            this.control.enabled = false;
            Invoke("HabilitarControl", 0.05f);
        }
    }

    private void HabilitarControl()
    {
        control.enabled = true;
    }

    //Para colisión con otra bola
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bola")
        {
            Vector3 direction = collision.contacts[0].point - transform.position;
            direction = direction.normalized;
            collision.rigidbody.velocity = collision.gameObject.GetComponent<Bola>().bola_Speed * direction;
        }
    }
    //Modificador de dificultad
    public void Dificultad()
    {
        if (opcion.nivelDificultad == Opciones.dificultad.facil)
        {
            bola_Speed = 20;
        }
        else if (opcion.nivelDificultad == Opciones.dificultad.normal)
        {
            bola_Speed = 25;
        }
        else if (opcion.nivelDificultad == Opciones.dificultad.dificil)
        {
            bola_Speed = 35;
        }
    }
}
