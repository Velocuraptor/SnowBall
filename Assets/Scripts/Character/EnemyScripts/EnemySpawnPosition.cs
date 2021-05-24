using System.Collections;
using UnityEngine;

public class EnemySpawnPosition : MonoBehaviour
{
    [SerializeField] private Enemy[] enemies = null;
    [SerializeField] private float speed = 0;
    public Rigidbody2D snowball = null;
    public Enemy enemyActive = null;
    private Vector3 endPosition;
    private Vector3 startPosition;

    private void Start()
    {
        endPosition= startPosition = transform.position;
        endPosition.x = 6;
    }

    public void CreateEnemy()
    {
        enemyActive = enemies[Random.Range(0, 3)];
        enemyActive.gameObject.SetActive(true);
        enemyActive.transform.localScale = Vector3.one;
        enemyActive.spawnPosition = this;
        StartCoroutine(StartLife());
    }

    private IEnumerator StartLife()
    {
        float k = 0.0f;
        enemyActive.SetCharacterState("Run");
        while (k < 1)
        {
            k += Time.deltaTime * speed;
            enemyActive.transform.position = Vector3.Lerp(transform.position, endPosition, k);
            yield return null;
        }
        enemyActive.SetCharacterState("Idle");
        enemyActive.StartLife();
}

    public IEnumerator EndLife()
    {
        float k = 0.0f;
        Vector3 startPosition = enemyActive.transform.position;
        Vector3 scale = enemyActive.transform.localScale;
        scale.x *= -1;
        enemyActive.transform.localScale = scale;
        enemyActive.SetCharacterState("Run");
        while (k < 1)
        {
            k += Time.deltaTime * speed;
            enemyActive.transform.position = Vector3.Lerp(startPosition, transform.position, k);
            yield return null;
        }
        scale.x *= -1;
        enemyActive.transform.localScale = scale;
        enemyActive.gameObject.SetActive(false);
        CreateEnemy();
    }

    public void ResetPosition()
    {
        StopAllCoroutines();
        enemyActive.gameObject.SetActive(false);
        enemyActive.transform.position = startPosition;
    }
}
