using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public bool       inMenu;
    public GameObject miPanel;


    
    public  void ButtonMenu()
    {
        if (!inMenu)
        {
            inMenu = true;
            miPanel.SetActive(true);
        }
        else
        {
            inMenu = false;
            miPanel.SetActive(false);
        }            
    }

    public void Reinicio()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void Salir()
    {
        Application.Quit();
    }

    //public void mandoMouse()
    //{
    //    GameObject.FindGameObjectWithTag("Player").GetComponent<Padle>().selectorControl = true;
    //}

    //public void mandoMando()
    //{
    //    GameObject.FindGameObjectWithTag("Player").GetComponent<Padle>().selectorControl = false;
    //}


}
