using UnityEngine;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private GameObject window = null;
    [SerializeField] private WindowController windowController = null;

    public void OpenWindow()
    {
        window.SetActive(true);
        windowController.SetActivateWindow(this);
    }

    public  void CloseWindow()
    {
        window.SetActive(false);
    }
}
