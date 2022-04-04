using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //Bolas extra
    public int n_bolas;

    //Gestión de vidas
    public List<GameObject> vidas;
    public GameObject menuGameOver;

    //Bolas por vidas
    public GameObject bolaPF;
    private Bola bolaSC;

    //Gestion de niveles
    public bool nivel1, nivel2, nivel3, nivel4, nivel5, nivel6, nivel7, nivel8, nivel9, nivel10 = false;
    public GameObject[] niveles;
    public GameObject menuFInal;

    void Start()
    {
        //Se asigna numero de bolas inicial
        n_bolas = 1;

        //Se adquieren numero de vidas
        Transform[] hijos = GetComponentsInChildren<Transform>();
        foreach (Transform hijo in hijos)
        {
            vidas.Add(hijo.gameObject);
        }
    }

    public void Update()
    {
        //Condición para perder vida
        if (n_bolas <= 0)
        {
            EliminarVida();
        }

        GestionNiveles();
    }

    //Funsión de gestión de vidas y game over
    public void EliminarVida()
    {
        var objetoAEliminar = vidas[vidas.Count - 1];
        Destroy(objetoAEliminar);
        vidas.RemoveAt(vidas.Count - 1);
        if (vidas.Count <= 0)
        {
            menuGameOver.SetActive(true);
            return;
        }
        var bola = Instantiate(bolaPF) as GameObject;
        bolaSC = bolaPF.GetComponent<Bola>();
        n_bolas += 1;
        bolaSC.juego_Comenzo = false;
        print($"Vidas restantes {vidas.Count}");
    }

    public void GestionNiveles()
    {
        if (nivel1) niveles[1].SetActive(true);
        if (nivel2) niveles[2].SetActive(true);
        if (nivel3) niveles[3].SetActive(true);
        if (nivel4) niveles[4].SetActive(true);
        if (nivel5) niveles[5].SetActive(true);
        if (nivel6) niveles[6].SetActive(true);
        if (nivel7) niveles[7].SetActive(true);
        if (nivel8) niveles[8].SetActive(true);
        if (nivel9) niveles[9].SetActive(true);
        if (nivel10) menuFInal.SetActive(true);
    }
}
