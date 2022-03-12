using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueMadera : BloqueBase
{
    // Start is called before the first frame update
    void Start()
    {
        recistencia = 2;
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
        fuerzaRebote = 10;
        
    }
}
