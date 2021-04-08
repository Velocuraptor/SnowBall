using System.Collections;
using UnityEngine;

public class HippoSnowBall : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceHit = null;
    [SerializeField] private ParticleSystem particleSystemHit = null;
    public float minHeight = 0.0f;

    private void Update()
    {
        if (transform.position.y <= minHeight)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            audioSourceHit.Play();
            enemy.GetDamage();
            particleSystemHit.transform.position = transform.position;
            particleSystemHit.Play();
            gameObject.SetActive(false);
        }
    }


}
