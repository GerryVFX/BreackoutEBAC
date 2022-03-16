using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limites : MonoBehaviour
{
    [Header("Configurar en el editor")]
    public float radio              = 0.5f;
    public bool  mantenerEnPantalla = false;

    [Header("Configuraciones din�micas")]
    public bool  EstaENPantalla = true;
    public float anchoCamara;
    public float altoCamara;
    public bool  salioArriba, salioAbajo, salioDerecha, salioIzquierda;

    //Variables para limitar bola
    public GameObject ball;
    public Ball       ball_S;
           Vector3    ultimaPosici�n = Vector3.zero;
           Vector3    direccion = Vector3.zero;
    new    Rigidbody  rigidbody;

    public void Awake()
    {
        altoCamara  = Camera.main.orthographicSize;
        anchoCamara = Camera.main.aspect * altoCamara;

        ball      = GameObject.FindGameObjectWithTag("ball");
        ball_S    = ball.GetComponent<Ball>();
        rigidbody = ball.GetComponent<Rigidbody>();
    }

    public void Update()
    {
        BallExitDetection();
    }

    public void LateUpdate()
    {
        LimitDetection();
    }

    public void ActivarLimites()
    {
       enabled = true;
    }

    //Dibujar Gizmos
    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 tama�oBorde = new Vector3(anchoCamara * 2, altoCamara * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, tama�oBorde);
    }

    //Funci�n para rebotar a la pelota seg�n donde colisiona
    public void BallExitDetection()
    {
        if (salioAbajo)
        {
            Destroy(ball);
        }
        else if (salioArriba)
        {
            direccion = transform.position - ultimaPosici�n;
            print("Toco la parte superior");
            direccion.y *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = ball_S.ballSpeed * direccion;
            salioArriba = false;
            enabled = false;
            Invoke("ActivarLimites", 0.0f);
        }
        else if (salioDerecha)
        {
            direccion = transform.position - ultimaPosici�n;
            print("Toco la parte derecha");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = ball_S.ballSpeed * direccion;
            salioDerecha = false;
            enabled = false;
            Invoke("ActivarLimites", 0.0f);
        }
        else if (salioIzquierda)
        {
            direccion = transform.position - ultimaPosici�n;
            print("Toco la parte izquierda");
            direccion.x *= -1;
            direccion = direccion.normalized;
            rigidbody.velocity = ball_S.ballSpeed * direccion;
            salioIzquierda = false;
            enabled = false;
            Invoke("ActivarLimites", 0.0f);
        }
    }

    //FUnci�n para detectar que la pelota sale del l�mite
    public void LimitDetection()
    {
        Vector3 pos = transform.position;
        EstaENPantalla = true;
        salioAbajo = salioArriba = salioDerecha = salioIzquierda = false;

        if (pos.x > anchoCamara - radio)
        {
            pos.x = anchoCamara - radio;
            salioDerecha = true;
        }
        if (pos.x < -anchoCamara + radio)
        {
            pos.x = -anchoCamara + radio;
            salioIzquierda = true;
        }
        if (pos.y > altoCamara - 2 - radio)
        {
            pos.y = altoCamara - radio;
            salioArriba = true;
        }
        if (pos.y < -altoCamara + radio)
        {
            pos.y = -altoCamara + radio;
            salioAbajo = true;
        }

        EstaENPantalla = !salioAbajo || salioArriba || salioDerecha || salioIzquierda;
        if (mantenerEnPantalla && !EstaENPantalla)
        {
            transform.position = pos;
            EstaENPantalla = true;
        }
    }
}
