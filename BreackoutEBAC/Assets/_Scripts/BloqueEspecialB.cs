using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueEspecialB : BloqueBase
{
    [SerializeField]
    bool special=true;
    public GameObject ball;

    // Start is called before the first frame update
    void Start()
    {
        ball = GameObject.FindGameObjectWithTag("ball");
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

        if (recistencia<=0 && special)
        {
            
            Instantiate(ball);
            Destroy(this.gameObject);
            
        }
        
    }
}
