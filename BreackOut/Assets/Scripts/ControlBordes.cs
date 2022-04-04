using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBordes : MonoBehaviour
{
    [Header("Configurar en el editor")]
    public float radio = 1f;
    public bool mantenerEnPantalla = false;

    [Header("Configuraciones dinámicas")]
    public bool estaEnPantalla = true;
    public float anchoCamara;
    public float altoCamara;
    public bool salioArriba, salioAbajo, salioDerecha, salioIzquierda;

    public void Awake()
    {
        altoCamara = Camera.main.orthographicSize;
        anchoCamara = Camera.main.aspect * altoCamara;
    }

    public void LateUpdate()
    {
        Vector3 pos = transform.position;
        estaEnPantalla = true;
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
        if (pos.y > anchoCamara -17 - radio)
        {
            pos.y = anchoCamara - radio;
            salioArriba= true;
        }
        if (pos.y < -anchoCamara + radio)
        {
            pos.y = -anchoCamara + radio;
            salioAbajo = true;
            
        }

        estaEnPantalla = !(salioAbajo || salioArriba || salioDerecha || salioIzquierda);

        if(mantenerEnPantalla && !estaEnPantalla)
        {
            transform.position = pos;
            estaEnPantalla = true;
        }
    }

    public void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 bordes = new Vector3(anchoCamara * 2, altoCamara * 2, 0.1f);
        Gizmos.DrawCube(Vector3.zero, bordes);
    }

}
