using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Limites : MonoBehaviour
{
    [Header("Configurar en el editor")]
    public float radio              = 1f;
    public bool  mantenerEnPantalla = false;

    [Header("Configuraciones dinámicas")]
    public bool  EstaENPantalla = true;
    public float anchoCamara;
    public float altoCamara;
    public bool  salioArriba, salioAbajo, salioDerecha, salioIzquierda;

    public void Awake()
    {
        altoCamara = Camera.main.orthographicSize;
        anchoCamara = Camera.main.aspect * altoCamara;
        
    }

    public void LateUpdate()
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
        if (pos.y > altoCamara-4 - radio)
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
        if(mantenerEnPantalla && !EstaENPantalla)
        {
            transform.position = pos;
            EstaENPantalla = true;
        }
    }

    private void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Vector3 tamañoBorde = new Vector3(anchoCamara * 2, altoCamara * 2, 0.1f);
        Gizmos.DrawWireCube(Vector3.zero, tamañoBorde);
    }
}
