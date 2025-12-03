using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPaddleController : MonoBehaviour
{
    public float speed = 3f;
    public bool secondPlayer = false;
    public PlayerPaddleController playerPaddleController;
    public SpriteRenderer spriteRenderer;


    private Rigidbody2D rb;
    private GameObject ball;

    void Start()
    {
        secondPlayer = SaveController.Instance.secondPlayer;
        if (!secondPlayer)
        {
            rb = GetComponent<Rigidbody2D>();
            ball = GameObject.Find("Ball");
        }

        spriteRenderer.color = SaveController.Instance.colorEnemy;

    }

    void Update()
    {
        if (secondPlayer)
        {
            float moveInput = Input.GetAxis("Vertical2");
            Vector3 newPosition = transform.position + Vector3.up * moveInput * playerPaddleController.speed * Time.deltaTime;
            newPosition.y = Mathf.Clamp(newPosition.y, -4.5f, 4.5f);
            transform.position = newPosition;
        }
        else
        {
            if (ball != null)
            {
                float targetY = Mathf.Clamp(ball.transform.position.y, -4.5f, 4.5f);
                Vector2 targetPosition = new Vector2(transform.position.x, targetY);
                transform.position = Vector2.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
            }
        }
    }
}
