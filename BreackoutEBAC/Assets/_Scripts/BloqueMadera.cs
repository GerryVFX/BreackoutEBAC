using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueMadera : BloqueBase
{
    //Asignaci�n de valores individuales
    public override void Start()
    {
        resistance  =      2;
        material    = "Wood";
        pointsScore =     20;
    }
}
