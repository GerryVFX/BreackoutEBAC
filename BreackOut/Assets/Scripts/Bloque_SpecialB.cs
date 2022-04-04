using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_SpecialB : Bloque
{


    void Start()
    {
        recistencia = 1;
        punto = 25;
        material = "SpecialB";
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }
}
