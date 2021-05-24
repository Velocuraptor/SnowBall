using UnityEngine;

public class EnemyStoper : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        if (enemy)
            enemy.SwitchDirection();
    }
}
