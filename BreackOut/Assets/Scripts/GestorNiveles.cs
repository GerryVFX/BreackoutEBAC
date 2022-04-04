using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GestorNiveles : MonoBehaviour
{
    public GameManager gameMG;

    void Update()
    {
        if (this.gameObject.tag == "Nivel1")
        {
            if (transform.childCount == 0)
            {
                gameMG.nivel1 = true;
            }
        }
        if (this.gameObject.tag == "NIvel2")
        {
            if (transform.childCount == 0)
            {
                gameMG.nivel2 = true;
            }
        }
        if (this.gameObject.tag == "Nivel3")
        {
            if (transform.childCount == 0)
            {
                gameMG.nivel3 = true;
            }
        }
        if (this.gameObject.tag == "Nivel4")
        {
            if (transform.childCount == 0)
            {
                gameMG.nivel4 = true;
            }
        }
        if (this.gameObject.tag == "Nivel5")
        {
            if (transform.childCount == 0)
            {
                gameMG.nivel5 = true;
            }
        }
        if (this.gameObject.tag == "Nivel6")
        {
            if (transform.childCount == 0)
            {
                gameMG.nivel6 = true;
            }
        }
        if (this.gameObject.tag == "Nivel7")
        {
            if (transform.childCount == 0)
            {
                gameMG.nivel7 = true;
            }
        }
        if (this.gameObject.tag == "Nivel8")
        {
            if (transform.childCount == 0)
            {
                gameMG.nivel8 = true;
            }
        }
        if (this.gameObject.tag == "Nivel9")
        {
            if (transform.childCount == 0)
            {
                gameMG.nivel9 = true;
            }
        }
        if (this.gameObject.tag == "Nivel10")
        {
            if (transform.childCount == 0)
            {
                Time.timeScale = 0;
                gameMG.nivel10 = true;
            }
        }
    }
}
