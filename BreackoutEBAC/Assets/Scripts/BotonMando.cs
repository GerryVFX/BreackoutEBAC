using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMando : MonoBehaviour
{
    public void Reinicio()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void Salir()
    {
        Application.Quit();
    }
    public void mandoMouse()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Padle>().selectorControl = true;
    }
    public void mandoMando()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Padle>().selectorControl = false;
    }
}
