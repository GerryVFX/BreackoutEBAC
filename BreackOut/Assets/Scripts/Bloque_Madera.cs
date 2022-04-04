using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_Madera : Bloque
{
    

    
    void Start()
    {
        recistencia = 3;
        punto = 20;
        material = "Wood";
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }
}
