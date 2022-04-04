using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    //Escena 0
    public GameObject menuInicial;
    public GameObject menuOpciones;

    //Escena 1
    public GameObject userInterface;
    public GameObject menuPausa;

    public Puntaje_Alto puntajes;
    
    //Escena 1
    public void IniciarJuego()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
    }

    public void QuitarJuego()
    {
        Application.Quit();
    }

    public void MostrarOpciones()
    {
        menuInicial.SetActive(false);
        menuOpciones.SetActive(true);
    }
    public void OcultarOpciones()
    {
        menuInicial.SetActive(true);
        menuOpciones.SetActive(false);
    }

    //Escena 0 / 1
    public void VolverMenuPrincipal()
    {
        SceneManager.LoadScene(0);
    }

    //Escena 1
    public void MostrarPausa()
    {
        userInterface.SetActive(false);
        menuPausa.SetActive(true);
        Time.timeScale = 0;    
    }

    public void OcultarPausa()
    {
        userInterface.SetActive(true);
        menuPausa.SetActive(false);
        Time.timeScale = 1;
    }

    public void RecetPuntaje()
    {
        puntajes.puntaje_Alto = 0;
    }
}
