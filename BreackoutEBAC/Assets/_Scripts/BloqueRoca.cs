using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueRoca : BloqueBase
{
    //Asignaci�n de valores individuales
    public override void Start()
    {
        resistance  =      4;
        material    = "Rock";
        pointsScore =     50;
    }
}
