using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public Transform transPuntajeActual;
    public Transform transMejorPuntaje;
    public TMP_Text  PuntajeActual;
    public TMP_Text  MejorPuntaje;
    public int       puntos = 0;
    public int       mejorPuntos;

    // Start is called before the first frame update
    void Start()
    {
        transPuntajeActual = GameObject.Find("PuntajeActual").transform;
        transMejorPuntaje  = GameObject.Find("MejorPuntaje").transform;
        PuntajeActual      = transPuntajeActual.GetComponent<TMP_Text>();
        MejorPuntaje       = transMejorPuntaje.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {
        MejorPuntaje.text = $"Mejor Puntaje: {mejorPuntos}";

        PuntajeActual.text = $"Puntaje Actual: {puntos}";
        if (puntos > mejorPuntos)
        {
            mejorPuntos = puntos;
            
        }
    }
}
