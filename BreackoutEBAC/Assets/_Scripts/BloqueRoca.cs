using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueRoca : BloqueBase
{
    // Start is called before the first frame update
    void Start()
    {
        recistencia = 4;
    }

    public override void RebotarBola()
    {
        base.RebotarBola();
        fuerzaRebote = 3;
    }
}
