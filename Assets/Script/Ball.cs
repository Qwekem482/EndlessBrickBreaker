using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static float speed = 10;
    
    [SerializeField] private AudioSource borderBounce;
    [SerializeField] private AudioSource blockBounce;
    [SerializeField] private AudioSource basketBounce;

    void Start()
    {
        Push();
    }
    public void Push()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.up * speed;
    }

    private float CalcDirection(Vector2 ballPosition, Vector2 basketPosition, float basketWidth)
    {
        return (ballPosition.x - basketPosition.x) / basketWidth;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Basket"))
        {
            float directionFactor = CalcDirection(transform.position, collision.transform.position, collision.collider.bounds.size.x);
            Vector2 direction = new Vector2(directionFactor, 1).normalized;

            GetComponent<Rigidbody2D>().velocity = direction * speed;
            basketBounce.Play();
        }

        if(collision.gameObject.CompareTag("DeathLine"))
        {
            Game.SubLive();
            this.transform.position = new Vector3(0f, -8.7f, 10f);
        }

        if(collision.gameObject.CompareTag("Block"))
        {
            Game.AddScore();
            blockBounce.Play();
        }

        if(collision.gameObject.CompareTag("Border"))
        {
            borderBounce.Play();
        }
    }
}
