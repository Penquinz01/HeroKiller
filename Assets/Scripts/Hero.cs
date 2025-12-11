using UnityEngine;

public class Hero : MonoBehaviour
{
    float hp = 100;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy1"))
        {
            hp = hp - 5;
        }
        if (collision.collider.CompareTag("Enemy2"))
        {
            hp = hp - 10;
        }
        if (collision.collider.CompareTag("Enemy3"))
        {
            hp = hp - 15;
        }
    }
}
