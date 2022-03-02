using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    //Variables Selector de bloque
    [SerializeField]
    int numMaterial;
    public int recistencia;
    bool especialA;
    bool especialB;    
    public string material;

    //Variables efectos de bloques especiales
    [SerializeField]
    GameObject ball,padle;
    Padle player;
    
    

    private void Awake()
    {
        //Asignación de numero de bloque
        if (this.gameObject.tag == "Wood")
        {
            numMaterial = 1;
        }else if (this.gameObject.tag == "Rock")
        {
            numMaterial = 2;
        }else if (this.gameObject.tag == "Special")
        {
            numMaterial = 3;
        }
        else if (this.gameObject.tag == "SpecialB")
        {
            numMaterial = 4;
        }
        //Comunicación con el jugador para PowerUps
        player = FindObjectOfType<Padle>();
    }

    void Start()
    {
        //Se asigna que tipo de bloque es
        SelectorDeMaterial();
    }
    
    void Update()
    {
        //Detecta si hay una destrucción de bloque
        DestruirBlock();
    }

    //Selector de bloque segpun asignación
    void SelectorDeMaterial()
    {
        switch (numMaterial)
        {
            case 0:
                material = "Basico";
                recistencia = 1;
                break;
            case 1:
                material = "Madera";
                recistencia = 2;
                break;
            case 2:
                material = "Roca";
                recistencia = 4;
                break;
            case 3:
                material = "Especial";
                recistencia = 3;
                especialA = true;
                break;
            case 4:
                material = "EspecialB";
                recistencia = 3;
                especialB = true;
                break;
        }
    }

    //Metodo para la destrucción de bloques
    void DestruirBlock()
    {
        if (recistencia <= 0)
        {
            Destroy(this.gameObject);
        }
        if (recistencia <= 0 && especialA)
        {
            Instantiate(ball);
            ball.transform.position = this.gameObject.transform.position;
            Destroy(this.gameObject);
        }
        if (recistencia <= 0 && especialB)
        {
            player.specialP = true;
            Destroy(this.gameObject);
        }
    }
}
