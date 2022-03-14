using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueMadera : BloqueBase
{

    public override void Start()
    {
        resistance  =      2;
        material    = "Wood";
        pointsScore =     20;
    }

    //public override void RebotarBola(Collision collision)
    //{
    //    base.RebotarBola(collision);
    //    fuerzaRebote = 10;

    //}
}
