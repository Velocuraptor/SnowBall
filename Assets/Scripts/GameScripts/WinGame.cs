using UnityEngine;

public class WinGame : Window
{
    [SerializeField] private GameObject[] stars = null;


    public void ActiveStar(int count)
    {
        for (int i = 0; i < count; i++)
        {
            stars[i].SetActive(true);
        }
    }

    public void ResetStar()
    {
        StopAllCoroutines();
        for (int i = 0; i < 3; i++)
        {
            stars[i].SetActive(false);
        }
    }
}
