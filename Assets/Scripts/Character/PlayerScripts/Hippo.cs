using UnityEngine;

public class Hippo : CharacterAnimation
{
    [SerializeField] private GameManager gameManager = null;
    [SerializeField] private Rigidbody2D rigidbody2D = null;
    public float speed = 3;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    internal void GetDamage()
    {
        gameManager.LoseHeart();
    }

    private void FixedUpdate()
    {
        Move();
    }
    
    private void Move()
    {
        float direction = SimpleInput.GetAxis("Vertical");
        if (GameManager.isGame && direction != 0)
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

    public void ResetGame()
    {
        transform.position = startPosition;
    }
}
