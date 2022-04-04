using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DroopDownControl : MonoBehaviour
{
    public Opciones opciones;
    Dropdown control;

    void Start()
    {
        control = this.GetComponent<Dropdown>();
        control.onValueChanged.AddListener(delegate { opciones.CambiarControl(control.value); });
    }   
}
