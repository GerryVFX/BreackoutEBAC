using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueRoca : BloqueBase
{
    // Start is called before the first frame update
    public override void Start()
    {
        resistance  =      4;
        material    = "Rock";
        pointsScore =     50;
    }

    //public override void RebotarBola(Collision collision)
    //{
    //    base.RebotarBola(collision);
    //    fuerzaRebote = 3;
    //}
}
