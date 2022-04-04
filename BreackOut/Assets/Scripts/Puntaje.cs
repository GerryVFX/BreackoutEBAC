using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Puntaje : MonoBehaviour
{
    public Transform puntaje_Alto_TF;
    public Transform puntaje_TF;
    public TMP_Text puntaje_Alto_Txt;
    public TMP_Text puntaje_Txt;
    

    public Puntaje_Alto puntaje_Alto_SO;

    
    void Start()
    {
        puntaje_Alto_TF = GameObject.Find("PuntajeAlto").transform;
        puntaje_TF = GameObject.Find("Puntaje").transform;
        puntaje_Alto_Txt = puntaje_Alto_TF.GetComponent<TMP_Text>();
        puntaje_Txt = puntaje_TF.GetComponent<TMP_Text>();

        puntaje_Alto_SO.Cargar();
        puntaje_Alto_Txt.text = $"Mejor Puntaje: {puntaje_Alto_SO.puntaje_Alto}";
        puntaje_Alto_SO.puntaje = 0;
    }

    // Update is called once per frame
    void Update()
    {
        puntaje_Txt.text = $"Puntaje Actual: {puntaje_Alto_SO.puntaje}";
        if (puntaje_Alto_SO.puntaje > puntaje_Alto_SO.puntaje_Alto)
        {
            puntaje_Alto_SO.puntaje_Alto = puntaje_Alto_SO.puntaje;
            puntaje_Alto_Txt.text = $"Mejor Puntaje: {puntaje_Alto_SO.puntaje_Alto}";
            puntaje_Alto_SO.Guardar();
            
        }     
    }

    public void AumentarPuntaje(int puntos)
    {
        puntaje_Alto_SO.puntaje += puntos;
    }
}
