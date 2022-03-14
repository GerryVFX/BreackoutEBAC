using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDownDificultad : MonoBehaviour
{
    public Opciones options;
    private Dropdown dificult;


    public void Start()
    {
        dificult = GetComponent<Dropdown>();
        dificult.onValueChanged.AddListener(delegate { options.ChangeDificult(dificult.value); });

        
    }
}
