using UnityEngine;

public class SnowBall : MonoBehaviour
{
    [SerializeField] private AudioSource audioSourceHit = null;
    [SerializeField] private ParticleSystem particleSystemHit = null;
    [SerializeField] private SpriteRenderer spriteRenderer = null;
    [SerializeField] private bool isHippoSnowBall = false;
    public float minHeight = 0.0f;


    private void Update()
    {
        if (isHippoSnowBall && transform.position.y < minHeight)
        {
            Destroy(gameObject);
        }
        else if(transform.position.x < -15.0f)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        var character = collision.gameObject.GetComponent<Character>();
        if (character)
        {
            spriteRenderer.enabled = false;
            audioSourceHit.Play();
            character.GetDamage();
            var effectHit = Instantiate(particleSystemHit, transform.position, Quaternion.identity);
            Destroy(effectHit, 0.3f);
            Destroy(gameObject, 0.31f);
        }
    }
}
