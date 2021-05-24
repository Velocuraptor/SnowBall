using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class SnowballButton : MonoBehaviour
{
    [SerializeField] private Image image = null;
    [SerializeField] private Button button = null;
    public float timeReaload = 2.0f;

    public void ResetButton()
    {
        StopAllCoroutines();
        image.fillAmount = 1;
        button.interactable = true;
    }

    public void Reload()//Button
    {
        image.fillAmount = 0;
        button.interactable = false;
        StartCoroutine(Filling(timeReaload));
    }

    private IEnumerator Filling(float timeReaload)
    {
        float timeFill = timeReaload;
        while(timeFill > 0)
        {
            timeFill -= Time.deltaTime;
            image.fillAmount += Time.deltaTime / this.timeReaload;
            yield return null;
        }
        button.interactable = true;
    }
}
