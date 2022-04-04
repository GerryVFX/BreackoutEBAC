using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloque_SpecialA : Bloque
{


    void Start()
    {
        gameGM = GameObject.FindObjectOfType<GameManager>();
        recistencia = 1;
        punto = 25;
        material = "SpecialA";
    }
   
    

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
    }
}
