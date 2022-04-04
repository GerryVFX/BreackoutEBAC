using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolumen : MonoBehaviour
{
    public Opciones opciones;
    Slider slider;
   

    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ControlCambios(); });
    }

    public void ControlCambios()
    {
        opciones.ModificarVolumen(slider.value);
    }
}
