using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySnowBall : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceHit = null;
    [SerializeField] private ParticleSystem particleSystemHit = null;

    private void Update()
    {
        if (transform.position.x < -10)
            gameObject.SetActive(false);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Hippo hippo = collision.gameObject.GetComponent<Hippo>();
        if (hippo)
        {
            audioSourceHit.Play();
            hippo.GetDamage();
            particleSystemHit.transform.position = transform.position;
            particleSystemHit.Play();
            gameObject.SetActive(false);
        }    
    }
}
