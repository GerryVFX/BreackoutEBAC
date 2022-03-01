using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloqueBase : MonoBehaviour
{
    public int resistencia;
    public GameObject ball;
    [SerializeField]
    protected bool especial;

    // Start is called before the first frame update
    void Start()
    {
        resistencia = 1;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (resistencia <= 0)
        {
            Destroy(this.gameObject);
        }
    }

   
}
