using System.Collections;
using UnityEngine;

public class Enemy : CharacterAnimation
{
    [SerializeField] private Transform target = null;
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private Rigidbody2D rigidbody2D = null;
    [SerializeField] private float speedSnowball = 10.0f;
    public float speed = 3;
    public int points = 1;
    public SpawnPosition spawnPosition = null;

    private int direction = 1;
    private bool isStop = false;

    public void StartLife()
    {
        StartCoroutine(TimeDelay(Random.Range(1.5f, 3.5f)));
    }

    private void FixedUpdate()
    {

        if (GameManager.isGame && !isStop)
        {
            SetCharacterState("Run");
            rigidbody2D.velocity = Vector2.up * (direction * speed);
        }
        else
        {
            SetCharacterState("Idle");
            rigidbody2D.velocity = Vector2.zero;
        }
    }

    private IEnumerator TimeDelay(float delay)
    {
        while (0 < delay)
        {
            delay -= Time.deltaTime;
                yield return null;
        }
        Stop();
    }

    private void Stop()
    {
        if (!isStop)
        {
            isStop = true;
            StartCoroutine(TimeDelay(Random.Range(0.5f, 1.0f)));
        }
        else
        {
            isStop = false;
            StartCoroutine(TimeDelay(Random.Range(1.5f, 3.5f)));
        }
    }
    
    public void SwitchDirection()
    {
        direction *= -1;
    }
    
    public void GetDamage()
    {
        gameManager.SetScore(points);
        StartCoroutine(DeleyRunWay());
    }

    private IEnumerator DeleyRunWay()
    {
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(spawnPosition.EndLife());
    }

    public void Throw()
    {
        Vector3 fromTo = target.position - transform.position;
        var snowball = spawnPosition.snowball;
        snowball.gameObject.SetActive(true);
        snowball.transform.position = transform.position;
        snowball.velocity = fromTo * speedSnowball;
    }
}
