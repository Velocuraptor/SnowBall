using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private GameObject window = null;
    [SerializeField] private GameManager gameManager = null;

    public void OpenWindow()
    {
        window.SetActive(true);
        gameManager.SetActivateWindow(this);
    }

    public  void CloseWindow()
    {
        window.SetActive(false);
    }
}
