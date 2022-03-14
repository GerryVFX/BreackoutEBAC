using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    //Variables para vinvular puntaje a la UI
    public Transform   transPuntajeActual;
    public Transform   transMejorPuntaje;
    public TMP_Text    PuntajeActual;
    public TMP_Text    MejorPuntaje;
    public PuntajeAlto puntajeAltoSO;
    

    // Start is called before the first frame update
    void Start()
    {
        //Declaraciíon de variables para TMPTEXT de UI
        transPuntajeActual = GameObject.Find("PuntajeActual").transform;
        transMejorPuntaje  = GameObject.Find("MejorPuntaje").transform;
        PuntajeActual      = transPuntajeActual.GetComponent<TMP_Text>();
        MejorPuntaje       = transMejorPuntaje.GetComponent<TMP_Text>();

        puntajeAltoSO.Cargar();
        MejorPuntaje.text = $"Mejor Puntaje: {puntajeAltoSO.puntajeAlto}";
        puntajeAltoSO.puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //Vinculación de puntaje a UI       
        PuntajeActual.text = $"Puntaje Actual: {puntajeAltoSO.puntaje}";
        if (puntajeAltoSO.puntaje > puntajeAltoSO.puntajeAlto)
        {
            puntajeAltoSO.puntajeAlto = puntajeAltoSO.puntaje;
            MejorPuntaje.text = $"Mejor Puntaje: {puntajeAltoSO.puntajeAlto}";
            puntajeAltoSO.Guardar();
        }
    }

    public void AumentarPuntaje(int puntos)
    {
        puntajeAltoSO.puntaje += puntos;
    }
}
