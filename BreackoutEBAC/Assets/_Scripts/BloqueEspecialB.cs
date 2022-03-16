using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueEspecialB : BloqueBase
{
    //Asignación de valores individuales
    public override void Start()
    {
        resistance = 3;
        material = "SpecialB";
        pointsScore = 30;
    }
}
