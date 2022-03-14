using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueEspecialA : BloqueBase
{
    //[SerializeField]
    //bool special

    //public Padle player;

    // Start is called before the first frame update
    public override void  Start()
    {
        resistance = 3;
        material = "SpecialA";
        pointsScore = 30;
    }

    //public override void RebotarBola(Collision collision)
    //{
    //    base.RebotarBola(collision);
    //    fuerzaRebote = 15;
    //}

    //public override void DestrucionDeBloque()
    //{
    //    base.DestrucionDeBloque();

    //    if (recistencia <= 0 && special)
    //    {

    //        player.specialP = true;
    //        Destroy(this.gameObject);

    //    }

    //}
}
