using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueBase : MonoBehaviour
{
    public int         recistencia;
    public int         fuerzaRebote;
    public PuntajeAlto puntajeALtoSO;




    // Start is called before the first frame update
    void Start()
    {
        
        
        recistencia = 1;
        
    }

    // Update is called once per frame
    void Update()
    {
        DestrucionDeBloque();
        RebotarBola();
    }

    public virtual void RebotarBola()
    {
        fuerzaRebote = 5;
    }

    public virtual void DestrucionDeBloque()
    {
        if (recistencia <= 0) Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ball")
        {
            GameObject mispuntos=GameObject.Find("Display");
            puntajeALtoSO.puntaje += 20;
            
        }
    }
}
