using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PuntajeFinal : MonoBehaviour
{
    public Transform puntaje_Alto_Final;
    public Transform puntaje_final;
    TMP_Text puntaje_Alto_Final_Txt;
    TMP_Text puntaje_Final_Txt;

    public GameObject texto2;

    public Puntaje_Alto ultimoPuntaje;

    void Update()
    {
        puntaje_Alto_Final_Txt = puntaje_Alto_Final.GetComponent<TMP_Text>();
        puntaje_Final_Txt = puntaje_final.GetComponent<TMP_Text>();

        

        if (ultimoPuntaje.puntaje >= ultimoPuntaje.puntaje_Alto)
        {
            texto2.SetActive(false);
            puntaje_Alto_Final_Txt.text = $"Nuevo record: {ultimoPuntaje.puntaje_Alto}";
        }
        else
        {
            puntaje_Alto_Final_Txt.text = $"Mejor puntaje: {ultimoPuntaje.puntaje_Alto}";
            puntaje_Final_Txt.text = $"Tu puntaje fue: {ultimoPuntaje.puntaje}";
        }
    }
}
