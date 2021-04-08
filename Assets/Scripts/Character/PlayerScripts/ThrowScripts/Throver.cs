using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throver : MonoBehaviour
{
    [SerializeField] private AudioSource audioThrow = null;
    [SerializeField] private Transform SpawnTransform = null;
    [SerializeField] private HippoSnowBall snowball = null;
    [SerializeField] private Scale scale = null;
    [SerializeField] private float AngleInDegrees;
    [SerializeField] private float handicap = 1.2f;
    private Vector3 target = Vector3.right * 6;
    private float velocity = 0;
    float g = Physics.gravity.y;

    private void Start()
    {
        VelocutySettings();
    }

    private void VelocutySettings()
    {
        SpawnTransform.localEulerAngles = new Vector3(-AngleInDegrees, 0f, 0f);
        target.y = SpawnTransform.position.y;
        Vector3 fromTo = target - transform.position;
        Vector3 fromToXZ = new Vector3(fromTo.x, 0f, fromTo.z);
        transform.rotation = Quaternion.LookRotation(fromToXZ, Vector3.up);
        float x = fromTo.x;
        float y = fromTo.y;
        float AngleInRadians = AngleInDegrees * Mathf.PI / 180;
        float v2 = (g * x * x) / (2 * (y - Mathf.Tan(AngleInRadians) * x) * Mathf.Pow(Mathf.Cos(AngleInRadians), 2));
        velocity = Mathf.Sqrt(Mathf.Abs(v2));
    }

    public void Throw()
    {
        if (GameManager.isGame)
        {
            snowball.gameObject.SetActive(true);
            snowball.transform.position = transform.position;
            snowball.minHeight = transform.position.y - 0.6f;

            float newScale = handicap * scale.fill;
            if (newScale > 1)
                newScale = 1;

            audioThrow.volume = scale.fill;
            audioThrow.Play();

            snowball.GetComponent<Rigidbody2D>().velocity = SpawnTransform.forward * velocity * newScale;
        }
    }

}
