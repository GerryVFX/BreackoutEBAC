using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Roca: Bloque
{


    void Start()
    {
        
        recistencia = 5;
        punto = 50;
        material = "Rock";
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }
}
