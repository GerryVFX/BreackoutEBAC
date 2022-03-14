using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueEspecialA : BloqueBase
{
    [SerializeField]
    bool special=true;

    public Padle player;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Padle>();
        recistencia = 3;
    }

    public override void RebotarBola(Collision collision)
    {
        base.RebotarBola(collision);
        fuerzaRebote = 15;
    }

    public override void DestrucionDeBloque()
    {
        base.DestrucionDeBloque();

        if (recistencia <= 0 && special)
        {

            player.specialP = true;
            Destroy(this.gameObject);

        }

    }
}
