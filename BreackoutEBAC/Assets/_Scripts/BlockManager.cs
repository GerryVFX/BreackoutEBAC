using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour
{
    public GameObject menu;
    void Update()
    {
        if (transform.childCount == 0)
        {
            menu.SetActive(true);
        }
    }
}
