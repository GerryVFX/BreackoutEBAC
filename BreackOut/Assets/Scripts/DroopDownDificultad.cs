using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroopDownDificultad : MonoBehaviour
{
    public Opciones opciones;
    Dropdown dificultad;

    void Start()
    {
        dificultad = this.GetComponent<Dropdown>();
        dificultad.onValueChanged.AddListener(delegate { opciones.CambiarDificultad(dificultad.value); });
    }    
}
