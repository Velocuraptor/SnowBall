using UnityEngine;
using UnityEngine.UI;

public class Scale : MonoBehaviour
{
    [SerializeField] private Image scale = null;
    [SerializeField] private float step = 0.01f;
    public float fill = 0.0f;

    private void FixedUpdate()
    {
        if (GameManager.isGame)
        {
            fill += step;
            scale.fillAmount = fill;
            if (scale.fillAmount == 1 || scale.fillAmount == 0)
                step *= -1;
        }
    }
}
