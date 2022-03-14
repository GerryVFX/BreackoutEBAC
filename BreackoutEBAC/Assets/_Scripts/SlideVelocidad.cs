using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SlideVelocidad : MonoBehaviour
{
    public Opciones options;
    Slider slider;


    
    void Start()
    {
        slider = this.GetComponent<Slider>();
        slider.onValueChanged.AddListener(delegate { ControlCambios(); });
    }

    public void ControlCambios()
    {
        options.ChangeSpeed(slider.value);
    }

    
}
