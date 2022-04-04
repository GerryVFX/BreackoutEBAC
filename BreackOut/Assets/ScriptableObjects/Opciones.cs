using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Opciones",menuName ="Tools/Opciones",order=1)]

public class Opciones : PuntajePersistente
{
    public float volumen = 30f;
    public dificultad nivelDificultad = dificultad.normal;
    public control tipoControl = control.mouse;

    public enum control
    {
        mouse,
        joystick
    }

    public enum dificultad
    {
        facil,
        normal,
        dificil
    }

    public void ModificarVolumen(float nuevoVolumen)
    {
        volumen = nuevoVolumen;
    }

    public void CambiarControl(int nuevoControl)
    {
        tipoControl = (control)nuevoControl;
    }

    public void CambiarDificultad(int nuevaDificultad)
    {
        nivelDificultad = (dificultad)nuevaDificultad;
    }
}
